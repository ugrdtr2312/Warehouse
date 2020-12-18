import { BrandDetail } from './../brand/brand-detail.model';
import { Injectable } from '@angular/core';
import { ProductDetail } from './product-detail.model';
import { HttpClient } from "@angular/common/http"
import { CategoryDetail } from '../category/category-detail.model';
import { SupplierDetail } from '../supplier/supplier-detail.model';

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
  supplierList:SupplierDetail[];

  postProductDetails(){
    console.log(this.formData);
    return this.http.post(this.baseURL, this.formData)
  }
 
  putProductDetails(){
    return this.http.put(`${this.baseURL}`, this.formData)
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
    this.http.get("http://localhost:5000/api/suppliers").toPromise()
    .then(res => this.supplierList = res as SupplierDetail[]);
  }
}
