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

        [Required]
        [ForeignKey("EmployeeMaster")]
        [StringLength(6)]
        public string EmployeeId { get; set; }
        public EmployeeMaster emp { get; set; }

        [Required]
        [ForeignKey("LoanCardMaster")]
        [StringLength(6)]
        public string LoanId { get; set; }
        public LoanCardMaster card { get; set; }

        [Column(TypeName = "DateTime")]
        public DateTime issue_date { get; set; }
    }
}
