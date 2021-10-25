import { IncidentResult } from "../enums/incident-result";
import { EventDto, EventInterface } from "./event-dto";
import { RiskDto, RiskInterface } from "./risk-dto";

export interface IncidentInterface {
  id: number;
  name: string;
  dateTime: string;
  result: IncidentResult;
  ccorresponds: boolean;
  riskId: number;

  risk: RiskInterface;
  events: EventInterface[];
}

export class IncidentDto {
  id: number;
  name: string;
  dateTime: Date;
  result: IncidentResult;
  ccorresponds: boolean;

  risk: RiskDto;
  events: EventDto[];

  constructor(data: IncidentInterface) {
    this.id = data.id;
    this.name = data.name;
    this.dateTime = new Date(data.dateTime);
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
