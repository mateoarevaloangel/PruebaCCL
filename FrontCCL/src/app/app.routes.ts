import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { ProductComponent } from './product/product.component';
import { AddProductComponent } from './add-product/add-product.component';
import { authGuard } from './custom/auth.guard';

export const routes: Routes = [
    {path:"", component:LoginComponent},
    {path:"product", component:ProductComponent},
    {path:"addProduct", component:AddProductComponent,canActivate:[authGuard]}
];
