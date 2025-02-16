import { Component, inject } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Login } from '../interfaces/login';
import { User } from '../interfaces/user';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';



@Component({
  selector: 'app-product',
  imports: [MatCardModule,MatFormFieldModule,MatInputModule,MatButtonModule,ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  private loginService = inject(AuthService);
  private router = inject(Router);
  public formBuild = inject(FormBuilder);

  public formLogin: FormGroup = this.formBuild.group({
    correo: ['',Validators.required],
    clave: ['',Validators.required]
})

iniciarSesion(){
  if(this.formLogin.invalid) return;

  const objeto:User = {
       UserName: this.formLogin.value.correo,
       Password: this.formLogin.value.clave
  }

  this.loginService.login(objeto).subscribe({
     next:(data) =>{
          console.log(data.respuesta)
          if(data.respuesta){
               localStorage.setItem("token",data.token)
               this.router.navigate(['product'])
          }else{
               console.log(data)
               alert("Credenciales son incorrectas")
          }
     },
     error:(error) =>{
          console.log(error.message);
     }
  })
}

}
