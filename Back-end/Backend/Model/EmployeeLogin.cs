using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend.Model
{
    public class EmployeeLogin
    {
        [Key]
        [Column(TypeName = "varchar")]
        [ForeignKey("EmployeeMaster")]
        [StringLength(6)]
        public string EmployeeId { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(8)]
        public string password { get; set; }

    }
}
