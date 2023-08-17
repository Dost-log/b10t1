import * as React from 'react';
import Avatar from '@mui/material/Avatar';
import Button from '@mui/material/Button';
import CssBaseline from '@mui/material/CssBaseline';
import TextField from '@mui/material/TextField';
import FormControlLabel from '@mui/material/FormControlLabel';
import Checkbox from '@mui/material/Checkbox';
import {Link, useNavigate} from 'react-router-dom';
import Grid from '@mui/material/Grid';
import Box from '@mui/material/Box';
// import LockOutlinedIcon from '@mui/icons-material/LockOutlined';
import Typography from '@mui/material/Typography';
import Container from '@mui/material/Container';
import { createTheme, ThemeProvider } from '@mui/material/styles';
import axios from 'axios';


const defaultTheme = createTheme();
const url = "http://localhost:5174/api/AdminMasters/LoginAdminMasters";

export default function AdminLogin() {

  const navigate = useNavigate();
  const [username, setUsername] = React.useState("");
  const [password, setPassword] = React.useState("");
  const [post, setPost] = React.useState(null);

  const usernameChange = (event) => {
    setUsername(event.target.value);
  }

  const passwordChange = (event) => {
    setPassword(event.target.value);
  }

  // const handleSubmit = (e) => {
  //   e.preventDefault();
  //   axios.post(url, {
  //     id : username,
  //     password : password
  //   }, 
  //     {
  //     headers : {
  //       'Access-Control-Allow-Origin':'*',
  //     }
  //   }).then((response) => {
  //     console.log(response);
  //   });

  //   // if(post) {
  //   //   console.log(post);
  //   //   //navigate('/admin-dashboard');
  //   // }
    
  // }

  const handleSubmit = (e) => {
    e.preventDefault();
    const newUrl = url + "?id=" + username + "&password=" + password;
    axios.post(newUrl,  
      {
      headers : {
        'Access-Control-Allow-Origin':'*',
      }
    }).then((response) => {
      navigate('/admin-dashboard');
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
            {/* <LockOutlinedIcon /> */}
          </Avatar>
          <Typography component="h1" variant="h5">
            Admin Login
          </Typography>
          <Box noValidate sx={{ mt: 1 }}>
            <TextField
              margin="normal"
              required
              fullWidth
              id="email"
              label="Email Address"
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
              onClick={handleSubmit}
              variant="contained"
              sx={{ mt: 3, mb: 2 }}
            >
              Log In
            </Button>
            <Grid container>
              <Grid item xs>
                <Link to='/' variant="body2">
                 I am a User 
                </Link>
              </Grid>
              <Grid item>
                <Link href="#" variant="body2">
                  {"Don't have an account? Sign Up"}
                </Link>
              </Grid>
            </Grid>
          </Box>
        </Box>
      </Container>
    </ThemeProvider>
  );
}