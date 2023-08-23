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

const defaultTheme = createTheme();
const url = "http://localhost:5174/api/EmployeeMasters/LoanCardsAvailed"

export default function ShowCustomers() {
  const [rows, setRows] = React.useState([]);

  const getData = () => {
    axios
      .get(url + "?=", {
        headers: {
          "Access-Control-Allow-Origin": "*",
        },
      })
      .then((response) => {
        setRows(response.data);
      })
      .catch((error) => {
        alert("Some Error Occured");
      });
  };

  React.useEffect(() => {
    getData();
  }, []);
  

  return (
    <ThemeProvider theme={defaultTheme}>
      <Typography variant="h2" align="center" marginTop={5}>
        Loan Management System
      </Typography>
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
            Loan Cards Availed
          </Typography>
          <TableContainer component={Paper}>
            <Table sx={{ minWidth: 650 }} aria-label="simple table">
              <TableHead>
                <TableRow>
                  <TableCell>Loan ID</TableCell>
                  <TableCell align="right">Loan Type</TableCell>
                  <TableCell align="right">Duration</TableCell>
                  <TableCell align="right">Card Issue Date</TableCell>
                </TableRow>
              </TableHead>
              <TableBody>
                {rows.map((row) => (
                  <TableRow
                    key={row.employeeId}
                    sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
                  >
                    <TableCell align="right">{row.loanId}</TableCell>
                    <TableCell align="right">{row.loanType}</TableCell>
                    <TableCell align="right">{row.duration}</TableCell>
                    <TableCell align="right">{row.cardIssueDate}</TableCell>
                    
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
