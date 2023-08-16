using Backend.Entities;
using Backend.Model;

namespace Backend.Services
{
    public interface ILoanCardMastersRepository
    {
        LoanCardMasters GetLoanCard(string id);
        void AddLoanCard(LoanCardMasters loanCardMasters);
        void EditLoanCard(LoanCardMasters loanCardMasters);
        void DeleteLoanCard(string id);
    }
}
