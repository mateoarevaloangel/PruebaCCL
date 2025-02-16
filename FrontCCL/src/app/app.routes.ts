import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { ProductComponent } from './product/product.component';
import { AddProductComponent } from './add-product/add-product.component';

export const routes: Routes = [
    {path:"login", component:LoginComponent},
    {path:"product", component:ProductComponent},
    {path:"addProduct", component:AddProductComponent}
];
