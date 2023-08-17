// loan management application
// select product and apply for loan
// employee id textbox || item category DropDown
// item description textbox || item value textbox
// itemmake DropDown

// Apply loan button

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

const defaultTheme = createTheme();
const url = "";

export default function UserApplyForLoan(){
    const [employeeId, setEmployeeId] = React.useState('');
    const [itemCategory, setItemCategory] = React.useState('');
    const [itemDescription, setItemDescription] = React.useState('');
    const [itemValue, setItemValue] = React.useState('');
    const [itemMake, setItemMake] = React.useState('');

    const handleSubmit = (event) => {
        console.log("Handle submit apply for loan fired!");
    }


    const employeeIdChange = (event) => {
        setEmployeeId(event.target.value);
    }

    const itemCategoryChange = (event) => {
        setItemCategory(event.target.value);
    }

    const itemDescriptionChange = (event) => {
        setItemDescription(event.target.value);
    }

    const itemValueChange = (event) =>{
        setItemValue(event.target.value);
    }

    const itemMakeChange = (event) => {
        setItemMake(event.target.value);
    }

    return (
    <ThemeProvider theme={defaultTheme}>
      <Typography variant='h2' align='center' marginTop={5}>
            Loan Management Application
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
            Select Product and Apply for Loan
          </Typography>
          <Box noValidate onSubmit={handleSubmit} sx={{ mt: 3 }}>
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
                <InputLabel id="item-category-select-label">Item Category</InputLabel>
                <Select
                  labelId='item-category-select-label'
                  id="item-category"
                  label="Item Category"
                  value={itemCategory}
                  onChange={itemCategoryChange}>
                  <MenuItem value={"Furniture"}>Furniture</MenuItem>
                  <MenuItem value={"Stationary"}>Stationary</MenuItem>
                  <MenuItem value={"Crockery"}>Crockery</MenuItem>
                </Select>
                </FormControl>
              </Grid>
              <Grid item xs={12} sm={6}>
                <TextField
                  required
                  fullWidth
                  id="itemDesc"
                  label="item Description"
                  name="Item Description"
                  value={itemDescription}
                  onChange={itemDescriptionChange}
                />
              </Grid>

              <Grid item xs={12} sm={6}>
                <TextField
                  required
                  fullWidth
                  id="itemVal"
                  label="item Value"
                  name="Item Value"
                  value={itemValue}
                  onChange={itemValueChange}
                />
              </Grid>
              
              <Grid item xs={12} sm={6}>
                <FormControl fullWidth>
                <InputLabel id="item-make-label">Item Make</InputLabel>
                <Select
                  required
                  labelId='item-make-select-label'
                  id="itemMake"
                  label="ItemMake"
                  onChange={itemMakeChange}
                  value={itemMake}>
                  <MenuItem value={"Wooden"}>Wooden</MenuItem>
                  <MenuItem value={"Plastic"}>Plastic</MenuItem>
                  <MenuItem value={"Metal"}>Metal</MenuItem>
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
              Apply Loan
            </Button>
            {/* <Grid container>
              <Grid item xs>
                <Link to='/' variant="body2">
                  View Existing Items
                </Link>
              </Grid>
            </Grid> */}
          </Box>
        </Box>
      </Container>

    </ThemeProvider>
    );
}