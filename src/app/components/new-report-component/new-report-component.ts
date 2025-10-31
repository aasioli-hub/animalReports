import { Component, inject } from '@angular/core';
import {
  FormArray,
  FormBuilder,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { DataService } from '../../services/data-service/data-service';
import { LocationService } from '../../services/location-service/location-service';
import { Report } from '../../model/report';

@Component({
  selector: 'app-new-report-component',
  imports: [ReactiveFormsModule],
  templateUrl: './new-report-component.html',
  styleUrl: './new-report-component.scss',
})
export class NewReportComponent {
  private fb = new FormBuilder();
  public dataServ = inject(DataService);
  public categoryNames: string[] = [];

  public images: string[] = [];

  private locationServ = inject(LocationService);
  private dataSer = inject(DataService);

  constructor() {
    this.dataServ.getCategories().then((categories) => {
      this.categoryNames = categories;
    });
  }

  public reportForm = this.fb.group({
    title: [''],
    description: [''],
    categories: this.fb.array([this.fb.control('', Validators.required)]),
  });

  get categories() {
    return this.reportForm.get('categories') as FormArray;
  }

  get image() {
    return this.reportForm.get('image')?.value;
  }

  addCategoryInput() {
    this.categories.push(this.fb.control('', Validators.required));
  }

  removeCategoryInput(index: number) {
    console.log(index);
    if (this.categories.length > 1){
      this.categories.removeAt(index);
    }

    
  }

  onImageSelected(event: Event) {
    const element = event.target as HTMLInputElement;
    if (element.files && element.files.length > 0) {
      const file = element.files[0];
      const reader = new FileReader();
      reader.onload = () => {

        this.images.push(reader.result as string);

      }
      reader.readAsDataURL(file);
    }
  }



  // public userform = this.fb.group({
  //   firstName: [''],
  //   lastName: [''],
  //   email: [''],
  //   address: this.fb.group({
  //     street: [''],
  //     city: [''],
  // })});

  // user = {
  //   firstName: 'John',
  //   lastName: 'Doe',
  //   email: 'jd@hotmail.com',
  //   address: {
  //     street: '123 Main St',
  //     city: 'Anytown'
  //   }
  // };
  postReport() {

    const newReport: Report = {
      title: this.reportForm.value.title!,
      description: this.reportForm.value.description!,
      categories: this.reportForm.value.categories as string[],
      images: this.images,
      date: new Date().toISOString(),
      lat: 0,
      lng: 0
    }

    this.locationServ.getPosition().then((pos) => {
      newReport.lat = pos.coords.latitude;
      newReport.lng = pos.coords.longitude;

      this.dataSer.postReport(newReport)
    });
  }
}
