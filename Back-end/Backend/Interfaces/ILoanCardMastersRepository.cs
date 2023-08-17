using Backend.Entities;

namespace Backend.Interfaces
{
    public interface ILoanCardMastersRepository
    {
        LoanCardMasters GetLoanCard(string id);
        void AddLoanCard(LoanCardMasters loanCardMasters);
        void EditLoanCard(LoanCardMasters loanCardMasters);
        void DeleteLoanCard(string id);
    }
}
