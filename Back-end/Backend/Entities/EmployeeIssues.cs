using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Backend.Entities
{
    public class EmployeeIssues
    {

        /*[Key]
        [Column(TypeName = "varchar")]
        [StringLength(6)]*/
        [Key]
        [Column(TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int issueId { get; set; }

        [Required]
        [ForeignKey("EmployeeMaster")]
        [Column(TypeName = "varchar")]
        [StringLength(6)]
        public string EmployeeId { get; set; }

        [Required]
        [ForeignKey("ItemMaster")]
        [Column(TypeName = "varchar")]
        [StringLength(6)]
        public string itemId { get; set; }

        [Column(TypeName = "DateTime")]
        public DateTime issue_date { get; set; }

        [Column(TypeName = "DateTime")]
        public DateTime return_date { get; set; }

    }
}
