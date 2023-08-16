using Backend.Model;
using Backend.Entities;

namespace Backend.Services
{
    public class EmployeeMastersRepository : IEmployeeMastersRepository
    {
        private readonly LoanDBContext _dbconnect;
        public EmployeeMastersRepository(LoanDBContext _dbconnect)
        {
            this._dbconnect =_dbconnect;    
        }
        public EmployeeMasters GetEmployee(string id)
        {
            var employeeMasters = _dbconnect.EmployeeMasters.FirstOrDefault(x => x.EmployeeId == id);
            return employeeMasters;
        }

        public void AddEmployee(EmployeeMasters employeeMasters)
        {
            _dbconnect.EmployeeMasters.Add(employeeMasters);
            _dbconnect.SaveChanges();
        }
        
        public void DeleteEmployee(string id)
        {
            EmployeeMasters employeeMasters = _dbconnect.EmployeeMasters.Find(id);
            _dbconnect.EmployeeMasters.Remove(employeeMasters);
            _dbconnect.SaveChanges();
        }
        public void EditEmployee(EmployeeMasters employeeMasters)
        {
            _dbconnect.EmployeeMasters.Update(employeeMasters);
            _dbconnect.SaveChanges();
        }
        public EmployeeMasters LoginEmployeeMasters(string id, string password)
        {
            var employeeMasters = _dbconnect.EmployeeMasters.FirstOrDefault(x => x.EmployeeId == id);
            return employeeMasters;
        }
    }
}
