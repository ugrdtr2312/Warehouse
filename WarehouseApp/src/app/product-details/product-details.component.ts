import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { ProductDetail } from '../shared/product/product-detail.model';
import { ProductDetailService } from '../shared/product/product-detail.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styles: [
  ]
})
export class ProductDetailsComponent implements OnInit {
  descrip:string;
  constructor(public service:ProductDetailService, private toastr:ToastrService) { }

  ngOnInit(): void {
    this.service.refreshList();
    this.descrip ='';
  }

  populateForm(selectedRecord:ProductDetail){
    this.service.formData =  Object.assign({}, selectedRecord);
  }

  onDelete(id:number){
    if (confirm('Are you sure to delete this record?'))
    {
      this.service.deleteProductDetails(id)
      .subscribe(
       res=>{
         this.service.refreshList();
         this.toastr.error("Deleted successfully", "Product deleted;")
       },
       err => {console.log(err)}
      )
    }
  }
}
