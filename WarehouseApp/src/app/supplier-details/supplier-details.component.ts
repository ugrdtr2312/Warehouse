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
  cName:string;
  constructor(public service:SupplierDetailService, private toastr:ToastrService) { }

  ngOnInit(): void {
    this.service.refreshList();
    this.cName ='';
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
         this.toastr.error("Deleted successfully", "Supplier deleted");
       },
       err => {
         this.toastr.warning(err);
        }
      )
    }
  }
}
