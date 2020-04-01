import { Component } from '@angular/core';
import { Router } from '@angular/router';



@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
    title = 'LSNJ Events Portal';
    loading = false;

    constructor(private router : Router) {
        this.navigateEventList();
    }

    navigateEventList() {
        this.router.navigateByUrl('/pages/event-list');
    }

}
