import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AccountService } from '../_services/account';
import { map } from 'rxjs';

export const authGuard: CanActivateFn = (route, state) => {
  const accountService = inject(AccountService);
  const router = inject(Router);

  return accountService.currentUser$.pipe(
    map(user => {
      if (user) {
        // If the user is logged in, allow access
        return true;
      } else {
        // If the user is not logged in, redirect to the home page
        console.error("Only Logged in User Can see the Tickets"); // For debugging
        router.navigateByUrl('/');
        return false;
      }
    })
  );
};

