import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TicketService } from '../../_services/ticket';
import { TicketCreateComponent } from '../ticket-create/ticket-create';

@Component({
  selector: 'app-ticket-list',
  standalone: true,
  imports: [CommonModule, TicketCreateComponent],
  templateUrl: './ticket-list.html',
  styleUrls: ['./ticket-list.css']
})
export class TicketListComponent implements OnInit {
  tickets: any;
  showCreateForm = false;

  constructor(private ticketService: TicketService) {}

  ngOnInit(): void {
    this.loadTickets();
  }

  loadTickets() {
    this.ticketService.getTickets().subscribe({
      next: tickets => this.tickets = tickets
    });
  }

  toggleCreateForm() {
    this.showCreateForm = !this.showCreateForm;
  }
}

