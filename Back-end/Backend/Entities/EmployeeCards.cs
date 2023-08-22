using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Entities
{
    public class EmployeeCards
    {
        [Key]
        [Column(TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int emp_card_id { get; set; }

        [Required]
        [ForeignKey("EmployeeMaster")]
        [StringLength(6)]
        public string EmployeeId { get; set; }

        [Required]
        [ForeignKey("LoanCardMaster")]
        [StringLength(6)]
        public string LoanId { get; set; }

        [Column(TypeName = "DateTime")]
        public DateTime issue_date { get; set; }
    }
}
