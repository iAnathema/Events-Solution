import { NgModule } from '@angular/core';
import { Routes, RouterModule, ExtraOptions } from '@angular/router';
import { AuthGuard } from './_authentication/auth.guard';
import { LoginComponent } from './_authentication/login/login.component';
import { AuthCallbackComponent } from './_authentication/auth-callback/auth-callback.component';
import { PagesComponent } from './+pages/pages.component';

//const routes: Routes = [
//    { path: 'auth-callback', component: AuthCallbackComponent  },
//    { path: 'event-list', component: EventListComponent },
//    { path: 'event-new', component: EventNewComponent },
//    { path: 'event-details/:id', component: EventDetailsComponent },
//    { path: 'login', component: LoginComponent }
//];

const routes: Routes = [
  { path: 'auth-callback', component: AuthCallbackComponent  },
  {
    path: 'pages',
    component : PagesComponent,
      canActivate: [AuthGuard]      
  },
  {
    path: 'login',
    component: LoginComponent,
  },
  //{
  //  path: 'auth',    
  //  children: [
  //    {
  //      path: '',
  //      component: LoginComponent,
  //    },
  //    {
  //      path: 'login',
  //      component: LoginComponent,
  //    },      
  //  ],
  //},
  { path: '', redirectTo: 'pages', pathMatch: 'full' },
  //{ path: '**', redirectTo: 'pages' },
];

const config: ExtraOptions = {
  useHash: false,
};

@NgModule({
  imports: [RouterModule.forRoot(routes, config)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
