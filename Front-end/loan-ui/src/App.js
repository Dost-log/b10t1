import logo from './logo.svg';
import UserLogin from './components/userLogin'
import AdminLogin from './components/adminLogin'
import UserDashboard from './components/userDashboard'
import AdminDashboard from './components/adminDashboard';
import AddCustomerData from './components/addCustomerData';
import {Routes, Route, Navigate, BrowserRouter} from 'react-router-dom'
import './App.css';

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path='/' element={<UserLogin/>} />
        <Route path='/admin-login' element={<AdminLogin/>} />
        <Route path='/user-dashboard' element={<UserDashboard/>} />
        <Route path='/admin-dashboard' element={<AdminDashboard/>} />
        <Route path='/admin-dashboard/add-customer-data' element={<AddCustomerData/>} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;
