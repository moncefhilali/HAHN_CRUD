import {
  Box,
  Button,
  MenuItem,
  Table,
  TableCell,
  TableContainer,
  TableRow,
  TextField,
} from "@mui/material";
import { DatePicker } from "@mui/x-date-pickers";
import { Ticket } from "../models/Ticket";
import { useEffect, useState } from "react";
import { toast } from "react-toastify";
import axios from "axios";

interface Props {
  ticket: Ticket;
  onHide: () => void;
}

export default function UpdateTicket({ ticket, onHide }: Props) {
  const [updatedTicket, setUpdatedTicket] = useState<Ticket>(ticket);
  const [errors, setErrors] = useState<{ [key: string]: string }>({});

  useEffect(() => {
    console.log(updatedTicket);
  }, [updatedTicket]);

  const validate = () => {
    const newErrors: { [key: string]: string } = {};

    if (!updatedTicket.description) {
      toast.warning("Description cannot be empty!");
      newErrors.description = "Description cannot be empty!";
    }

    if (!updatedTicket.date || isNaN(new Date(updatedTicket.date).getTime())) {
      toast.warning("A valid date is required!");
      newErrors.date = "A valid date is required!";
    }

    if (updatedTicket.status !== 0 && updatedTicket.status !== 1) {
      toast.warning("A valid status is required!");
      newErrors.status = "A valid status is required!";
    }

    setErrors(newErrors);
    return Object.keys(newErrors).length === 0;
  };

  const handleUpdate = async () => {
    if (validate()) {
      await axios
        .put(
          `https://localhost:7127/api/Tickets/${updatedTicket.ticketId}`,
          updatedTicket
        )
        .then((response) => {
          if (response.status === 200) {
            toast.success("Ticket updated!");
            onHide();
          } else {
            toast.error("Error updating the ticket!");
            console.log(response);
          }
        });
    }
  };

  return (
    <>
      <div className="update-popup">
        <TableContainer>
          <Table>
            <TableRow>
              <TableCell>
                <TextField
                  disabled
                  id="outlined-error-helper-text"
                  label="Ticket Id"
                  defaultValue={updatedTicket.ticketId}
                  sx={{ width: "100%" }}
                />
              </TableCell>
              <TableCell>
                <TextField
                  variant="standard"
                  id="outlined-error-helper-text"
                  label="Description"
                  defaultValue={updatedTicket.description}
                  sx={{ width: "100%" }}
                  onChange={(e) =>
                    setUpdatedTicket({
                      ...updatedTicket,
                      description: e.target.value,
                    })
                  }
                />
              </TableCell>
            </TableRow>
            <TableRow>
              <TableCell>
                <TextField
                  id="outlined-select-currency"
                  select
                  label="Status"
                  defaultValue={updatedTicket.status}
                  sx={{ width: "100%" }}
                  onChange={(e) =>
                    setUpdatedTicket({
                      ...updatedTicket,
                      status: Number.parseInt(e.target.value),
                    })
                  }
                >
                  <MenuItem key={1} value={0}>
                    Closed
                  </MenuItem>
                  <MenuItem key={2} value={1}>
                    Open
                  </MenuItem>
                </TextField>
              </TableCell>
              <TableCell>
                <DatePicker
                  label="Date"
                  defaultValue={new Date(updatedTicket.date)}
                  sx={{ width: "100%" }}
                  onChange={(e) =>
                    setUpdatedTicket({
                      ...updatedTicket,
                      date: e ?? updatedTicket.date,
                    })
                  }
                />
              </TableCell>
            </TableRow>
            <TableRow>
              <TableCell colSpan={2}>
                <Button
                  sx={{ marginRight: "10px", textTransform: "capitalize" }}
                  variant="contained"
                  onClick={handleUpdate}
                >
                  Update
                </Button>
                <Button
                  color="error"
                  sx={{ textTransform: "capitalize" }}
                  variant="contained"
                  onClick={onHide}
                >
                  Cancel
                </Button>
              </TableCell>
            </TableRow>
          </Table>
        </TableContainer>
      </div>
    </>
  );
}
