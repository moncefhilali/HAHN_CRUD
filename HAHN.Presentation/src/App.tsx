import { useEffect, useState } from "react";
import "./App.css";
import axios from "axios";

function App() {
  const [tickets, setTickets] = useState(["dd", "dd"]);

  useEffect(() => {
    // axios.get("/api/tickets").then((response) => {
    //   if (response.data) setTickets(response.data);
    // });
  }, []);

  return (
    <>
      <h1>CRUD</h1>
      {tickets && tickets.map((ticket) => <ul>{ticket}</ul>)}
    </>
  );
}

export default App;
