import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class TicketService {
  baseUrl = 'https://localhost:7236/api/';

  constructor(private http: HttpClient) { }

  getTickets() {
    return this.http.get(this.baseUrl + 'tickets');
  }

  // New method to create a ticket
  createTicket(model: any) {
    return this.http.post(this.baseUrl + 'tickets', model);
  }
}

