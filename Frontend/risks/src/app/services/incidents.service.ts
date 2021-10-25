import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, of } from "rxjs";
import { map } from "rxjs/operators";
import { API_BASE_URL } from "../app.config";
import { IncidentDto, IncidentInterface } from "../dto/incident-dto";

@Injectable({
  providedIn: 'root'
})
export class IncidentsService {

  constructor(private http$: HttpClient) {}

  getAll(): Observable<IncidentDto[]> {
    const response: IncidentInterface[] = [{"id":1,"name":"Hello333","riskId":1,"dateTime":"2021-10-25T16:52:40.2667794","ccorresponds":false,"result":2,"events":[{"id":1,"name":"Мероприятие 1","riskId":1,"durationInSeconds":30,"eventsLog":{"id":1,"start":"2021-10-25T16:52:41.3667814","finish":"2021-10-25T16:53:11.3671651","isExternalFactor":false,"status":0,"eventId":1,"riskId":1},"value":3}],"risk":{"id":1,"name":"Риск 1","operationId":1,"currentStatus":2,"wantedStatus":1,"incidents":[],"events":[{"id":1,"name":"Мероприятие 1","riskId":1,"durationInSeconds":30,"eventsLog":{"id":1,"start":"2021-10-25T16:52:41.3667814","finish":"2021-10-25T16:53:11.3671651","isExternalFactor":false,"status":0,"eventId":1,"riskId":1},"value":3}],"damage":3,"prob":2}}]

    return of(response)
      .pipe(map(incidents => incidents.map(data => new IncidentDto(data))));

    return this.http$.get<IncidentInterface[]>(API_BASE_URL + '/incidents/info')
      .pipe(map(incidents => incidents.map(data => new IncidentDto(data))));
  }
}
