using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Linq;

namespace Backend.Model
{
    public class AdminMasters
    {
            [Key]
            [Column(TypeName = "varchar")]
            [StringLength(6)]
            public string EmployeeId { get; set; }

            [Required]
            [Column(TypeName = "varchar")]
            [StringLength(20)]
            public string name { get; set; }
            
            [Column(TypeName = "varchar")]
            [StringLength(25)]
            public string designation { get; set; }

            [Column(TypeName = "char")]
            public char gender { get; set; }

            [Column(TypeName = "varchar")]
            [StringLength(25)]
            public string department { get; set; }

            [Column(TypeName = "DateTime")]
            public DateTime DOB { get; set; }

            [Column(TypeName = "DateTime")]
            public DateTime DOJ { get; set; }

            [Column(TypeName = "varchar")]
            [StringLength(25)]
            public string password { get; set; }
        }
    }

