    import { Component, EventEmitter, Output } from '@angular/core';
    import { FormsModule } from '@angular/forms';
    import { AccountService } from '../_services/account';
    import { ToastrService } from 'ngx-toastr';
    import { CommonModule } from '@angular/common';
    
    @Component({
      selector: 'app-register',
      standalone: true,
      imports: [FormsModule, CommonModule],
      templateUrl: './register.html',
      styleUrl: './register.css'
    })
    export class RegisterComponent {
      // This allows the component to emit an event to a parent component
      @Output() cancelRegister = new EventEmitter();
      model: any = {}
    
      constructor(private accountService: AccountService, private toastr: ToastrService) { }
    
      register() {
        this.accountService.register(this.model).subscribe({
          next: () => {
            this.toastr.success('Registration successful!');
            this.cancel();
          },
          error: error => this.toastr.error(error.error)
        })
      }
    
      cancel() {
        this.cancelRegister.emit(false);
      }
    }
    
