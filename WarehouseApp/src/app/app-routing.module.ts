import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router'
import { ProductDetailsComponent } from './product-details/product-details.component';
import { CategoryDetailsComponent } from './category-details/category-details.component';
import { SupplierDetailsComponent } from './supplier-details/supplier-details.component';
import { BrandDetailsComponent } from './brand-details/brand-details.component';

const routes: Routes = [
    { path:'categories', component: CategoryDetailsComponent},
    { path:'products', component: ProductDetailsComponent},
    { path:'brands', component: BrandDetailsComponent},
    { path:'suppliers', component: SupplierDetailsComponent}
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutingModule { }
export const routingComponents = [CategoryDetailsComponent, ProductDetailsComponent, BrandDetailsComponent, SupplierDetailsComponent]