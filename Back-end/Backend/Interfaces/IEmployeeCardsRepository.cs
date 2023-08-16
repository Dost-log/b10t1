using Backend.Entities;
using Backend.Model;

namespace Backend.Services
{
    public interface IEmployeeCardsRepository
    {
        void AddEmployeeCard(EmployeeCards employeeCards);
        EmployeeCards GetEmployeeCard(string  id);
        void EditEmployeeCard(EmployeeCards employeeCards);
        void DeleteEmployeeCard(string id);
    }
}
