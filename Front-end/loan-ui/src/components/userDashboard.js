import * as React from "react";
import Box from "@mui/material/Box";
import TextField from "@mui/material/TextField";
import Typography from "@mui/material/Typography";
import Button from "@mui/material/Button";
import Stack from "@mui/material/Stack";
import CssBaseline from "@mui/material/CssBaseline";
import FormControlLabel from "@mui/material/FormControlLabel";
import Checkbox from "@mui/material/Checkbox";
import { Link, useNavigate } from "react-router-dom";
import Grid from "@mui/material/Grid";
import Container from "@mui/material/Container";
import { createTheme, ThemeProvider } from "@mui/material/styles";
import axios from "axios";
import Navbar from "./navbar";

const defaultTheme = createTheme();

export default function UserDashboard() {
  const navigate = useNavigate();
  
  const ApplyLoan = () => {
    navigate("/apply-for-loan");
  };

  const ViewLoans = () => {
    navigate("/loan-cards-availed");
  };

  const ViewItemsPurchased = () => {
    navigate("/items-purchased");
  };

  return (
    <ThemeProvider theme={defaultTheme}>
      <Navbar />
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
          <Typography component="h1" variant="h5" marginBottom={10}>
            User Dashboard
          </Typography>
          <Box component="form" noValidate sx={{ mt: 1 }}>
            <Button
              fullWidth
              sx={{ mb: 4 }}
              onClick={ViewLoans}
              variant="outlined"
              align="center"
            >
              View Loans
            </Button>

            <Button
              fullWidth
              sx={{ mb: 4 }}
              onClick={ApplyLoan}
              variant="outlined"
              align="center"
            >
              Apply for Loan
            </Button>

            <Button 
              fullWidth 
              sx={{ mb: 4 }} 
              onClick={ViewItemsPurchased}
              variant="outlined" 
              align="center"
            >
              View Items Purchased
            </Button>
          </Box>
        </Box>
      </Container>
    </ThemeProvider>
  );
}
