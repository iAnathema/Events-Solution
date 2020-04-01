import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EventService } from '../../_services/event.service';
import { first } from 'rxjs/operators';
import { EventDetails } from '../../_models/lsnjEvent';

@Component({
  selector: 'app-event-details',
  templateUrl: './event-details.component.html',
  styleUrls: ['./event-details.component.css']
})
export class EventDetailsComponent implements OnInit {

    eventId: number;
    eventDetails: EventDetails;


    constructor(private route: ActivatedRoute, private _eventService: EventService) {
        //Get id from route request
        this.route.params.subscribe(params =>
            this.eventId = params['id']
        );
    }

    ngOnInit() {       
        //Call GetEventById by EventService
        this._eventService.GetEventById(this.eventId).pipe(first()).subscribe(result => {
            this.eventDetails = result;            
        });
    }

}
