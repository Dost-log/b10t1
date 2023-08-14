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


const defaultTheme = createTheme();


export default function AdminDashboard() {

  const navigate = useNavigate();

  const CustomerDataManagement = () => {
    navigate('\add-customer-data');
  }


  return (
    <ThemeProvider theme={defaultTheme}>
      <Typography variant='h2' align='center' marginTop={5}>
            Loan Management System
          </Typography>
      <Container component="main" maxWidth="xs">
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
            Admin Dashboard
          </Typography>
          <Box component="form" noValidate sx={{ mt: 1 }}>

          <Button 
            fullWidth
            sx={{mb : 4}}
            onClick={CustomerDataManagement}
            variant='outlined' 
            align='center'>
              Customer Data Management
          </Button>

          <Button 
            fullWidth
            sx={{mb : 4}}
            variant='outlined' 
            align='center'>
              Loan Card Management
          </Button>

          <Button 
            fullWidth
            sx={{mb : 4}}
            variant='outlined' 
            align='center'>
              Items Master Data
          </Button>
          </Box>
        </Box>
      </Container>
    </ThemeProvider>
  );
}