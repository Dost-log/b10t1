
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Entities
{
    public class EmployeeMaster
    {
        public EmployeeMaster() { }

        [Key]
        public int EmployeeId { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(6)]
        public string Name{get; set;}

        [Column(TypeName = "varchar")]
        [StringLength(25)]
        public string Designation{get; set;}

        [Column(TypeName = "varchar")]
        [StringLength(25)]
        public string Dept { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(1)]
        public char Gender { get; set; }

        [Column(TypeName = "Date")]
        [StringLength(25)]
        public DateOnly DOB{ get; set; }


    }
}