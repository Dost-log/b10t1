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

const getUrl = "";
const deleteUrl = "";
const editUrl = "";

export default function LoanData(){
    const [rows, setRows] = React.useState([]);

    const getData = ()=> {

        axios.get(getUrl,{
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
    
      const handleDelete = (loanID) => {
        var result = window.confirm("Are you sure you want to delete?");
        if(result) {
          axios.delete(deleteUrl + "?id=" + loanID,{
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
      const [loanType, setLoanType] = React.useState('');
      const [duration, setDuration] = React.useState('');
      
      const handleEdit = (row) => {
        setText("Save");
        setCounter(row.loanID);
        setLoanType(row.loanType);
        setDuration(row.duration);
      }
    
      const handleSave = (row) => {
        setText("Edit");
        setCounter(0);
        axios.post(editUrl, {
          loanID: row.loanID,
          loanType: loanType,
          duration: duration
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

      const loanTypeChange = (event)=>{
        setLoanType(event.target.value);
      }
      const durationChange = (event)=>{
        setDuration(event.target.value);
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
                Customer Master Data Details
              </Typography>
              <TableContainer component={Paper}>
          <Table sx={{ minWidth: 650 }} aria-label="simple table">
            <TableHead>
              <TableRow>
                <TableCell>Loan ID</TableCell>
                <TableCell align="right">Loan Type</TableCell>
                <TableCell align="right">Duration</TableCell>
                <TableCell align="right"></TableCell>
                <TableCell align="left">Actions</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {rows.map((row) => (
                <TableRow
                  key={row.loanID}
                  sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                >
                  <TableCell component="th" scope="row">
                    {row.loanID}
                  </TableCell>
                  <TableCell align="right">
                    {counter === row.loanID ?
                    (<FormControl sx={{maxWidth : 100}}>
                      <InputLabel id="loanType-select-label"></InputLabel>
                        <Select
                          labelId='loanType-select-label'
                          id="loanType"
                          value={loanType}
                          defaultValue={row.loanType}
                          
                          onChange={loanTypeChange}
                          >
                          <MenuItem value={"Furniture"}>Furniture</MenuItem>
                          <MenuItem value={"Stationary"}>Stationary</MenuItem>
                          <MenuItem value={"Crockery"}>Crockery</MenuItem>
                        </Select>
                      </FormControl>):
                      (row.loanType)}
                  </TableCell>
                  <TableCell align="right">
                {counter === row.loanID ?
                (<TextField 
                  variant='standard' 
                  defaultValue={row.duration} 
                  sx={{maxWidth : 100}}
                  value={duration}
                  onChange={durationChange}/>):
                  (row.duration)}
                  </TableCell>
                {/* <TableCell align="right">{row.gender}</TableCell>
                  <TableCell align="right">{row.dob.substring(0,10)}</TableCell>
                  <TableCell align="right">{row.doj.substring(0,10)}</TableCell> */}
                  <TableCell align='right'>
                    <Button sx={{color : (counter === row.loanID ?"green" : "")}} 
                         onClick={counter === row.loanID ? () => handleSave(row) : () => handleEdit(row)}>
                      {text}
                    </Button>
                  </TableCell>
                  <TableCell align='right'><Button sx={{color : "red"}} onClick={() => handleDelete(row.loanID)}>Delete</Button></TableCell>
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