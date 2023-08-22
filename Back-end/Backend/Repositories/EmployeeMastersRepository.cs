using Backend.DTO;
using Backend.Entities;
using Backend.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data.SqlClient;

namespace Backend.Repositories
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
        public List<EmployeeMasters> GetAllEmployeeMasters()
        {
            return _dbconnect.EmployeeMasters.ToList();     
        }
        public string ApplyLoan(ApplyLoanDTO applyLoanDTO)
        {
            var itemMasters = _dbconnect.ItemMasters.FirstOrDefault(
                x => x.category == applyLoanDTO.category && x.descprition == applyLoanDTO.descprition && x.valuation == applyLoanDTO.valuation && x.make == applyLoanDTO.make && x.status == 'Y'
                );
            if (itemMasters == null)
            {
                return "No item available";
            }
            else
            {
                var loanCardMasters = _dbconnect.LoanCardMasters.FirstOrDefault(x => x.loan_type == applyLoanDTO.category && x.status == 'Y');
                if (loanCardMasters == null)
                {
                    return "No loan card available for this item";
                }
                else
                {
                    loanCardMasters.status = 'N';
                    _dbconnect.LoanCardMasters.Update(loanCardMasters);

                    itemMasters.status = 'N';
                    _dbconnect.ItemMasters.Update(itemMasters);

                    var datetime = DateTime.Now;

                    var employeeCard = new EmployeeCards();
                    employeeCard.EmployeeId = applyLoanDTO.EmployeeId;
                    employeeCard.LoanId = loanCardMasters.LoanId;
                    employeeCard.issue_date = datetime;

                    _dbconnect.EmployeeCards.Add(employeeCard);

                    var employeeIssues = new EmployeeIssues();
                    employeeIssues.EmployeeId = applyLoanDTO.EmployeeId;
                    employeeIssues.itemId = itemMasters.itemId;
                    employeeIssues.issue_date = datetime;
                    employeeIssues.return_date = datetime.AddYears(loanCardMasters.duration);

                    _dbconnect.EmployeeIssues.Add(employeeIssues);
                    _dbconnect.SaveChanges();
                    return "Loan approved";
                }
            }
        }
        public List<AvailedLoansDTO> LoanCardsAvailed(string id)
        {
            List<AvailedLoansDTO> availedLoans = new List<AvailedLoansDTO>();
            string ConnectionString = "Data Source=WINDOWS-BVQNF6J;Database=Loan;TrustServerCertificate=True;Trusted_Connection=true";

            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string Query = "select EmployeeCards.issue_date, LoanCardMasters.LoanId, LoanCardMasters.loan_type, LoanCardMasters.duration from EmployeeCards inner join LoanCardMasters on EmployeeCards.LoanId = LoanCardMasters.LoanId where EmployeeCards.EmployeeId='"+id+"'";
            SqlCommand cmd = new SqlCommand(Query, con);   
            using(SqlDataReader rdr  = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    AvailedLoansDTO al = new AvailedLoansDTO();
                    al.issue_date = (DateTime)rdr[0];
                    al.loan_id = (string)rdr[1];
                    al.loan_type = (string)rdr[2];
                    al.duration = (int)rdr[3];
                    availedLoans.Add(al);
                }
            }
            return availedLoans;
        }
        public List<ItemPurchasedDTO> ItemsPurchased(string id)
        {
            List<ItemPurchasedDTO> items_purchased = new List<ItemPurchasedDTO>();
            string ConnectionString = "Data Source=WINDOWS-BVQNF6J;Database=Loan;TrustServerCertificate=True;Trusted_Connection=true";

            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string Query = "select EmployeeIssues.issueId, ItemMasters.descprition, ItemMasters.make, ItemMasters.category, ItemMasters.valuation from EmployeeIssues inner join ItemMasters on EmployeeIssues.itemId = ItemMasters.itemId where EmployeeIssues.EmployeeId='" + id + "'";
            SqlCommand cmd = new SqlCommand(Query, con);
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    ItemPurchasedDTO ip = new ItemPurchasedDTO();
                    ip.issue_id = (int)rdr[0];
                    ip.description = (string)rdr[1];
                    ip.make = (string)rdr[2];
                    ip.category = (string)rdr[3];
                    ip.valuation = (int)rdr[4];
                    items_purchased.Add(ip);
                }
            }
            return items_purchased;
        }
    }
}
