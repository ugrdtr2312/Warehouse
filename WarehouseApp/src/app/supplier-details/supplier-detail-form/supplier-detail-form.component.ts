import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { SupplierDetail } from 'src/app/shared/supplier/supplier-detail.model';
import { SupplierDetailService } from 'src/app/shared/supplier/supplier-detail.service';

@Component({
  selector: 'app-supplier-detail-form',
  templateUrl: './supplier-detail-form.component.html',
  styles: [
  ]
})
export class SupplierDetailFormComponent implements OnInit {

  constructor(public service:SupplierDetailService, private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  onSubmit(form:NgForm){
    if(this.service.formData.id == 0)
      this.inserRecord(form);
    else 
      this.updateRecord(form);
  }

  inserRecord(form: NgForm){
    this.service.postSupplierDetails().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.success('Submitted succesfully', "Supplier added")
      },
      err => {
        console.log(err);
      }
    );
  }

  updateRecord(form:NgForm){
    this.service.putSupplierDetails().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.info('Updated succesfully', "Supplier updated")
      },
      err => {
        console.log(err);
      }
    );
  }

  resetForm(form:NgForm){
    form.form.reset();
    this.service.formData = new SupplierDetail();
  }
}
