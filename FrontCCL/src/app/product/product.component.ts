import { Component, inject } from '@angular/core';
import { ProductService } from '../_services/product.service';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Product } from '../interfaces/product';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table'



@Component({
  selector: 'app-product',
  imports: [MatCardModule,MatFormFieldModule,MatInputModule,MatButtonModule,ReactiveFormsModule,MatTableModule],
  templateUrl: './product.component.html',
  styleUrl: './product.component.css'
})
export class ProductComponent {
  private productoServicio = inject(ProductService)
     public listaProducto: Product[] = []
     public displayedColumns: string[] = ['name', 'cantidad'];
     private router = inject(Router);
     constructor() {
      this.productoServicio.list().subscribe({
           next: (data) => {
                console.log(data)
                     this.listaProducto = data;   
           },
           error: (err) => {
                console.log(err.message);
           }
      })
 }
 addProduct(){
     this.router.navigate(['addProduct'])
 }


}
