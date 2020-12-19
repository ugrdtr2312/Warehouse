import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { BrandDetail } from '../shared/brand/brand-detail.model';
import { BrandDetailService } from '../shared/brand/brand-detail.service';

@Component({
  selector: 'app-brand-details',
  templateUrl: './brand-details.component.html',
  styles: [
  ]
})

export class BrandDetailsComponent implements OnInit {
  serach:string;
  constructor(public service:BrandDetailService, private toastr:ToastrService) { }

  ngOnInit(): void {
    this.service.refreshList();
    this.serach ='';
  }

  populateForm(selectedRecord:BrandDetail){
    this.service.formData =  Object.assign({}, selectedRecord);
  }

  onDelete(id:number){
    if (confirm('Are you sure to delete this record?'))
    {
      this.service.deleteBrandDetails(id)
      .subscribe(
       res=>{
         this.service.refreshList();
         this.service.formData = new BrandDetail();
         this.toastr.error("Deleted successfully", "Brand deleted")
       },
       err => {console.log(err)}
      )
    }
  }
}
