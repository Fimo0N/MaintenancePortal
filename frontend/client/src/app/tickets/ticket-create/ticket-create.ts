import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { TicketService } from '../../_services/ticket';
import { AssetService } from '../../_services/asset';
import { AccountService } from '../../_services/account';
import { take } from 'rxjs';
import { User } from '../../_models/user';

@Component({
  selector: 'app-ticket-create',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './ticket-create.html',
  styleUrl: './ticket-create.css'
})
export class TicketCreateComponent implements OnInit {
  @Output() cancelCreate = new EventEmitter();
  model: any = {};
  assets: any[] = [];
  user: User | null = null;

  constructor(
    private ticketService: TicketService, 
    private assetService: AssetService,
    private accountService: AccountService,
    private toastr: ToastrService) {
      this.accountService.currentUser$.pipe(take(1)).subscribe({
        next: user => this.user = user
      });
    }

  ngOnInit(): void {
    this.loadAssets();
  }

  loadAssets() {
    this.assetService.getAssets().subscribe({
      next: assets => this.assets = assets as any[] // This tells TypeScript to trust us that 'assets' is an array
    })
  }

  createTicket() {
    if (!this.user) return; // safety check

    const ticketToCreate = {
      title: this.model.title,
      description: this.model.description,
      priority: this.model.priority,
      assetId: parseInt(this.model.assetId),
      reportedByUserId: this.user.id // Using the REAL logged-in user's ID
    };

    this.ticketService.createTicket(ticketToCreate).subscribe({
      next: () => {
        this.toastr.success('Ticket created successfully!');
        this.cancel();
      },
      error: error => this.toastr.error(error.error)
    })
  }

  cancel() {
    this.cancelCreate.emit(false);
  }

}

