import { CanActivateFn, Router } from '@angular/router';
import { inject } from '@angular/core';
import { LoginService } from '../login/service/login.service';

export const authGuard: CanActivateFn = (route, state) => {
  const authService = inject(LoginService);
  const router = inject(Router);
  if (authService.isAuthenticated())
    return true;
  router.navigate(["/login"]);
  return false;
};
