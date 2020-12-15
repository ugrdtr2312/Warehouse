import { ProductDetailService } from 'src/app/shared/product-detail.service';
import { Component, OnInit } from '@angular/core';
import { ProductDetail } from '../shared/product-detail.model';
import { ToastrService } from 'ngx-toastr';

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
