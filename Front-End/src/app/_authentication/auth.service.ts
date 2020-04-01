import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserManager, UserManagerSettings, User } from 'oidc-client';
import { BehaviorSubject } from 'rxjs'; 
import { BaseService } from '../base.service';
import { IdentityServerEnv } from 'src/environments/environment';



@Injectable({
  providedIn: 'root'
})
export class AuthService extends BaseService  {

  // Observable navItem source
  private _authNavStatusSource = new BehaviorSubject<boolean>(false);
  // Observable navItem stream
  authNavStatus$ = this._authNavStatusSource.asObservable();

  private manager = new UserManager(getClientSettings());
  private user: User | null;

  constructor(private http: HttpClient) { 
    super();     
    
    this.manager.getUser().then(user => { 
      this.user = user;            
      console.log(this.user);
      this._authNavStatusSource.next(this.isAuthenticated());
    });
  }

  login() { 
    return this.manager.signinRedirect();   
  }

  async completeAuthentication() {   
      this.user = await this.manager.signinRedirectCallback();        
      this._authNavStatusSource.next(this.isAuthenticated());      
  }  

  get authorityUrl()
  {
    return this.manager.settings.authority;
  }

  isAuthenticated(): boolean {    
    return this.user != null && !this.user.expired;
  }

  get authorizationHeaderValue(): string {
    return `${this.user.token_type} ${this.user.access_token}`;
  }

  get authorizationHeader(): AuthHeader {

     const header : AuthHeader = {
      TokenType : this.user.token_type,
      Token : this.user.access_token
    }
    return header;
  }

  get name(): string {
    return this.user != null ? this.user.profile.name : '';
  }

  get profile(): any {
    return this.user != null ? this.user.profile : { };
  }

  async signout() {
    await this.manager.signoutRedirect();
  }
}

export interface AuthHeader 
{
    TokenType : string;
    Token : string;
}

export function getClientSettings(): UserManagerSettings {
  return IdentityServerEnv;
}

