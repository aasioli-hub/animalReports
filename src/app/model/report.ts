export interface Report {
  id?: number;
  description?: string;
  title: string;
  date: string;
  categories: string[];
  images: string[];
  lat: number;
  lng: number;
  distance?: number;
}


// enum Category{
//   Mammal = "Mammal",
//   Bird = "Bird",
//   Reptile = "Reptile",
// }