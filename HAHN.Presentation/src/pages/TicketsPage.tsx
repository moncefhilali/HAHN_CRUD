import {
  Button,
  Card,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
} from "@mui/material";
import axios from "axios";
import { useEffect, useState } from "react";
import { Ticket } from "../models/Ticket";
import { format } from "date-fns";
import { confirmAlert } from "react-confirm-alert";
import "react-confirm-alert/src/react-confirm-alert.css";
import { toast } from "react-toastify";
import UpdateTicket from "../components/UpdateTicket";
import AddTicket from "../components/AddTicket";

export default function TicketsPage() {
  const [tickets, setTickets] = useState<Ticket[]>([]);
  const [isUpdating, setIsUpdating] = useState(false);
  const [isAdding, setIsAdding] = useState(false);
  const [currentTicket, setCurrentTicket] = useState<Ticket>();

  useEffect(() => {
    axios.get("https://localhost:7127/api/Tickets").then((response) => {
      setTickets(response.data);
    });
  }, []);

  const headCellsTheme = {
    color: "white",
    fontWeight: 600,
    border: "solid #e4e4e4 2px",
    borderRadius: 0,
    padding: "10px 10px",
  };

  const cellsTheme = {
    fontWeight: 600,
    border: "solid #e4e4e4 2px",
    borderRadius: 0,
    padding: "10px 10px",
  };

  const tableTheme = {
    borderRadius: 0,
    width: "90%",
    boxShadow: 0,
    marginLeft: "auto",
    marginRight: "auto",
  };

  const buttonTheme = {
    backgroundColor: "#02a459",
    fontSize: "12px",
    textTransform: "capitalize",
    padding: "10px 20px",
  };

  const deleteTicket = async (index: number) => {
    await axios
      .delete(`https://localhost:7127/api/Tickets/${tickets[index].ticketId}`)
      .then((response) => {
        if (response.status === 200) {
          const updatedTickets = [...tickets];
          updatedTickets.splice(index, 1);
          setTickets(updatedTickets);
          toast.success("Ticket deleted successfully!");
        } else {
          toast.error(`Error deleting Ticket #${tickets[index].ticketId}`);
        }
      });
  };

  const handleDelete = async (e: any, index: number) => {
    e.preventDefault();
    confirmAlert({
      title: `Ticket #${tickets[index].ticketId}`,
      message: "Are you sure you want to permanently delete the ticket?",
      buttons: [
        {
          label: "Yes",
          onClick: () => deleteTicket(index),
        },
        {
          label: "No",
        },
      ],
    });
  };

  const handleUpdate = (e: any, index: number) => {
    e.preventDefault();
    setCurrentTicket(tickets[index]);
    setIsUpdating(true);
  };

  const handleHide = () => {
    setIsUpdating(false);
    setIsAdding(false);

    axios.get("https://localhost:7127/api/Tickets").then((response) => {
      setTickets(response.data);
    });
  };

  return (
    <>
      <h1>Tickets CRUD</h1>
      <TableContainer component={Card} sx={tableTheme}>
        <Table>
          <TableHead sx={{ backgroundColor: "#02a459" }}>
            <TableRow sx={{ borderRadius: 0 }}>
              <TableCell sx={headCellsTheme}>Ticket Id</TableCell>
              <TableCell sx={headCellsTheme}>Description</TableCell>
              <TableCell sx={headCellsTheme}>Status</TableCell>
              <TableCell sx={headCellsTheme}>Date</TableCell>
              <TableCell sx={headCellsTheme}>Actions</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {tickets.map((ticket, index) => (
              <TableRow
                key={ticket.ticketId}
                sx={{ backgroundColor: "#f2eeeb" }}
              >
                <TableCell sx={cellsTheme}>{ticket.ticketId}</TableCell>
                <TableCell sx={cellsTheme}>{ticket.description}</TableCell>
                <TableCell sx={cellsTheme}>
                  {ticket.status === 0 ? "Closed" : "Open"}
                </TableCell>
                <TableCell sx={cellsTheme}>
                  {format(ticket.date, "MMMM-dd-yyyy")}
                </TableCell>
                <TableCell sx={cellsTheme}>
                  <a href="#update" onClick={(e) => handleUpdate(e, index)}>
                    Update
                  </a>
                  &nbsp;&nbsp;&nbsp;
                  <a href="#delete" onClick={(e) => handleDelete(e, index)}>
                    Delete
                  </a>
                </TableCell>
              </TableRow>
            ))}
            <TableRow sx={{ backgroundColor: "#f2eeeb" }}>
              <TableCell colSpan={5} sx={cellsTheme}>
                <Button
                  sx={buttonTheme}
                  onClick={() => setIsAdding(true)}
                  variant="contained"
                >
                  Add New
                </Button>
              </TableCell>
            </TableRow>
          </TableBody>
        </Table>
      </TableContainer>
      {isUpdating && currentTicket && (
        <UpdateTicket ticket={currentTicket} onHide={handleHide} />
      )}
      {isAdding && <AddTicket onHide={handleHide} />}
    </>
  );
}
