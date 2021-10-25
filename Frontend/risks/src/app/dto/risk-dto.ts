import { RiskStatus } from "../enums/risk-status";
import { EventDto, EventInterface } from "./event-dto";

export interface RiskInterface {
  id: number;
  name: string;
  operationId: number;
  currentStatus: RiskStatus;
  wantedStatus: RiskStatus;
  damage: number;
  prob: number;
  events: EventInterface[];
  incidents: any[];
  operation: any;
}

export class RiskDto {
  id: number;
  name: string;
  operationId: number;
  currentStatus: RiskStatus;
  wantedStatus: RiskStatus;
  damage: number;
  prob: number;
  value: number;
  events: EventDto[];
  operation: any;

  constructor(data: RiskInterface) {
    this.id = data.id;
    this.name = data.name;
    this.operationId = data.operationId;
    this.currentStatus = data.currentStatus;
    this.wantedStatus = data.wantedStatus;
    this.damage = data.damage;
    this.prob = data.prob;
    this.value = data.damage * data.prob;
    this.operation = data.operation;

    if (data.events) {
      this.events = data.events.map(data => new EventDto(data));
    }
  }
}
