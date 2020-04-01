import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { EventDetails } from '../../_models/lsnjEvent';
import { EventService } from '../../_services/event.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-event-new',
  templateUrl: './event-new.component.html',
  styleUrls: ['./event-new.component.css']
})
export class EventNewComponent implements OnInit {

    newEventForm: FormGroup

    constructor(private formBuilder: FormBuilder, private router: Router, private _eventService: EventService) {
        this.newEventForm = this.formBuilder.group({
            eventTitle: '',  
            eventDescription: '',
            eventNote: '',
            eventDate: new Date()
        });
    }

    onSubmit(eventData: any) {
       
        const event: EventDetails = {
            date : eventData.eventDate,
            title: eventData.eventTitle,
            description: eventData.eventDescription,
            note: eventData.eventNote
        }
        
        this._eventService.InsertNewEvent(event).subscribe(
            res => { this.router.navigateByUrl('/event-list'); },
            err => { console.log(err); }
        )

    }

  ngOnInit() {
  }

}
