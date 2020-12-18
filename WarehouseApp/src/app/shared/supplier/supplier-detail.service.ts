import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http"
import { SupplierDetail } from './supplier-detail.model';

@Injectable({
  providedIn: 'root'
})
export class SupplierDetailService {

  constructor(private http:HttpClient) { }

  readonly baseURL = "http://localhost:5000/api/suppliers"
  formData:SupplierDetail = new SupplierDetail();
  list:SupplierDetail[];

  postSupplierDetails(){
    return this.http.post(this.baseURL, this.formData)
  }
 
  putSupplierDetails(){
    return this.http.put(`${this.baseURL}`, this.formData)
  }

  deleteSupplierDetails(id:number){
    return this.http.delete(`${this.baseURL}/${id}`)
  }

  refreshList(){
    this.http.get(this.baseURL).toPromise()
    .then(res => this.list = res as SupplierDetail[]);
  }
}
