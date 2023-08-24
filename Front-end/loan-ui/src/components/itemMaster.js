import * as React from "react";
import Box from "@mui/material/Box";
import TextField from "@mui/material/TextField";
import Typography from "@mui/material/Typography";
import Button from "@mui/material/Button";
import CssBaseline from "@mui/material/CssBaseline";
import Container from "@mui/material/Container";
import { createTheme, ThemeProvider } from "@mui/material/styles";
import axios from "axios";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import Paper from "@mui/material/Paper";
import { FormControl, InputLabel, MenuItem, Select } from "@mui/material";
import Navbar from "./navbar";

const defaultTheme = createTheme();

const getUrl = "http://localhost:5174/api/ItemMasters/GetAllItemMasters";
const deleteUrl = "http://localhost:5174/api/ItemMasters/DeleteItem";
const editUrl = "http://localhost:5174/api/ItemMasters/EditItem";

export default function ItemMaster() {
  const [rows, setRows] = React.useState([]);

  const getData = () => {
    axios
      .get(getUrl, {
        headers: {
          "Access-Control-Allow-Origin": "*",
        },
      })
      .then((response) => {
        setRows(response.data);
      })
      .catch((error) => {
        //alert("User Already Exists");
      });
  };

  React.useEffect(() => {
    getData();
  }, []);

  const handleDelete = (itemId) => {
    var result = window.confirm("Are you sure you want to delete?");
    if (result) {
      axios
        .delete(deleteUrl + "?id=" + itemId, {
          headers: {
            "Access-Control-Allow-Origin": "*",
          },
        })
        .then((response) => {
          console.log(response);
          getData();
        })
        .catch((error) => {
          //alert("User Already Exists");
        });
    }
  };
  const [counter, setCounter] = React.useState(0);
  const [description, setDescription] = React.useState("");
  const [issueStatus, setIssueStatus] = React.useState("");
  const [itemValuation, setItemValuation] = React.useState("");

  const handleEdit = (row) => {
    setCounter(row.itemId);
    setDescription(row.descprition);
    setIssueStatus(row.status);
    setItemValuation(row.valuation);
  };

  const handleSave = (row) => {
    setCounter(0);
    axios
      .post(
        editUrl,
        {
          itemId: row.itemId,
          descprition: description,
          status: issueStatus,
          make: row.make,
          category: row.category,
          valuation: itemValuation,
        },
        {
          headers: {
            "Access-Control-Allow-Origin": "*",
          },
        }
      )
      .then((response) => {
        console.log(response);
        getData();
      })
      .catch((error) => {
        //alert("User Already Exists");
      });
  };

  const descriptionChange = (event) => {
    setDescription(event.target.value);
  };

  const issueStatusChange = (event) => {
    setIssueStatus(event.target.value);
  };

  const itemValuationChange = (event) => {
    setItemValuation(event.target.value);
  };

  return (
    <ThemeProvider theme={defaultTheme}>
      <Navbar />
      <Container component="main" maxWidth="lg">
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
            Customer Master Data Details
          </Typography>
          <TableContainer component={Paper}>
            <Table sx={{ minWidth: 650 }} aria-label="simple table">
              <TableHead>
                <TableRow>
                  <TableCell>Item ID</TableCell>
                  <TableCell align="right">Description</TableCell>
                  <TableCell align="right">Issue Status</TableCell>
                  <TableCell align="right">Item Make</TableCell>
                  <TableCell align="right">Item Category</TableCell>
                  <TableCell align="right">Item Valuation</TableCell>
                  <TableCell align="right"></TableCell>
                  <TableCell align="left">Actions</TableCell>
                </TableRow>
              </TableHead>
              <TableBody>
                {rows.map((row) => (
                  <TableRow
                    key={row.employeeId}
                    sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
                  >
                    <TableCell component="th" scope="row">
                      {row.itemId}
                    </TableCell>
                    <TableCell align="right">
                      {counter === row.itemId ? (
                        <TextField
                          variant="standard"
                          defaultValue={row.descprition}
                          sx={{ maxWidth: 100 }}
                          value={description}
                          onChange={descriptionChange}
                        />
                      ) : (
                        row.descprition
                      )}
                    </TableCell>
                    <TableCell align="right">
                      {counter === row.itemId ? (
                        <FormControl sx={{ maxWidth: 100 }}>
                          <InputLabel id="issueStatus-select-label"></InputLabel>
                          <Select
                            labelId="issueStatus-select-label"
                            id="issueStatus"
                            value={issueStatus}
                            defaultValue={row.status}
                            onChange={issueStatusChange}
                          >
                            <MenuItem value={"Y"}>Y</MenuItem>
                            <MenuItem value={"N"}>N</MenuItem>
                          </Select>
                        </FormControl>
                      ) : (
                        row.status
                      )}
                    </TableCell>

                    <TableCell align="right">{row.make}</TableCell>

                    <TableCell align="right">{row.category}</TableCell>

                    <TableCell align="right">
                      {counter === row.itemId ? (
                        <TextField
                          variant="standard"
                          defaultValue={row.valuation}
                          sx={{ maxWidth: 100 }}
                          value={itemValuation}
                          onChange={itemValuationChange}
                        />
                      ) : (
                        row.valuation
                      )}
                    </TableCell>

                    <TableCell align="right">
                      <Button
                        sx={{ color: counter === row.itemId ? "green" : "" }}
                        onClick={
                          counter === row.itemId
                            ? () => handleSave(row)
                            : () => handleEdit(row)
                        }
                      >
                        {counter === row.itemId ? "Save" : "Edit"}
                      </Button>
                    </TableCell>
                    <TableCell align="right">
                      <Button
                        sx={{ color: "red" }}
                        onClick={() => handleDelete(row.itemId)}
                      >
                        Delete
                      </Button>
                    </TableCell>
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
