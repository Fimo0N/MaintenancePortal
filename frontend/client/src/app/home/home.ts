    import { Component } from '@angular/core';
    import { RegisterComponent } from '../register/register';
    import { CommonModule } from '@angular/common';
    
    @Component({
      selector: 'app-home',
      standalone: true,
      imports: [RegisterComponent, CommonModule],
      templateUrl: './home.html',
      styleUrl: './home.css'
    })
    export class HomeComponent {
      registerMode = false;
    
      constructor() {}
    
      registerToggle() {
        this.registerMode = !this.registerMode;
      }
    
      cancelRegisterMode(event: boolean) {
        this.registerMode = event;
      }
    }
    

