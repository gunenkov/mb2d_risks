import { Component, OnInit } from '@angular/core';
import { IncidentDto } from 'src/app/dto/incident-dto';
import { IncidentResult } from 'src/app/enums/incident-result';
import { IncidentsService } from 'src/app/services/incidents.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.styl']
})
export class DashboardComponent implements OnInit {
  public activeIncidents: IncidentDto[] = [];
  public otherIncidents: IncidentDto[] = [];

  constructor(private svc$: IncidentsService) { }

  getData(): void {
    this.svc$.getAll().subscribe(incidents => {
      this.activeIncidents = this.otherIncidents = [];

      for (let incident of incidents.reverse()) {
        if (incident.result === IncidentResult.Undefined) {
          this.activeIncidents.push(incident);
        } else {
          this.otherIncidents.push(incident);
        }
      }

      console.log(this.activeIncidents, this.otherIncidents);
    });
  }

  ngOnInit(): void {
    this.getData();
  }

}
