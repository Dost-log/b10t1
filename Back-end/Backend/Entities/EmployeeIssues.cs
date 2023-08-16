using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Backend.Entities
{
    public class EmployeeIssues
    {
        [Required]
        [ForeignKey("EmployeeMaster")]
        [Column(TypeName = "varchar")]
        [StringLength(6)]
        public int EmployeeId { get; set; }

        [Required]
        [ForeignKey("ItemMaster")]
        [Column(TypeName = "varchar")]
        [StringLength(6)]
        public string itemId { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(25)]
        public string Designation { get; set; }


        [Key]
        [Column(TypeName = "varchar")]
        [StringLength(6)]
        public string issueId { get; set; }

        [Column(TypeName = "DateTime")]
        public DateTime return_date { get; set; }

        [Column(TypeName = "DateTime")]
        public DateTime issue_date { get; set; }
    }
}
