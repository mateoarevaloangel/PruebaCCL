import { CanActivateFn, Router } from '@angular/router';
import { inject } from '@angular/core';
//import { AccesoService } from '../services/acceso.service';
import { catchError, map, of } from 'rxjs';


export const authGuard: CanActivateFn = (route, state) => {
  
  const token = localStorage.getItem("token") || "";
  const router = inject(Router);
  if(token!=""){
    return true;
  }else{
    router.navigate([''])
  }
return true;
};
