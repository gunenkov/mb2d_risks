export interface EventInterface {
  id: number;
  name: string;
  riskId: number;
  durationInSeconds: number;
  value: number;
  eventsLog: any[];
}

export class EventDto {
  id: number;
  name: string;
  riskId: number;
  durationInSeconds: number;
  value: number;
  eventsLog: any[];

  constructor(data: EventInterface) {
    this.id = data.id;
    this.name = data.name;
    this.riskId = data.riskId;
    this.durationInSeconds = data.durationInSeconds;
    this.value = data.value;
    this.eventsLog = data.eventsLog;
  }
}
