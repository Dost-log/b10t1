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
const url = "http://localhost:5174/api/EmployeeMasters/ItemsPurchased";

export default function ItemsPurchased() {
  const [rows, setRows] = React.useState([]);
  const user = JSON.parse(localStorage.getItem("user"));

  const getData = () => {
    axios
      .post(url + "?id=" + user.username, {
        headers: {
          "Access-Control-Allow-Origin": "*",
        },
      })
      .then((response) => {
        setRows(response.data);
        console.log(response.data);
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
            Items Purchased
          </Typography>

          <Grid container spacing={2} sx={{ marginBottom: 10 }}>
            <Grid item xs={12} sm={4}>
              <Typography align="center" variant="h6">
                Employee Id : {user.username}
              </Typography>
            </Grid>

            <Grid item xs={12} sm={4}>
              <Typography align="center" variant="h6">
                Designation : {user.designation}
              </Typography>
            </Grid>

            <Grid item xs={12} sm={4}>
              <Typography align="center" variant="h6">
                Department : {user.department}
              </Typography>
            </Grid>
          </Grid>

          <TableContainer component={Paper}>
            <Table sx={{ minWidth: 650 }} aria-label="simple table">
              <TableHead>
                <TableRow>
                  <TableCell align="left">Issue ID</TableCell>
                  <TableCell align="right">Item Description</TableCell>
                  <TableCell align="right">Item Make</TableCell>
                  <TableCell align="right">Item Category</TableCell>
                  <TableCell align="right">Item Valuation</TableCell>
                </TableRow>
              </TableHead>
              <TableBody>
                {rows.map((row) => (
                  <TableRow
                    key={row.employeeId}
                    sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
                  >
                    <TableCell align="left">{row.issue_id}</TableCell>
                    <TableCell align="right">{row.description}</TableCell>
                    <TableCell align="right">{row.make}</TableCell>
                    <TableCell align="right">{row.category}</TableCell>
                    <TableCell align="right">{row.valuation}</TableCell>
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
