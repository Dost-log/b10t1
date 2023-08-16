import * as React from 'react';
import Avatar from '@mui/material/Avatar';
import Button from '@mui/material/Button';
import CssBaseline from '@mui/material/CssBaseline';
import TextField from '@mui/material/TextField';
import FormControlLabel from '@mui/material/FormControlLabel';
import Checkbox from '@mui/material/Checkbox';
import Link from '@mui/material/Link';
import Grid from '@mui/material/Grid';
import { FormControl, InputLabel, MenuItem, Select } from '@mui/material';
import Box from '@mui/material/Box';
import Typography from '@mui/material/Typography';
import Container from '@mui/material/Container';
import { createTheme, ThemeProvider } from '@mui/material/styles';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import {DatePicker} from '@mui/x-date-pickers/DatePicker'
import dayjs from 'dayjs';
import axios from 'axios';
// import response from 'express';


const defaultTheme = createTheme();
const url = "http://localhost:5174/api/EmployeeMasters/AddEmployee";

export default function AddCustomerData() {

  const [employeeId, setEmployeeId] = React.useState('');
  const [designation, setDesignation] = React.useState('');
  const [employeeName, setEmployeeName] = React.useState('');
  const [dob, setDob] = React.useState(dayjs('2022-01-01'));
  const [department, setDepartment] = React.useState('');
  const [doj, setDoj] = React.useState(dayjs('2022-01-01'));
  const [gender, setGender] = React.useState('');
  const [post, setPost] = React.useState(null);

  // React.useEffect(() => {
  //   axios.get(url, {
  //     headers : {
  //       'Access-Control-Allow-Origin':'*',
  //     }
  //   }).then((response) => {
  //     setPost(response.data);
  //   });
  // }, []);

  React.useEffect(() => {
    axios.post(url, {
      employeeId: employeeId,
      name: employeeName,
      designation: designation,
      gender: gender,
      department: department,
      dob: dob,
      doj: doj,
      password: "testing@123"
    }, {
      headers : {
        'Access-Control-Allow-Origin':'*',
      }
    }).then((response) => {
      setPost(response.data);
    });
  })

  if(post) console.log(post);

  const employeeIdChange = (event) => {
    setEmployeeId(event.target.value);
  }
  
  const designationChange = (event) => {
    setDesignation(event.target.value);
  }

  const employeeNameChange = (event) => {
    setEmployeeName(event.target.value);
  }

  // const dobChange = (event) => {
  //   setDob(event.target.value);
  // }

  const departmentChange = (event) => {
    setDepartment(event.target.value);
  }

  // const dojChange = (event) => {
  //   setDoj(event.target.value);
  // }

  const genderChange = (event) => {
    setGender(event.target.value);
  }

  const handleSubmit = (event) => {
    event.preventDefault();
    console.log(department);
    console.log(designation);
    console.log(employeeId);
    console.log(employeeName);
    console.log(dob.format("DD/MM/YYYY"));
    console.log(dob);
    console.log(doj);
    console.log(gender);
  };

  return (
    <ThemeProvider theme={defaultTheme}>
      <Typography variant='h2' align='center' marginTop={5}>
            Loan Management System
      </Typography>
      <Container component="main" maxWidth="xs">
        <CssBaseline />
        <Box
          sx={{
            marginTop: 5,
            display: 'flex',
            flexDirection: 'column',
            alignItems: 'center',
          }}
        >
          
          <Typography component="h1" variant="h5">
            Add a new user
          </Typography>
          <Box component="form" noValidate onSubmit={handleSubmit} sx={{ mt: 3 }}>
            <Grid container spacing={2}>
              <Grid item xs={12} sm={6}>
                <TextField
                  autoComplete="given-name"
                  name="firstName"
                  required
                  fullWidth
                  id="firstName"
                  label="Employee Id"
                  value={employeeId}
                  onChange={employeeIdChange}
                  autoFocus
                />
              </Grid>
              <Grid item xs={12} sm={6}>
                <FormControl fullWidth>
                <InputLabel id="designation-select-label">Designation</InputLabel>
                <Select
                  labelId='designation-select-label'
                  id="designation"
                  label="Designation"
                  value={designation}
                  onChange={designationChange}>
                  <MenuItem value={"Manager"}>Manager</MenuItem>
                  <MenuItem value={"CEO"}>CEO</MenuItem>
                  <MenuItem value={"Software Developer"}>Software Developer</MenuItem>
                </Select>
                </FormControl>
              </Grid>
              <Grid item xs={12} sm={6}>
                <TextField
                  required
                  fullWidth
                  id="lastName"
                  label="Employee Name"
                  name="lastName"
                  value={employeeName}
                  onChange={employeeNameChange}
                />
              </Grid>
              <Grid item xs={12} sm={6}>
              <LocalizationProvider dateAdapter={AdapterDayjs}>
                <DatePicker 
                label="Date of birth"
                value={dob}
                onChange={(newDob) => setDob(newDob)}/>
              </LocalizationProvider>
              </Grid>
              <Grid item xs={12} sm={6}>
                <FormControl fullWidth>
                <InputLabel id="department-select-label">Department</InputLabel>
                <Select
                  required
                  labelId='department-select-label'
                  id="department"
                  label="Department"
                  onChange={departmentChange}
                  value={department}>
                  <MenuItem value={"Technology"}>Technology</MenuItem>
                  <MenuItem value={"Finance"}>Finance</MenuItem>
                  <MenuItem value={"H.R."}>H.R.</MenuItem>
                </Select>
                </FormControl>
              </Grid>
              <Grid item xs={12} sm={6}>
              <LocalizationProvider dateAdapter={AdapterDayjs}>
                <DatePicker 
                label="Date of joining"
                value={doj}
                  onChange={(newDoj) => setDoj(newDoj)}/>
              </LocalizationProvider>
              </Grid>
              <Grid item xs={12} sm={6}>
                <FormControl fullWidth>
                <InputLabel id="gender-select-label">Gender</InputLabel>
                <Select
                  required
                  labelId='gender-select-label'
                  id="gender"
                  label="Gender"
                  onChange={genderChange}
                  value={gender}>
                  <MenuItem value={"M"}>Male</MenuItem>
                  <MenuItem value={"F"}>Female</MenuItem>
                </Select>
                </FormControl>
              </Grid>
              
            </Grid>
            <Button
              type="submit"
              fullWidth
              variant="contained"
              onClick={handleSubmit}
              sx={{ mt: 3, mb: 2 }}
            >
              Add user
            </Button>
            
          </Box>
        </Box>
      </Container>
    </ThemeProvider>
  );
}