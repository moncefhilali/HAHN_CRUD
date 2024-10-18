export interface PaginatedTickets {
  totalCount: number;
  pageSize: number;
  pageNumber: number;
  totalPages: number;
  tickets?: Ticket[];
}

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
