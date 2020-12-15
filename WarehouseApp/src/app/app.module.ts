import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

import { AppComponent } from './app.component';
import { ProductDetailFormComponent } from './product-details/product-detail-form/product-detail-form.component';
import { HttpClientModule } from '@angular/common/http';
import { SortDirective } from './diretive/sort.directive';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { CategoryDetailFormComponent } from './category-details/category-detail-form/category-detail-form.component';
import { AppRoutingModule, routingComponents } from './app-routing.module';

@NgModule({
  declarations: [
    AppComponent,
    ProductDetailFormComponent,
    CategoryDetailFormComponent,
    SortDirective,
    routingComponents
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    Ng2SearchPipeModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
