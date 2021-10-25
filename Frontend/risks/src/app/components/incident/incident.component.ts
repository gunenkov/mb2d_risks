import { Component, Input, OnInit } from '@angular/core';
import { IncidentDto } from 'src/app/dto/incident-dto';

@Component({
  selector: 'app-incident',
  templateUrl: './incident.component.html',
  styleUrls: ['./incident.component.styl']
})
export class IncidentComponent implements OnInit {
  @Input() data: IncidentDto;

  constructor() { }

  ngOnInit(): void {
    console.log(this.data);
  }

}
