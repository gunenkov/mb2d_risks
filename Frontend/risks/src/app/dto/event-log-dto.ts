import { EventLogStatus } from "../enums/event-log-status";

export interface EventLogInterface {
  id: number;
  start: string;
  finish: string;
  isExternalFactor: boolean;
  status: EventLogStatus;
  eventId: number;
  riskId: number;
}

export class EventLogDto {
  id: number;
  start: Date;
  finish: Date;
  isExternalFactor: boolean;
  status: EventLogStatus;
  eventId: number;
  riskId: number;

  constructor(data: EventLogInterface) {
    this.id = data.id;
    this.start = new Date(data.start);
    this.finish = new Date(data.finish);
    this.isExternalFactor = data.isExternalFactor;
    this.status = data.status;
    this.eventId = data.eventId;
    this.riskId = data.riskId;
  }
}
