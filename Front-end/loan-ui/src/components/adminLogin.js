import * as React from 'react';
import Box from '@mui/material/Box';
import TextField from '@mui/material/TextField';
import Typography from '@mui/material/Typography';

export default function FormPropsTextFields() {
  return (
    <Box
      component="form"
      sx={{
        '& .MuiTextField-root': { m: 1, width: '25ch' }
      }}
      noValidate
      autoComplete="off"
    >
        <Typography variant='h1' gutterBottom align='center'>
            Loan Management Application
        </Typography>

        <Typography variant='h5' gutterBottom align='center'>
            Admin Login
        </Typography>
      
        <TextField
          required
          id="standard-required"
          label="Username"
          defaultValue=""
          variant="standard"
        />
        <TextField
        required
          id="standard-password-input"
          label="Password"
          type="password"
          autoComplete="current-password"
          variant="standard"
        />

        <Typography variant='h6' gutterBottom={true} align='center'>
            Are you a User? Click here.
        </Typography>
        
    </Box>
  );
}