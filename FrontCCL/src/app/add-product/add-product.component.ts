import { Component, inject } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Product } from '../interfaces/product';
import { SendProduct } from '../interfaces/send-product';
import { ProductService } from '../_services/product.service';

@Component({
  selector: 'app-add-product',
  imports: [MatCardModule,MatFormFieldModule,MatInputModule,MatButtonModule,ReactiveFormsModule],
  templateUrl: './add-product.component.html',
  styleUrl: './add-product.component.css'
})
export class AddProductComponent {
    private productService = inject(ProductService);
    private router = inject(Router);
    public formBuild = inject(FormBuilder);
  
    public formProduct = this.formBuild.group({
      name: ['',Validators.required],
      cantidad: ['',Validators.required]
  })

  guardar(){
    const objeto:SendProduct = {
      name: this.formProduct.value.name!,
      cantidad: parseInt(this.formProduct.value.cantidad!)
 }
 
    this.productService.addProdut(objeto).subscribe({
      next:(data) =>{
           console.log(data)
           this.router.navigate(['product'])
      },
      error:(error) =>{
           console.log(error.message);
           alert(error.message)
      }
   })
  }
  cancelar(){
    this.router.navigate(['product'])
  }

}
