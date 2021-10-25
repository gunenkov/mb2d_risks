import { Component, Input, OnInit } from '@angular/core';
import { IncidentDto } from 'src/app/dto/incident-dto';
import { EventLogStatus } from 'src/app/enums/event-log-status';
import { IncidentResult } from 'src/app/enums/incident-result';
import { RiskStatus } from 'src/app/enums/risk-status';

@Component({
  selector: 'app-incident',
  templateUrl: './incident.component.html',
  styleUrls: ['./incident.component.styl']
})
export class IncidentComponent implements OnInit {
  @Input() data: IncidentDto;

  EventLogStatus = EventLogStatus;
  IncidentResult = IncidentResult;

  constructor() { }

  isRiskMarkInCorrect(): boolean {
    const currentStatus: RiskStatus = this.data.risk.currentStatus;
    const wantedStatus: RiskStatus = this.data.risk.wantedStatus;
    const incidentResult: IncidentResult = this.data.result;

    return (
      wantedStatus === RiskStatus.Managed && currentStatus === RiskStatus.Managed && incidentResult !== IncidentResult.Minimized && incidentResult !== IncidentResult.Escaped ||
      wantedStatus === RiskStatus.Free && currentStatus === RiskStatus.Free && incidentResult === IncidentResult.Escaped);
  }

  ngOnInit(): void {
  }

}
