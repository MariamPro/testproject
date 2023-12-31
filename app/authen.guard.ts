import { CanActivateFn } from '@angular/router';

export const authenGuard: CanActivateFn = (route, state) => {
  return true;
};
