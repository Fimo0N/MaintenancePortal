import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../_services/account';
import { Router, RouterModule } from '@angular/router'; // Import RouterModule
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-nav',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule], // Add RouterModule here
  templateUrl: './nav.html',
  styleUrls: ['./nav.css']
})
export class NavComponent {
  model: any = {};

  constructor(public accountService: AccountService, private router: Router, private toastr: ToastrService) {}

  login() {
    this.accountService.login(this.model).subscribe({
      next: () => {
        this.router.navigateByUrl('/tickets');
      },
      error: error => {
        this.toastr.error(error.error);
      }
    });
  }

  logout() {
    this.accountService.logout();
    this.router.navigateByUrl('/');
  }
}

