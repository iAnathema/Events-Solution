import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable()

export class LoaderService {
    //Spinner Show/Hide on Interceptor HTTP Calls
    isLoading = new Subject<boolean>();

    show() {
        setTimeout(() => this.isLoading.next(true), 500);
        
    }

    hide() {
        setTimeout(() => this.isLoading.next(false), 500);
    }
}