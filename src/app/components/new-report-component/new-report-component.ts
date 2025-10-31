import { I } from '@angular/cdk/keycodes';
import { Component, inject } from '@angular/core';
import { FormArray, FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { DataService } from '../../services/data-service/data-service';


@Component({
  selector: 'app-new-report-component',
  imports: [ReactiveFormsModule],
  templateUrl: './new-report-component.html',
  styleUrl: './new-report-component.scss'
})
export class NewReportComponent {

  private fb = new FormBuilder();
  public dataServ = inject(DataService);
  public categoryNames: string[] = [];

  constructor() {
    this.dataServ.getCategories().then(categories => {
      this.categoryNames = categories;
    });
  }

  public reportForm = this.fb.group({
    title: ['', Validators.required, Validators.minLength(5)],
    description: [''],
    categories: this.fb.array([
      this.fb.control(''),
    ]),
  });

  get categories() {
    return this.reportForm.get('categories') as FormArray;
  }

  addCategoryInput() {
    this.categories.push(this.fb.control(''));
  }

  removeCategoryInput(index: number) {
    console.log(index);
    
    this.categories.removeAt(index);
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
    console.log(this.reportForm.valid);
    console.log(this.reportForm.value);
  }
}
