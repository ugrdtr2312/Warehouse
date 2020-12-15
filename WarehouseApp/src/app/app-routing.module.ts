import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router'
import { ProductDetailsComponent } from './product-details/product-details.component';
import { CategoryDetailsComponent } from './category-details/category-details.component';

const routes: Routes = [
    { path:'categories', component: CategoryDetailsComponent},
    { path:'products', component: ProductDetailsComponent}
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutingModule { }
export const routingComponents = [CategoryDetailsComponent, ProductDetailsComponent]