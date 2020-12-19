import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { SupplierDetail } from '../shared/supplier/supplier-detail.model';
import { SupplierDetailService } from '../shared/supplier/supplier-detail.service';

@Component({
  selector: 'app-supplier-details',
  templateUrl: './supplier-details.component.html',
  styles: [
  ]
})
export class SupplierDetailsComponent implements OnInit {
  serach:string;
  constructor(public service:SupplierDetailService, private toastr:ToastrService) { }

  ngOnInit(): void {
    this.service.refreshList();
    this.serach ='';
  }

  populateForm(selectedRecord:SupplierDetail){
    this.service.formData =  Object.assign({}, selectedRecord);
  }

  onDelete(id:number){
    if (confirm('Are you sure to delete this record?'))
    {
      this.service.deleteSupplierDetails(id)
      .subscribe(
       res=>{
         this.service.refreshList();
         this.service.formData = new SupplierDetail();
         this.toastr.error("Deleted successfully", "Supplier deleted");
       },
       err => {
        console.log(err);
        }
      )
    }
  }
}
