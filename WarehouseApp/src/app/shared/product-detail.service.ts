import { Injectable } from '@angular/core';
import { ProductDetail } from './product-detail.model';
import { HttpClient } from "@angular/common/http"

@Injectable({
  providedIn: 'root'
})
export class ProductDetailService {

  constructor(private http:HttpClient) { }

  readonly baseURL = "http://localhost:5000/api/tasks"
  formData:ProductDetail = new ProductDetail();
  list:ProductDetail[];

  postProductDetails(){
    return this.http.post(this.baseURL, this.formData)
  }
 
  patchProductDetails(){
    return this.http.patch(`${this.baseURL}/${this.formData.id}`, this.formData)
  }

  deleteProductDetails(id:number){
    return this.http.delete(`${this.baseURL}/${id}`)
  }

  refreshList(){
    this.http.get(this.baseURL).toPromise()
    .then(res => this.list = res as ProductDetail[]);
  }
}
