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
  onHide: () => void;
}

export default function AddTicket({ onHide }: Props) {
  const [newTicket, setNewTicket] = useState<Ticket>({
    ticketId: 0,
    description: "",
    date: new Date(),
    status: 0,
  });
  const [errors, setErrors] = useState<{ [key: string]: string }>({});

  useEffect(() => {
    console.log(newTicket);
  }, [newTicket]);

  const validate = () => {
    const newErrors: { [key: string]: string } = {};

    if (!newTicket.description) {
      toast.warning("Description cannot be empty!");
      newErrors.description = "Description cannot be empty!";
    }

    if (!newTicket!.date || isNaN(new Date(newTicket.date).getTime())) {
      toast.warning("A valid date is required!");
      newErrors.date = "A valid date is required!";
    }

    if (newTicket.status !== 0 && newTicket!.status !== 1) {
      toast.warning("A valid status is required!");
      newErrors.status = "A valid status is required!";
    }

    setErrors(newErrors);
    return Object.keys(newErrors).length === 0;
  };

  const handleUpdate = async () => {
    if (validate()) {
      await axios
        .post("https://localhost:7127/api/Tickets", newTicket)
        .then((response) => {
          if (response.status === 200) {
            toast.success("Ticket added!");
            onHide();
          } else {
            toast.error("Error adding the ticket!");
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
              <TableCell colSpan={2}>
                <TextField
                  helperText="Please enter the ticket details"
                  variant="standard"
                  id="outlined-error-helper-text"
                  label="Description"
                  sx={{ width: "100%" }}
                  onChange={(e) =>
                    setNewTicket({
                      ...newTicket,
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
                  defaultValue={0}
                  sx={{ width: "100%" }}
                  onChange={(e) =>
                    setNewTicket({
                      ...newTicket,
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
                  defaultValue={new Date()}
                  sx={{ width: "100%" }}
                  onChange={(e) =>
                    setNewTicket({
                      ...newTicket,
                      date: e ?? new Date(),
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
                  Add
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
