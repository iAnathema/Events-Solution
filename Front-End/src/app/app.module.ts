import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { LoaderComponent } from './+loader/loader.component';
import { LoaderService } from './_services/loader.service';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { LoaderInterceptor } from './_interceptor/loader.interceptor';
import { HttpClientModule } from '@angular/common/http';
import { AlertComponent } from './+alert/alert.component';
import { JwtInterceptor } from './_services/jwt.interceptor';
import { AuthModule } from './_authentication/auth.module';
import { LoginComponent } from './_authentication/login/login.component';
import { AuthCallbackComponent } from './_authentication/auth-callback/auth-callback.component';
import { PagesModule } from './+pages/pages.module';
import { MatMenuModule, MatIconModule, MatToolbarModule, MatProgressSpinnerModule, MatButtonModule } from '@angular/material';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CommonModule } from '@angular/common';

@NgModule({
  declarations: [
    LoginComponent,
    AuthCallbackComponent,
    AppComponent,  
    AlertComponent,
    LoaderComponent
  ],
  imports: [    
      AppRoutingModule,
      BrowserModule,
      BrowserAnimationsModule,
      AuthModule,
      PagesModule,
      HttpClientModule,  
      MatMenuModule,
      MatIconModule,
      MatToolbarModule,
      MatProgressSpinnerModule,
      MatButtonModule,
      CommonModule
    ],
    providers: [    
        LoaderService,                   
        { provide: HTTP_INTERCEPTORS, useClass: LoaderInterceptor, multi: true },
        { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    ],

    bootstrap: [AppComponent]
})
export class AppModule { }
