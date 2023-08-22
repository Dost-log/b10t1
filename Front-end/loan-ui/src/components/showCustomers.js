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
import { FormControl, InputLabel, MenuItem, Select } from '@mui/material';



const defaultTheme = createTheme();

const getAllUrl = "http://localhost:5174/api/EmployeeMasters/GetAllEmployeeMasters";
const deleteUrl = "http://localhost:5174/api/EmployeeMasters/DeleteEmployee";
const editUrl = "http://localhost:5174/api/EmployeeMasters/EditEmployee";

export default function ShowCustomers() {
  
  const [rows, setRows] = React.useState([]);

  const getData = ()=> {

    axios.get(getAllUrl,{
      headers : {
        'Access-Control-Allow-Origin':'*',
      }
    }).then((response) => {
      setRows(response.data);
    }).catch((error) => {
      //alert("User Already Exists");
    });
  }

  React.useEffect(()=> {
    getData()
  },[])

  const handleDelete = (employeeId) => {
    var result = window.confirm("Are you sure you want to delete?");
    if(result) {
      axios.delete(deleteUrl + "?id=" + employeeId,{
        headers : {
          'Access-Control-Allow-Origin':'*',
        }
      }).then((response) => {
        console.log(response);
        getData();
      }).catch((error) => {
        //alert("User Already Exists");
      });
    }
  }
  const [counter, setCounter] = React.useState(0);
  const [text, setText] = React.useState("Edit");
  const [designation, setDesignation] = React.useState('');
  const [department, setDepartment] = React.useState('');
  const [name, setName] = React.useState('');

  const handleEdit = (row) => {
    setText("Save");
    setCounter(row.employeeId);
    setDepartment(row.department);
    setDesignation(row.designation);
    setName(row.name);
  }

  const handleSave = (row) => {
    setText("Edit");
    setCounter(0);
    axios.post(editUrl, {
      employeeId: row.employeeId,
      name: name,
      designation: designation,
      gender: row.gender,
      department: department,
      dob: row.dob,
      doj: row.doj,
      password: row.password
    }, {
      headers : {
        'Access-Control-Allow-Origin':'*',
      }
    }).then((response) => {
      console.log(response);
      getData();
    }).catch((error) => {
      //alert("User Already Exists");
    });
    
  }

  const designationChange = (event) => {
    setDesignation(event.target.value);
  }

  const departmentChange = (event) => {
    setDepartment(event.target.value);
  }

  const nameChange = (event) => {
    setName(event.target.value);
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
            <TableCell align="right"></TableCell>
            <TableCell align="left">Actions</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {rows.map((row) => (
            <TableRow
              key={row.employeeId}
              sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
            >
              <TableCell component="th" scope="row">
                {row.employeeId}
              </TableCell>
              <TableCell align="right">
                {counter === row.employeeId ?
                (<TextField 
                  variant='standard' 
                  defaultValue={row.name} 
                  sx={{maxWidth : 100}}
                  value={name}
                  onChange={nameChange}/>):
                  (row.name)}</TableCell>
              <TableCell align="right">
                {counter === row.employeeId ?
                (<FormControl sx={{maxWidth : 100}}>
                  <InputLabel id="designation-select-label"></InputLabel>
                    <Select
                      labelId='designation-select-label'
                      id="designation"
                      value={designation}
                      defaultValue={row.designation}
                      
                      onChange={designationChange}
                      >
                      <MenuItem value={"Manager"}>Manager</MenuItem>
                      <MenuItem value={"CEO"}>CEO</MenuItem>
                      <MenuItem value={"Software Developer"}>Software Developer</MenuItem>
                    </Select>
                  </FormControl>):
                  (row.designation)}
              </TableCell>
              <TableCell align="right">
                {counter === row.employeeId ?
                (<FormControl sx={{maxWidth : 100}}>
                  <InputLabel id="department-select-label"></InputLabel>
                    <Select
                      labelId='department-select-label'
                      id="department"
                      defaultValue={row.department}
                      onChange={departmentChange}
                      value={department}
                      >
                      <MenuItem value={"Technology"}>Technology</MenuItem>
                      <MenuItem value={"Finance"}>Finance</MenuItem>
                      <MenuItem value={"H.R."}>H.R.</MenuItem>
                    </Select>
                  </FormControl>):
                  (row.department)}
              </TableCell>
              <TableCell align="right">{row.gender}</TableCell>
              <TableCell align="right">{row.dob.substring(0,10)}</TableCell>
              <TableCell align="right">{row.doj.substring(0,10)}</TableCell>
              <TableCell align='right'>
                <Button sx={{color : (counter === row.employeeId ? "green" : "")}} onClick={counter === row.employeeId ? () => handleSave(row) : () => handleEdit(row)}>
                  {text}
                </Button>
              </TableCell>
              <TableCell align='right'><Button sx={{color : "red"}} onClick={() => handleDelete(row.employeeId)}>Delete</Button></TableCell>
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