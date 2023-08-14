import * as React from 'react';
import Box from '@mui/material/Box';
import TextField from '@mui/material/TextField';
import Typography from '@mui/material/Typography';
import Button from '@mui/material/Button';
import Stack from '@mui/material/Stack';

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
        <Typography variant='h2' gutterBottom align='center'>
            Loan Management Application
        </Typography>

        <Typography variant='h5' gutterBottom align='center'>
            User Dashboard
        </Typography>
      
        <Stack direction="row" spacing={5} align='center'>
          
          <Button variant='contained' align='center'>View Loans</Button>
          <Button variant='contained' align='center'>Apply for a Loan</Button>

          <Button variant='contained' align='center'>View Items Purchased</Button>

        </Stack>  

        
    </Box>
  );
}