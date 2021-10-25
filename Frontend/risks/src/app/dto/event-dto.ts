import { EventLogDto, EventLogInterface } from "./event-log-dto";

export interface EventInterface {
  id: number;
  name: string;
  riskId: number;
  durationInSeconds: number;
  value: number;
  eventsLog: EventLogInterface;
}

export class EventDto {
  id: number;
  name: string;
  riskId: number;
  durationInSeconds: number;
  value: number;
  eventsLog: EventLogDto;

  constructor(data: EventInterface) {
    this.id = data.id;
    this.name = data.name;
    this.riskId = data.riskId;
    this.durationInSeconds = data.durationInSeconds;
    this.value = data.value;
    this.eventsLog = new EventLogDto(data.eventsLog);
  }
}
