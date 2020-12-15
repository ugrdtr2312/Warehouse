import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http"
import { CategoryDetail } from './category-detail.model';

@Injectable({
  providedIn: 'root'
})
export class CategoryDetailService {

  constructor(private http:HttpClient) { }

  readonly baseURL = "http://localhost:5000/api/categories"
  formData:CategoryDetail = new CategoryDetail();
  list:CategoryDetail[];

  postCategoryDetails(){
    return this.http.post(this.baseURL, this.formData)
  }
 
  patchCategoryDetails(){
    return this.http.put(`${this.baseURL}/${this.formData.id}`, this.formData)
  }

  deleteCategoryDetails(id:number){
    return this.http.delete(`${this.baseURL}/${id}`)
  }

  refreshList(){
    this.http.get(this.baseURL).toPromise()
    .then(res => this.list = res as CategoryDetail[]);
  }
}
