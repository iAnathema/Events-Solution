import { Component, OnInit } from '@angular/core';
import { EventService } from '../../_services/event.service';
import { first } from 'rxjs/operators';
import { EventHeader } from '../../_models/lsnjEvent';
import { PageEvent } from '@angular/material';

@Component({
  selector: 'app-event-list',
  templateUrl: './event-list.component.html',
  styleUrls: ['./event-list.component.css']
})
export class EventListComponent implements OnInit {

    allEvents: EventHeader[];


    length: number;
    pageCurrent = 1;
    pageSize = 10;
    pageSizeOptions: number[] = [1, 5, 10, 25, 100];

    // MatPaginator Output
    


    constructor(private _eventService: EventService) {  }

    ngOnInit() {
        this.allEvents = [];
        //Call GetAllEvents by EventService
        this._eventService.GetAllEvents().pipe(first()).subscribe(result => {
            this.allEvents = result;
            this.length = result.length;
        });

    }

    setPageSizeOptions(setPageSizeOptionsInput: string) {
        this.pageSizeOptions = setPageSizeOptionsInput.split(',').map(str => +str);
    }

    pagingLazy(pageEvent: PageEvent) {
        this._eventService.GetEventsPaged(pageEvent.pageIndex +1, pageEvent.pageSize).pipe(first()).subscribe(result => {
            this.allEvents = result;           
        });
    }

    pagingNGX(pageEvent: PageEvent) {
        this.pageCurrent = pageEvent.pageIndex + 1;
        this.pageSize = pageEvent.pageSize;
    }

}
