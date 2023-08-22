namespace Backend.DTO
{
    public class AvailedLoansDTO
    {
        public string loan_id { get; set; }     
        public string loan_type { get; set; }
        public int duration { get; set;}
        public DateTime issue_date { get; set; }   

    }
}
