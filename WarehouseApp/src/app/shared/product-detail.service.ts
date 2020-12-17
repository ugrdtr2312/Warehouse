import { Injectable } from '@angular/core';
import { ProductDetail } from './product-detail.model';
import { HttpClient } from "@angular/common/http"
import { CategoryDetail } from './category-detail.model';
import { BrandDetail } from './brand-detail.model';

@Injectable({
  providedIn: 'root'
})
export class ProductDetailService {

  constructor(private http:HttpClient) { }

  readonly baseURL = "http://localhost:5000/api/products"
  formData:ProductDetail = new ProductDetail();
  list:ProductDetail[];
  categoryList:CategoryDetail[];
  brandList:BrandDetail[];

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
    this.http.get("http://localhost:5000/api/categories").toPromise()
    .then(res => this.categoryList = res as CategoryDetail[]);
    this.http.get("http://localhost:5000/api/brands").toPromise()
    .then(res => this.brandList = res as BrandDetail[]);
  }
}
