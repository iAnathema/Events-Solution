import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {EventDetails, EventHeader } from '../_models/lsnjEvent';


@Injectable({
  providedIn: 'root'
})
export class EventService {
    //Agular Service to consume API on Events EndPoints  
    constructor(private http: HttpClient) { }


    async GetAllEventsAsync(): Promise<EventHeader[]> {
        const response = await this.http.get<EventHeader[]>(`${environment.apiUrl}/event/`).toPromise();
        return response;
    }

    async GetEventByIdAsync(id: number): Promise<EventDetails> {
        const response = await this.http.get<EventDetails>(`${environment.apiUrl}/event/${id}`).toPromise();
        return response;
    }


    GetAllEvents(): Observable<EventHeader[]> {
        return this.http.get<EventHeader[]>(`${environment.apiUrl}/event`);
    }

    GetEventsPaged(pageNum: number, pageSize: number): Observable<EventHeader[]> {
        const httpOptions = {
            params: { pageNum: pageNum.toString(), pageSize: pageSize.toString() }
        };
        return this.http.get<EventHeader[]>(`${environment.apiUrl}/event`, httpOptions);
    }

    GetEventById(id: number): Observable<EventDetails> {
        return this.http.get<EventDetails>(`${environment.apiUrl}/event/${id}`);
    }

    InsertNewEvent(newEvent: EventDetails): Observable<void> {
        return this.http.post<void>(`${environment.apiUrl}/event`, newEvent);
    }

    
}
