import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { CategoryDetail } from '../shared/category/category-detail.model';
import { CategoryDetailService } from '../shared/category/category-detail.service';

@Component({
  selector: 'app-category-details',
  templateUrl: './category-details.component.html',
  styles: [
  ]
})
export class CategoryDetailsComponent implements OnInit {
  categoryName:string;
  constructor(public service:CategoryDetailService, private toastr:ToastrService) { }

  ngOnInit(): void {
    this.service.refreshList();
    this.categoryName ='';
  }

  populateForm(selectedRecord:CategoryDetail){
    this.service.formData =  Object.assign({}, selectedRecord);
  }

  onDelete(id:number){
    if (confirm('Are you sure to delete this record?'))
    {
      this.service.deleteCategoryDetails(id)
      .subscribe(
       res=>{
         this.service.refreshList();
         this.toastr.error("Deleted successfully", "Category deleted")
       },
       err => {console.log(err)}
      )
    }
  }
}
