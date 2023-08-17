using Backend.Entities;
using Backend.Interfaces;

namespace Backend.Services
{
    public class EmployeeCardsRepository : IEmployeeCardsRepository
    {
        private readonly LoanDBContext _dbconnect;
        public EmployeeCardsRepository(LoanDBContext _dbconnect)
        {
            this._dbconnect =_dbconnect;    
        }
        public EmployeeCards GetEmployeeCard(string id)
        {
            var employeeCards = _dbconnect.EmployeeCards.FirstOrDefault(x => x.LoanId == id);
            return employeeCards;
        }

        public void AddEmployeeCard(EmployeeCards employeeCards)
        {
            _dbconnect.EmployeeCards.Add(employeeCards);
            _dbconnect.SaveChanges();
        }
        
        public void DeleteEmployeeCard(string id)
        {
            EmployeeCards employeeCards = _dbconnect.EmployeeCards.Find(id);
            _dbconnect.EmployeeCards.Remove(employeeCards);
            _dbconnect.SaveChanges();
        }
        public void EditEmployeeCard(EmployeeCards employeeCards)
        {
            _dbconnect.EmployeeCards.Update(employeeCards);
            _dbconnect.SaveChanges();
        }
    }
}
