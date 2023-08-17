using Backend.Entities;
using Backend.Interfaces;

namespace Backend.Repositories
{
    public class LoanCardMastersRepository : ILoanCardMastersRepository
    {
        private readonly LoanDBContext _dbconnect;
        public LoanCardMastersRepository(LoanDBContext _dbconnect)
        {
            this._dbconnect =_dbconnect;    
        }
        public LoanCardMasters GetLoanCard(string id)
        { 
            var loanCardMasters = _dbconnect.LoanCardMasters.FirstOrDefault(x => x.LoanId == id);
            return loanCardMasters;
        }

        public void AddLoanCard(LoanCardMasters loanCardMasters)
        {
            _dbconnect.LoanCardMasters.Add(loanCardMasters);
            _dbconnect.SaveChanges();
        }
        
        public void DeleteLoanCard(string id)
        {
            LoanCardMasters loanCardMasters = _dbconnect.LoanCardMasters.Find(id);
            _dbconnect.LoanCardMasters.Remove(loanCardMasters);
            _dbconnect.SaveChanges();
        }
        public void EditLoanCard(LoanCardMasters loanCardMasters)
        {
            _dbconnect.LoanCardMasters.Update(loanCardMasters);
            _dbconnect.SaveChanges();
        }
    }
}
