import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { PagesComponent } from './pages.component';
import { EventListComponent } from './+event-list/event-list.component';
import { EventNewComponent } from './+event-new/event-new.component';
import { EventDetailsComponent } from './+event-details/event-details.component';


const routes: Routes = [{
  path: 'pages',
  component: PagesComponent,
  children: [    
    {
      path: 'event-list',
      component: EventListComponent            
    },
    {
      path: 'event-new',
      component: EventNewComponent            
    },
    {
      path: 'event-details/:id',
      component: EventDetailsComponent            
    },
    {
      path: '',
      redirectTo: 'event-list',
      pathMatch: 'full',
    }    
  ],
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PagesRoutingModule {
}
