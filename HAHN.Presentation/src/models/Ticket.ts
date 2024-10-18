export interface Ticket {
  ticketId: number;
  description: string;
  status: TicketStatus;
  date: Date;
}

export enum TicketStatus {
  Closed,
  Open,
}
