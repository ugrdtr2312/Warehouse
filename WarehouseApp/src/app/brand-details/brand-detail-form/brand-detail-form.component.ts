import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { BrandDetail } from 'src/app/shared/brand/brand-detail.model';
import { BrandDetailService } from 'src/app/shared/brand/brand-detail.service';

@Component({
  selector: 'app-brand-detail-form',
  templateUrl: './brand-detail-form.component.html',
  styles: [
  ]
})

export class BrandDetailFormComponent implements OnInit {

  constructor(public service:BrandDetailService, private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  onSubmit(form:NgForm){
    if(this.service.formData.id == 0)
      this.inserRecord(form);
    else 
      this.updateRecord(form);
  }

  inserRecord(form: NgForm){
    this.service.postBrandDetails().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.success('Submitted succesfully', "Brand added")
      },
      err => {
        console.log(err);
      }
    );
  }

  updateRecord(form:NgForm){
    this.service.putBrandDetails().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.info('Updated succesfully', "Brand updated")
      },
      err => {
        console.log(err);
      }
    );
  }

  resetForm(form:NgForm){
    form.form.reset();
    this.service.formData = new BrandDetail();
  }
}
