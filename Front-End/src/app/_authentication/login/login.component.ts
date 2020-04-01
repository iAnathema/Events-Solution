import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
})
export class LoginComponent implements OnInit { 

  constructor(private router: Router, private authService: AuthService) { }    
    ngOnInit() {   
      console.log(this.authService.isAuthenticated());
      if(this.authService.isAuthenticated())
        this.router.navigate(['/pages']);
      else      
      {
        setTimeout (() => {
          this.authService.login();
       }, 1000);
      }   
        
    }
}


 