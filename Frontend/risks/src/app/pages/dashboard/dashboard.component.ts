import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { IncidentDto } from 'src/app/dto/incident-dto';
import { IncidentResult } from 'src/app/enums/incident-result';
import { IncidentsService } from 'src/app/services/incidents.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.styl']
})
export class DashboardComponent implements OnInit {
  public businessServices: any[] = [];
  public operationServices: any[] = [];
  public operationServicesFiltered: any[] = [];
  public risks: any[] = [];
  public risksFiltered: any[] = [];
  public activeIncidents: IncidentDto[] = [];
  public otherIncidents: IncidentDto[] = [];

  public riskForm: FormGroup;
  public eventForm: FormGroup;
  public incidentForm: FormGroup;

  constructor(private svc$: IncidentsService) { }

  openModal(event: Event, id: string): void {
    event.preventDefault();
    globalThis.$(id).modal('show');
  }

  closeModal(event: Event, id: string): void {
    if (event) {
      event.preventDefault();
    }

    globalThis.$(id).modal('hide');
  }

  filterOperationServices(bs: number): void {
    this.operationServicesFiltered = this.operationServices.filter(item => item.businessServiceId == bs);
  }
  
  filterRisks(operationId: number): void {
    this.risksFiltered = this.risks.filter(item => item.operationId == operationId);
  }

  initForms(): void {
    this.riskForm = new FormGroup({
      name: new FormControl('', Validators.required),
      bs: new FormControl('', Validators.required),
      operationId: new FormControl('', Validators.required),
      damage: new FormControl('', Validators.required),
      prob: new FormControl('', Validators.required),
      currentStatus: new FormControl('', Validators.required),
      wantedStatus: new FormControl('', Validators.required)
    });
    
    this.eventForm = new FormGroup({
      name: new FormControl('', Validators.required),
      bs: new FormControl('', Validators.required),
      operationId: new FormControl('', Validators.required),
      riskId: new FormControl('', Validators.required),
      durationInSeconds: new FormControl('', Validators.required),
      value: new FormControl('', Validators.required)
    });
    
    this.incidentForm = new FormGroup({
      incidentName: new FormControl('', Validators.required),
      bs: new FormControl('', Validators.required),
      operationId: new FormControl('', Validators.required),
      riskId: new FormControl('', Validators.required)
    });
  }

  addRisk(): void {
    const data = this.riskForm.value;
    delete data.bs;

    this.svc$.addRisk(data).subscribe(() => {
      this.closeModal(null, '#riskModal');
      this.riskForm.reset();
    });
  }
  
  addEvent(): void {
    console.log(this.eventForm.value);
    const data = this.eventForm.value;
    delete data.bs;

    this.svc$.addEvent(data).subscribe(() => {
      this.closeModal(null, '#eventModal');
      this.eventForm.reset();
    });
  }
  
  addIncident(): void {
    const data = this.incidentForm.value;
    data.riskName = this.risks.find(item => item.id == data.riskId).name;
    delete data.riskId;
    delete data.bs;
    delete data.operationId;

    this.svc$.addIncident(data).subscribe(() => {
      this.closeModal(null, '#incidentModal');
      this.incidentForm.reset();
    });
  }

  getData(): void {
    this.svc$.getAll().subscribe(incidents => {
      this.activeIncidents = [];
      this.otherIncidents = [];

      for (let incident of incidents.reverse()) {
        if (incident.result === IncidentResult.Undefined) {
          this.activeIncidents.push(incident);
        } else {
          this.otherIncidents.push(incident);
        }
      }
    });

    this.svc$.getBusinessServices().subscribe(businessServices => {
      this.businessServices = businessServices;
    });
    
    this.svc$.getOperationServices().subscribe(operationServices => {
      this.operationServices = operationServices;
    });
    
    this.svc$.getRisks().subscribe(risks => {
      this.risks = risks;
    });
  }

  ngOnInit(): void {
    this.getData();
    this.initForms();
  }

}
