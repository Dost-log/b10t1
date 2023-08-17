using Backend.Entities;

namespace Backend.Interfaces
{
    public interface IEmployeeCardsRepository
    {
        void AddEmployeeCard(EmployeeCards employeeCards);
        EmployeeCards GetEmployeeCard(string  id);
        void EditEmployeeCard(EmployeeCards employeeCards);
        void DeleteEmployeeCard(string id);
    }
}
