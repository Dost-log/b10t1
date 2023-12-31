import * as React from "react";
import Avatar from "@mui/material/Avatar";
import Button from "@mui/material/Button";
import CssBaseline from "@mui/material/CssBaseline";
import TextField from "@mui/material/TextField";
import { Link, useNavigate } from "react-router-dom";
import Grid from "@mui/material/Grid";
import Box from "@mui/material/Box";
import Typography from "@mui/material/Typography";
import Container from "@mui/material/Container";
import { createTheme, ThemeProvider } from "@mui/material/styles";
import axios from "axios";
import { AppBar, Toolbar } from "@mui/material";
import { toast } from "react-toastify";

const defaultTheme = createTheme();
const url = "http://localhost:5174/api/AdminMasters/LoginAdminMasters";

export default function AdminLogin() {
  const navigate = useNavigate();
  const [username, setUsername] = React.useState("");
  const [password, setPassword] = React.useState("");

  const usernameChange = (event) => {
    setUsername(event.target.value);
  };

  const passwordChange = (event) => {
    setPassword(event.target.value);
  };

  const validated = () => {
    let ok = true;
    if(username === "") {
      ok = false;
      toast.error("Admin Id can't be empty!")
    }
    if(!(/^[0-9]+$/i.test(username)) && ok) {
      ok = false;
      toast.error("Admin Id should be a number!")
    }
    if(password === "") {
      ok = false;
      toast.error("Password can't be empty!")
    }
    return ok;
  }

  const handleSubmit = (e) => {
    if(!validated()) return;
    e.preventDefault();
    const newUrl = url + "?id=" + username + "&password=" + password;
    axios
      .post(newUrl, {
        headers: {
          "Access-Control-Allow-Origin": "*",
        },
      })
      .then((response) => {
        navigate("/admin-dashboard");
        const admin = {
          username: username,
        };
        localStorage.clear();
        localStorage.setItem("admin", JSON.stringify(admin));
        toast.success("Login Successful!");
      })
      .catch((error) => {
        toast.error("Wrong Credentials!");
      });
  };

  React.useEffect(() => {
    const admin = localStorage.getItem("admin");
    if (admin) {
      navigate("/admin-dashboard");
    }
  }, []);

  return (
    <ThemeProvider theme={defaultTheme}>
      <AppBar position="static">
        <Toolbar>
          <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
            Loan Management System
          </Typography>
        </Toolbar>
      </AppBar>
      <Container
        sx={{ border: 1, marginTop: 5, paddingBottom: 5, borderRadius: 2 }}
        component="main"
        maxWidth="xs"
      >
        <CssBaseline />

        <Box
          sx={{
            marginTop: 8,
            display: "flex",
            flexDirection: "column",
            alignItems: "center",
          }}
        >
          <Avatar sx={{ m: 1, bgcolor: "primary.main" }}>
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
              label="Admin Id"
              name="email"
              value={username}
              onChange={usernameChange}
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
                <Link to="/" variant="body2">
                  I am a User
                </Link>
              </Grid>
            </Grid>
          </Box>
        </Box>
      </Container>
    </ThemeProvider>
  );
}
