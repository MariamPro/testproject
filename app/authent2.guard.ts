import { CanActivateFn } from '@angular/router';
import { AuthService } from './services/auth.service';
import { inject } from '@angular/core';


export const authent2Guard: CanActivateFn = (route, state) => {
  return inject(AuthService).isLogin();
};
