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
        public EmployeeIssues GetEmployeeIssue(int id)
        {
            var employeeIssue = _dbconnect.EmployeeIssues.FirstOrDefault(x => x.issueId == id);
            return employeeIssue;
        }

        public void AddEmployeeIssue(EmployeeIssues employeeIssues)
        {
            _dbconnect.EmployeeIssues.Add(employeeIssues);
            _dbconnect.SaveChanges();
        }
        
        public void DeleteEmployeeIssue(int id)
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
        public List<EmployeeIssues> GetAllEmployeeIssues()
        {
            return _dbconnect.EmployeeIssues.ToList();  
        }
    }
}
