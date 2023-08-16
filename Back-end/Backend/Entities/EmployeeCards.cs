using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Entities
{
    public class EmployeeCards
    {
       
        [Required]
        [ForeignKey("EmployeeMaster")]
        [StringLength(6)]
        public string EmployeeId { get; set; }
        public EmployeeMasters emp { get; set; }

        [Required]
        [ForeignKey("LoanCardMaster")]
        [StringLength(6)]
        public string LoanId { get; set; }
        public LoanCardMasters card { get; set; }

        [Column(TypeName = "DateTime")]
        public DateTime issue_date { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(25)]
        public string password { get; set; }
    }
}
