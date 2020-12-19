import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { CategoryDetail } from 'src/app/shared/category/category-detail.model';
import { CategoryDetailService } from 'src/app/shared/category/category-detail.service';

@Component({
  selector: 'app-category-detail-form',
  templateUrl: './category-detail-form.component.html',
  styles: [
  ]
})
export class CategoryDetailFormComponent implements OnInit {

  constructor(public service:CategoryDetailService, private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  onSubmit(form:NgForm){
    if(this.service.formData.id == 0)
      this.inserRecord(form);
    else 
      this.updateRecord(form);
  }

  inserRecord(form: NgForm){
    this.service.postCategoryDetails().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.success('Submitted succesfully', "Category added")
      },
      err => {
        console.log(err);
      }
    );
  }

  updateRecord(form:NgForm){
    this.service.putCategoryDetails().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.info('Updated succesfully', "Category updated")
      },
      err => {
        console.log(err);
      }
    );
  }

  resetForm(form:NgForm){
    form.form.reset();
    this.service.formData = new CategoryDetail();
  }
}
