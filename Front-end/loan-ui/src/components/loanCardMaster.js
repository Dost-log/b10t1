import * as React from "react";
// import React from 'react';
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
// import ButtonGroup from "@material-ui/core/ButtonGroup";
import { ButtonGroup } from "@mui/material";
import { FormControl } from "@mui/material";
import { InputLabel } from "@mui/material";
import { Select } from "@mui/material";
import { MenuItem } from "@mui/material";
import Navbar from "./navbar";

const defaultTheme = createTheme();

const url = "http://localhost:5174/api/LoanCardMasters/AddLoanCard";

export default function LoanCardMaster() {
  const [loanID, setloanID] = React.useState("");
  const [loanType, setLoanType] = React.useState("");
  const [state, setState] = React.useState(1);

  const handleSubmit = (event) => {
    // event.preventDefault();
    axios
      .post(
        url,
        {
          loanId: loanID,
          loan_type: loanType,
          status: "Y",
          duration: state,
        },
        {
          headers: {
            "Access-Control-Allow-Origin": "*",
          },
        }
      )
      .then((response) => {
        console.log(response);
        alert("Loan Card Added Successfully.");
      })
      .catch((error) => {
        alert("Error : This Loan ID already exists, please enter a new ID.");
      });
  };

  const loanIDChange = (event) => {
    setloanID(event.target.value);
  };

  const loanTypeChange = (event) => {
    setLoanType(event.target.value);
  };

  const handleIncrement = (event) => {
    setState(state + 1);
  };

  const handleDecrement = (event) => {
    setState(state > 1 ? state - 1 : state);
  };
  return (
    <ThemeProvider theme={defaultTheme}>
      <Navbar />
      <Container component="main" maxWidth="xs">
        <CssBaseline />
        <Box
          sx={{
            marginTop: 5,
            display: "flex",
            flexDirection: "column",
            alignItems: "center",
          }}
        >
          <Typography component="h1" variant="h5">
            Loan Card Master Data Details
          </Typography>
          <Box noValidate onSubmit={handleSubmit} sx={{ mt: 3 }}>
            <Grid container spacing={2}>
              <Grid item xs={12} sm={6}>
                <TextField
                  //   autoComplete="given-name"
                  //   name="firstName"
                  required
                  fullWidth
                  id="loanID"
                  label="Loan ID"
                  value={loanID}
                  onChange={loanIDChange}
                  autoFocus
                />
              </Grid>
              <Grid item xs={12} sm={6}>
                <FormControl fullWidth>
                  <InputLabel id="loanType-select-label">Loan Type</InputLabel>
                  <Select
                    labelId="loanType-select-label"
                    id="loanType"
                    label="LoanType"
                    value={loanType}
                    onChange={loanTypeChange}
                  >
                    <MenuItem value={"Furniture"}>Furniture</MenuItem>
                    <MenuItem value={"Stationary"}>Stationary</MenuItem>
                    <MenuItem value={"Crockery"}>Crockery</MenuItem>
                  </Select>
                </FormControl>
              </Grid>
              <Grid item xs={12} sm={6}>
                <Typography variant="h5" align="right">
                  Duration (yrs)
                </Typography>
              </Grid>
              <Grid item xs={12} sm={6}>
                <ButtonGroup
                  size="small"
                  aria-label="small outlined button group"
                  label="Duration"
                >
                  <Button onClick={handleIncrement}>+</Button>
                  <Button disabled>{state}</Button>
                  <Button onClick={handleDecrement}>-</Button>
                  {/* {displayCounter && <Button disabled>{this.state.counter}</Button>}
                {displayCounter && <Button onClick={this.handleDecrement}>-</Button>} */}
                </ButtonGroup>
              </Grid>
            </Grid>
            <Button
              type="submit"
              fullWidth
              variant="contained"
              onClick={handleSubmit}
              sx={{ mt: 3, mb: 2 }}
            >
              Add Data
            </Button>
            <Grid container>
              <Grid item xs>
                <Link to="/loan-data" variant="body2">
                  View Existing Loan Cards
                </Link>
              </Grid>
            </Grid>
          </Box>
        </Box>
      </Container>
    </ThemeProvider>
  );
}
