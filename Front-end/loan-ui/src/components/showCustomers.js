import * as React from 'react';
import Box from '@mui/material/Box';
import TextField from '@mui/material/TextField';
import Typography from '@mui/material/Typography';
import Stack from '@mui/material/Stack';
import Button from '@mui/material/Button';
import CssBaseline from '@mui/material/CssBaseline';
import FormControlLabel from '@mui/material/FormControlLabel';
import Checkbox from '@mui/material/Checkbox';
import {Link, useNavigate} from 'react-router-dom';
import Grid from '@mui/material/Grid';
import Container from '@mui/material/Container';
import { createTheme, ThemeProvider } from '@mui/material/styles';
import axios from 'axios';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';


const defaultTheme = createTheme();

const url = "http://localhost:5174/api/EmployeeMasters/GetAllEmployeeMasters";

export default function ShowCustomers() {

  function createData(employeeId, name, designation, department, gender, dob, doj) {
    return { employeeId, name, designation, department, gender, dob, doj};
  }
  
  const [rows, setRows] = React.useState([]);

  axios.get(url,{
    headers : {
      'Access-Control-Allow-Origin':'*',
    }
  }).then((response) => {
    const arr = response.data;
    for(let i = 0; i < arr.length; i++) {
      rows.push(createData(
        arr[i].employeeId, 
        arr[i].name, 
        arr[i].designation, 
        arr[i].department,
        arr[i].gender,
        arr[i].dob,
        arr[i].doj));
    }
  }).catch((error) => {
    //alert("User Already Exists");
  });

  console.log(rows);
  const change = (row) => {
    
  }

  return (
    <ThemeProvider theme={defaultTheme}>
      <Typography variant='h2' align='center' marginTop={5}>
            Loan Management System
          </Typography>
      <Container component="main" maxWidth="lg">
        <CssBaseline />
        <Box
          sx={{
            marginTop: 8,
            display: 'flex',
            flexDirection: 'column',
            alignItems: 'center',
          }}
        >
          <Typography component="h1" variant="h5" marginBottom={10}>
            Customer Master Data
          </Typography>
          <TableContainer component={Paper}>
      <Table sx={{ minWidth: 650 }} aria-label="simple table">
        <TableHead>
          <TableRow>
            <TableCell>Employee Id</TableCell>
            <TableCell align="right">Employee Name</TableCell>
            <TableCell align="right">Designation</TableCell>
            <TableCell align="right">Department</TableCell>
            <TableCell align="right">Gender</TableCell>
            <TableCell align="right">Date of Birth</TableCell>
            <TableCell align="right">Date of Joining</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {rows.map((row, index) => (
            <TableRow
              key={row.employeeId}
              sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
            >
              <TableCell component="th" scope="row">
                {row.employeeId}
              </TableCell>
              <TableCell align="right">{row.name}</TableCell>
              <TableCell align="right">{row.designation}</TableCell>
              <TableCell align="right">{row.department}</TableCell>
              <TableCell align="right">{row.gender}</TableCell>
              <TableCell align="right">{row.dob}</TableCell>
              <TableCell align="right">{row.doj}</TableCell>
              <TableCell align='right'><Button onClick={()=>change(index)}>Edit</Button></TableCell>
              <TableCell align='right'><Button>Delete</Button></TableCell>
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