import { IncidentResult } from "../enums/incident-result";
import { EventDto, EventInterface } from "./event-dto";
import { RiskDto, RiskInterface } from "./risk-dto";

export interface IncidentInterface {
  id: number;
  name: string;
  date: number;
  result: IncidentResult;
  ccorresponds: boolean;

  risk: RiskInterface;
  events: EventInterface[];
}

export class IncidentDto {
  id: number;
  name: string;
  date: number;
  result: IncidentResult;
  ccorresponds: boolean;

  risk: RiskDto;
  events: EventDto[];

  constructor(data: IncidentInterface) {
    this.id = data.id;
    this.name = data.name;
    this.date = data.date;
    this.result = data.result;
    this.ccorresponds = data.ccorresponds;

    if (data.risk) {
      this.risk = new RiskDto(data.risk);
    }
    
    if (data.events) {
      this.events = data.events.map(data => new EventDto(data));
    }
  }
}
