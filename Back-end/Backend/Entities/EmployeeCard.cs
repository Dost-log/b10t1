using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Entities
{
    public class EmployeeCard
    {
        /*[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int EmployeeId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int LoanId { get; set; }*/

        [ForeignKey("EmployeeMaster")]
        public string EmployeeId { get; set; }
        public EmployeeMaster emp { get; set; }

        [ForeignKey("LoanCardMaster")]
        public string LoanId { get; set; }
        public LoanCardMaster card { get; set; }

        [Column(TypeName = "Date")]
        public DateOnly issue_date { get; set; }
    }
}
