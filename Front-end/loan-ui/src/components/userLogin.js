import * as React from 'react';
import Avatar from '@mui/material/Avatar';
import Button from '@mui/material/Button';
import CssBaseline from '@mui/material/CssBaseline';
import TextField from '@mui/material/TextField';
import FormControlLabel from '@mui/material/FormControlLabel';
import Checkbox from '@mui/material/Checkbox';
import Grid from '@mui/material/Grid';
import Box from '@mui/material/Box';
import Typography from '@mui/material/Typography';
import Container from '@mui/material/Container';
import { createTheme, ThemeProvider } from '@mui/material/styles';
import {Link, useNavigate} from 'react-router-dom';
import axios from 'axios';



const defaultTheme = createTheme();
const url = "http://localhost:5174/api/EmployeeMasters/LoginEmployeeMasters";

export default function UserLogin() {

  const navigate = useNavigate();
  const [username, setUsername] = React.useState("");
  const [password, setPassword] = React.useState("");

  const usernameChange = (event) => {
    setUsername(event.target.value);
  }

  const passwordChange = (event) => {
    setPassword(event.target.value);
  }

  const handleSubmit = (e) => {
    e.preventDefault();
    const newUrl = url + "?id=" + username + "&password=" + password;
    axios.post(newUrl,  
    {
      headers : {
        'Access-Control-Allow-Origin':'*',
      }
    }).then((response) => {
      navigate('/user-dashboard');
      console.log(response);
    }).catch((error) => {
      alert("Wrong credentials");
    });
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
          
          <Avatar sx={{ m: 1, bgcolor: 'secondary.main' }}>
  
          </Avatar>
          <Typography component="h1" variant="h5">
            User Login
          </Typography>
          <Box noValidate sx={{ mt: 1 }}>
            <TextField
              margin="normal"
              required
              fullWidth
              id="email"
              label="Employee Id"
              name="email"
              value={username}
              onChange={usernameChange}
              autoComplete="email"
              autoFocus
            />
            <TextField
              margin="normal"
              required
              fullWidth
              name="password"
              label="Password"
              type="password"
              id="password"
              value={password}
              onChange={passwordChange}
              autoComplete="current-password"
            />
            
            <Button
              type="submit"
              fullWidth
              variant="contained"
              onClick={handleSubmit}
              sx={{ mt: 3, mb: 2 }}
            >
            Log In
            </Button>
            <Grid container fullWidth>
              <Grid item xs>
                <Link to='/admin-login' variant="body2">
                 I am an Admin 
                </Link>
              </Grid>
            </Grid>
          </Box>
        </Box>
      </Container>
    </ThemeProvider>
  );
}