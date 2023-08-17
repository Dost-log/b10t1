using Backend.Entities;
using Backend.Interfaces;

namespace Backend.Services
{
    public class EmployeeIssuesRepository : IEmployeeIssuesRepository
    {
        private readonly LoanDBContext _dbconnect;
        public EmployeeIssuesRepository(LoanDBContext _dbconnect)
        {
            this._dbconnect =_dbconnect;    
        }
        public EmployeeIssues GetEmployeeIssue(string id)
        {
            var employeeIssue = _dbconnect.EmployeeIssues.FirstOrDefault(x => x.issueId == id);
            return employeeIssue;
        }

        public void AddEmployeeIssue(EmployeeIssues employeeIssues)
        {
            _dbconnect.EmployeeIssues.Add(employeeIssues);
            _dbconnect.SaveChanges();
        }
        
        public void DeleteEmployeeIssue(string id)
        {
            EmployeeIssues employeeIssues = _dbconnect.EmployeeIssues.Find(id);
            _dbconnect.EmployeeIssues.Remove(employeeIssues);
            _dbconnect.SaveChanges();
        }
        public void EditEmployeeIssue(EmployeeIssues employeeIssues)
        {
            _dbconnect.EmployeeIssues.Update(employeeIssues);
            _dbconnect.SaveChanges();
        }
    }
}
