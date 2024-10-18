export interface Ticket {
  ticketId: number;
  description: string;
  status: TicketStatus;
  date: string;
}

export enum TicketStatus {
  Closed,
  Open,
}
