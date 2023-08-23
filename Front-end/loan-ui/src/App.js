import logo from './logo.svg';
import UserLogin from './components/userLogin'
import AdminLogin from './components/adminLogin'
import UserDashboard from './components/userDashboard'
import AdminDashboard from './components/adminDashboard';
import AddCustomerData from './components/addCustomerData';
import UserApplyForLoan from './components/userApplyForLoan'
import {Routes, Route, Navigate, BrowserRouter} from 'react-router-dom'
import ShowCustomers from './components/showCustomers'
import LoanCardMaster from './components/loanCardMaster';
import AddItem from './components/addItem';
import LoanCardsAvailed from './components/loanCardsAvailed';
import ItemsPurchased from './components/itemsPurchased';
import ItemMaster from './components/itemMaster';
import LoanData from './components/loanData';
import './App.css';

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path='/' element={<UserLogin/>} />
        <Route path='/admin-login' element={<AdminLogin/>} />
        <Route path='/user-dashboard' element={<UserDashboard/>} />
        <Route path='/admin-dashboard' element={<AdminDashboard/>} />
        <Route path='/add-customer-data' element={<AddCustomerData />} />
        <Route path='/apply-for-loan' element={<UserApplyForLoan />} />
        <Route path='/show-customers' element={<ShowCustomers/>}/>
        <Route path='/loan-card-master' element={<LoanCardMaster/>}/>
        <Route path='/add-item' element={<AddItem/>}/>
        <Route path='/loan-cards-availed' element={<LoanCardsAvailed/>}/>
        <Route path='/items-purchased' element={<ItemsPurchased/>}/>
        <Route path='/item-master' element={<ItemMaster/>}/>
        <Route path='/loan-data' element={<LoanData/>}/>
      </Routes>
    </BrowserRouter>
  );
}

export default App;
