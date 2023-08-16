using Backend.Entities;
using Backend.Model;

namespace Backend.Services
{
    public interface IEmployeeMastersRepository
    {
        EmployeeMasters GetEmployee(string id);
        void AddEmployee(EmployeeMasters employeeMasters);
        void EditEmployee(EmployeeMasters employeeMasters);
        void DeleteEmployee(string id);
        EmployeeMasters LoginEmployeeMasters(string id, string password);
    }
}
