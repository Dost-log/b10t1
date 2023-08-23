import * as React from 'react';
import Button from '@mui/material/Button';
import CssBaseline from '@mui/material/CssBaseline';
import TextField from '@mui/material/TextField';
import {Link} from 'react-router-dom'
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


const defaultTheme = createTheme();
const url = "http://localhost:5174/api/ItemMasters/AddItem";


export default function AddCustomerData() {

  const [itemID, setItemID] = React.useState('');
  const [itemCategory, setItemCategory] = React.useState('');
  const [itemDescription, setItemDescription] = React.useState('');
  const [itemValue, setItemValue] = React.useState('');
  const [issueStatus, setItemStatus] = React.useState('');
  const [itemMake, setItemMake]  = React.useState('');

  const handleSubmit = (event) => {
    event.preventDefault();
    axios.post(url, {
      itemId : itemID,
      descprition : itemDescription,
      make : itemMake,
      status : "Y",
      category : itemCategory,
      valuation : itemValue
    }, {
      headers : {
        'Access-Control-Allow-Origin':'*',
      }
    }).then((response) => {
      console.log(response);
      alert("Item Added Successfully")
    }).catch((error) => {
      alert("Error Occured");
    });
  };

  const itemIDChange = (event)=>{
    setItemID(event.target.value);
  }
  const itemCategoryChange = (event)=>{
    setItemCategory(event.target.value);
  }
  const itemDescriptionChange = (event)=>{
    setItemDescription(event.target.value);
  }
  const itemValueChange = (event)=>{
    setItemValue(event.target.value);
  }
  const issueStatusChange = (event)=>{
    setItemStatus(event.target.value);
  }
  const itemMakeChange = (event)=>{
    setItemMake(event.target.value);
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
            marginTop: 5,
            display: 'flex',
            flexDirection: 'column',
            alignItems: 'center',
          }}
        >
          
          <Typography component="h1" variant="h5">
            Add Item Details
          </Typography>
          <Box noValidate onSubmit={handleSubmit} sx={{ mt: 3 }}>
            <Grid container spacing={2}>
              <Grid item xs={12} sm={6}>
                <TextField
                  required
                  fullWidth
                  id="itemid"
                  label="Item ID"
                  value={itemID}
                  onChange={itemIDChange}
                  autoFocus
                />
              </Grid>
              <Grid item xs={12} sm={6}>
                <FormControl fullWidth>
                <InputLabel id="item-select-label">Item Category</InputLabel>
                <Select
                  labelId='item-select-label'
                  id="itemCategory"
                  label="ItemCategory"
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
                  id="item Description"
                  label ="Item Description"
                //   name="lastName"
                  value={itemDescription}
                  onChange={itemDescriptionChange}
                />
              </Grid>
              <Grid item xs={12} sm={6}>
                <TextField
                  required
                  fullWidth
                  id="item Value"
                  label ="Item Value"
                  value={itemValue}
                  onChange={itemValueChange}
                />
              </Grid>


              <Grid item xs={12} sm={6}>
                <FormControl fullWidth>
                <InputLabel id="issueStatus-select-label">Issue Status</InputLabel>
                <Select
                  required
                  labelId='issueStatus-select-label'
                  id="issueStatus"
                  label="IssueStatus"
                  onChange={issueStatusChange}
                  value={issueStatus}>
                  <MenuItem value={"Yes"}>Yes</MenuItem>
                  <MenuItem value={"No"}>No</MenuItem>
                </Select>
                </FormControl>
              </Grid>
              <Grid item xs={12} sm={6}>
                <FormControl fullWidth>
                <InputLabel id="itemMkae-select-label">Item Make</InputLabel>
                <Select
                  required
                  labelId='itemMake-select-label'
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
              Add Data
            </Button>
            <Grid container>
              <Grid item xs>
                <Link to='/item-master' variant="body2">
                  View Existing Items
                </Link>
              </Grid>
            </Grid>
          </Box>
        </Box>
      </Container>
    </ThemeProvider>
  );
}