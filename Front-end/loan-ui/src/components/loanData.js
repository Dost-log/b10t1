import * as React from "react";
import Box from "@mui/material/Box";
import TextField from "@mui/material/TextField";
import Typography from "@mui/material/Typography";
import Stack from "@mui/material/Stack";
import Button from "@mui/material/Button";
import CssBaseline from "@mui/material/CssBaseline";
import FormControlLabel from "@mui/material/FormControlLabel";
import Checkbox from "@mui/material/Checkbox";
import { Link, useNavigate } from "react-router-dom";
import Grid from "@mui/material/Grid";
import Container from "@mui/material/Container";
import { createTheme, ThemeProvider } from "@mui/material/styles";
import axios from "axios";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import Paper from "@mui/material/Paper";
import { FormControl, InputLabel, MenuItem, Select } from "@mui/material";
import Navbar from "./navbar";

const defaultTheme = createTheme();

const getUrl =
  "http://localhost:5174/api/LoanCardMasters/GetAllLoanCardMasters";
const deleteUrl = "http://localhost:5174/api/LoanCardMasters/DeleteLoanCard";
const editUrl = "http://localhost:5174/api/LoanCardMasters/EditLoanCard";

export default function LoanData() {
  const [rows, setRows] = React.useState([]);

  const getData = () => {
    axios
      .get(getUrl, {
        headers: {
          "Access-Control-Allow-Origin": "*",
        },
      })
      .then((response) => {
        setRows(response.data);
      })
      .catch((error) => {
        //alert("User Already Exists");
      });
  };

  React.useEffect(() => {
    getData();
  }, []);

  const handleDelete = (loanId) => {
    var result = window.confirm("Are you sure you want to delete?");
    if (result) {
      axios
        .delete(deleteUrl + "?id=" + loanId, {
          headers: {
            "Access-Control-Allow-Origin": "*",
          },
        })
        .then((response) => {
          console.log(response);
          getData();
        })
        .catch((error) => {
          //alert("User Already Exists");
        });
    }
  };
  const [counter, setCounter] = React.useState(0);
  const [loanType, setLoanType] = React.useState("");
  const [duration, setDuration] = React.useState("");
  const [status, setStatus] = React.useState("");

  const handleEdit = (row) => {
    setCounter(row.loanId);
    setLoanType(row.loan_type);
    setDuration(row.duration);
    setStatus(row.status);
  };

  const handleSave = (row) => {
    setCounter(0);
    axios
      .post(
        editUrl,
        {
          loanId: row.loanId,
          loan_type: loanType,
          status: status,
          duration: duration,
        },
        {
          headers: {
            "Access-Control-Allow-Origin": "*",
          },
        }
      )
      .then((response) => {
        console.log(response);
        getData();
      })
      .catch((error) => {
        //alert("User Already Exists");
      });
  };

  const loanTypeChange = (event) => {
    setLoanType(event.target.value);
  };
  const durationChange = (event) => {
    setDuration(event.target.value);
  };
  const statusChange = (event) => {
    setStatus(event.target.value);
  };

  return (
    <ThemeProvider theme={defaultTheme}>
      <Navbar />
      <Container component="main" maxWidth="md">
        <CssBaseline />
        <Box
          sx={{
            marginTop: 8,
            display: "flex",
            flexDirection: "column",
            alignItems: "center",
          }}
        >
          <Typography component="h1" variant="h5" marginBottom={10}>
            Customer Master Data Details
          </Typography>
          <TableContainer component={Paper}>
            <Table sx={{ minWidth: 650 }} aria-label="simple table">
              <TableHead>
                <TableRow>
                  <TableCell>Loan ID</TableCell>
                  <TableCell align="right">Loan Type</TableCell>
                  <TableCell align="right">Duration</TableCell>
                  <TableCell align="right">Status</TableCell>
                  <TableCell align="right"></TableCell>
                  <TableCell align="left">Actions</TableCell>
                </TableRow>
              </TableHead>
              <TableBody>
                {rows.map((row) => (
                  <TableRow
                    key={row.loanId}
                    sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
                  >
                    <TableCell component="th" scope="row">
                      {row.loanId}
                    </TableCell>
                    <TableCell align="right">
                      {counter === row.loanId ? (
                        <FormControl sx={{ maxWidth: 100 }}>
                          <InputLabel id="loanType-select-label"></InputLabel>
                          <Select
                            labelId="loanType-select-label"
                            id="loanType"
                            value={loanType}
                            defaultValue={row.loan_type}
                            onChange={loanTypeChange}
                          >
                            <MenuItem value={"Furniture"}>Furniture</MenuItem>
                            <MenuItem value={"Stationary"}>Stationary</MenuItem>
                            <MenuItem value={"Crockery"}>Crockery</MenuItem>
                          </Select>
                        </FormControl>
                      ) : (
                        row.loan_type
                      )}
                    </TableCell>
                    <TableCell align="right">
                      {counter === row.loanId ? (
                        <TextField
                          variant="standard"
                          defaultValue={row.duration}
                          sx={{ maxWidth: 100 }}
                          value={duration}
                          onChange={durationChange}
                        />
                      ) : (
                        row.duration
                      )}
                    </TableCell>
                    <TableCell align="right">
                      {counter === row.loanId ? (
                        <FormControl sx={{ maxWidth: 100 }}>
                          <InputLabel id="loanType-select-label"></InputLabel>
                          <Select
                            labelId="loanType-select-label"
                            id="loanType"
                            value={status}
                            defaultValue={row.status}
                            onChange={statusChange}
                          >
                            <MenuItem value={"Y"}>Yes</MenuItem>
                            <MenuItem value={"N"}>No</MenuItem>
                          </Select>
                        </FormControl>
                      ) : (
                        row.status
                      )}
                    </TableCell>
                    <TableCell align="right">
                      <Button
                        sx={{ color: counter === row.loanId ? "green" : "" }}
                        onClick={
                          counter === row.loanId
                            ? () => handleSave(row)
                            : () => handleEdit(row)
                        }
                      >
                        {counter === row.loanId ? "Save" : "Edit"}
                      </Button>
                    </TableCell>
                    <TableCell align="right">
                      <Button
                        sx={{ color: "red" }}
                        onClick={() => handleDelete(row.loanId)}
                      >
                        Delete
                      </Button>
                    </TableCell>
                  </TableRow>
                ))}
              </TableBody>
            </Table>
          </TableContainer>
        </Box>
      </Container>
    </ThemeProvider>
  );
}
