import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { NavComponent } from "./nav/nav";
import { AccountService } from './_services/account';

@Component({
    selector: 'app-root',
    standalone: true,
    templateUrl: './app.html',
    styleUrls: ['./app.css'],
    imports: [CommonModule, RouterOutlet, NavComponent]
})
export class AppComponent implements OnInit {
  title = 'client';

  constructor(private accountService: AccountService) {}

  // This function runs automatically when the component is initialized
  ngOnInit(): void {
    this.setCurrentUser();
  }

  // This logic checks the browser's storage for a user
  setCurrentUser() {
    const userString = localStorage.getItem('user');
    if (!userString) return;
    const user = JSON.parse(userString);
    this.accountService.setCurrentUser(user);
  }
}

