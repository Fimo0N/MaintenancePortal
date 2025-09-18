import { Routes } from '@angular/router';
import { HomeComponent } from './home/home';
import { TicketListComponent } from './tickets/ticket-list/ticket-list';
import { authGuard } from './_guards/auth-guard';

export const routes: Routes = [
    { path: '', component: HomeComponent },
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [authGuard],
        children: [
            { path: 'tickets', component: TicketListComponent },
        ]
    },
    { path: '**', component: HomeComponent, pathMatch: 'full' }
];

