import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { AlertService } from '../_services/alert.service';
import { MatSnackBar } from '@angular/material';

@Component({
  selector: 'app-alert',
  templateUrl: './alert.component.html',
  styleUrls: ['./alert.component.css']
})
export class AlertComponent implements OnInit, OnDestroy {

    private subscription: Subscription;   

    message: any;    

    constructor(private alertService: AlertService, private _snackBar: MatSnackBar) { }

    ngOnInit() {
        this.subscription = this.alertService.getMessage().subscribe(message => {            
            if(message != undefined)
            this._snackBar.open(message.text, message.subject, {
                duration: 5000
            });
        });
    }

    ngOnDestroy() {
        if (this.subscription && this.subscription instanceof Subscription) {
            this.subscription.unsubscribe();
        }
    }

}
