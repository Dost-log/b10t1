using Backend.Entities;

namespace Backend.Interfaces
{
    public interface IEmployeeIssuesRepository
    {
        EmployeeIssues GetEmployeeIssue(string id);
        void AddEmployeeIssue(EmployeeIssues employeeIssues);
        void EditEmployeeIssue(EmployeeIssues employeeIssues);
        void DeleteEmployeeIssue(string id);
    }
}
