using Backend.Entities;

namespace Backend.Interfaces
{
    public interface IEmployeeIssuesRepository
    {
        EmployeeIssues GetEmployeeIssue(int id);
        void AddEmployeeIssue(EmployeeIssues employeeIssues);
        void EditEmployeeIssue(EmployeeIssues employeeIssues);
        void DeleteEmployeeIssue(int id);
        List<EmployeeIssues> GetAllEmployeeIssues();
    }
}
