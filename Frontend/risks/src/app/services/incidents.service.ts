import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { API_BASE_URL } from "../app.config";
import { IncidentDto, IncidentInterface } from "../dto/incident-dto";

@Injectable({
  providedIn: 'root'
})
export class IncidentsService {

  constructor(private http$: HttpClient) {}

  getAll(): Observable<IncidentDto[]> {
    return this.http$.get<IncidentInterface[]>(API_BASE_URL + '/incidents/info')
      .pipe(map(incidents => incidents.map(data => new IncidentDto(data))));
  }
}
