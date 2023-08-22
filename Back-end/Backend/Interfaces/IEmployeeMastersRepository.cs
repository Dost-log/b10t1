using Backend.DTO;
using Backend.Entities;

namespace Backend.Interfaces
{
    public interface IEmployeeMastersRepository
    {
        EmployeeMasters GetEmployee(string id);
        void AddEmployee(EmployeeMasters employeeMasters);
        void EditEmployee(EmployeeMasters employeeMasters);
        void DeleteEmployee(string id);
        EmployeeMasters LoginEmployeeMasters(string id, string password);
        string ApplyLoan(ApplyLoanDTO applyLoanDTO);
        List<ItemPurchasedDTO> ItemsPurchased(string id);
        List<AvailedLoansDTO> LoanCardsAvailed(string id);
        List<EmployeeMasters> GetAllEmployeeMasters();
    }
}
