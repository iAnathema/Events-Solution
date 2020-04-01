import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthService } from '../_authentication/auth.service';



@Injectable()
export class JwtInterceptor implements HttpInterceptor {
    constructor(private authService: AuthService) {}

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        // add authorization header with jwt token if available            
        if (this.authService.isAuthenticated()) {
            let header = this.authService.authorizationHeader;
            request = request.clone({
                setHeaders: { 
                    Authorization: `${header.TokenType} ${header.Token}`
                }
            });
        }
        return next.handle(request);
    }
}