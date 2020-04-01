import { Injectable } from "@angular/core";
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpResponse, HttpErrorResponse } from "@angular/common/http";
import { Observable } from "rxjs";
import { finalize, tap } from "rxjs/operators";
import { LoaderService } from '../_services/loader.service';
import { AlertService } from '../_services/alert.service';
@Injectable()
export class LoaderInterceptor implements HttpInterceptor {
    constructor(public loaderService: LoaderService, private alertService: AlertService) { }


    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        this.loaderService.show();
        return next.handle(req).pipe(
            tap(
                event => {                   
                    if (event instanceof HttpResponse) {                                                
                        this.loaderService.hide()
                    }
                },
                error => {
                    if (error instanceof HttpErrorResponse) {
                        this.loaderService.hide();
                        this.alertService.error(error.message, error.statusText);
                        console.log(error)
                    }
                }
            ),
            finalize(() => {

            })
        );
        //return next.handle(req).pipe(finalize(() => this.loaderService.hide()));
        
    }
}
