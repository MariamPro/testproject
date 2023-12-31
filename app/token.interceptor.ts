import { HttpInterceptorFn } from '@angular/common/http';
import { AuthService } from './services/auth.service';
import { inject } from '@angular/core';

export const tokenInterceptor: HttpInterceptorFn = (req, next) => {
  const myToken =  inject(AuthService).getToken
  const toke = localStorage.getItem('token');
  console.log(myToken)
    req = req.clone({
      headers : req.headers.set('Authorization' , 'Bearer '+toke)
    })

  return next(req);
};
