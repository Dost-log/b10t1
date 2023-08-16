using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Backend.Entities
{
    public class LoanCardMasters
    { 
        

        [Key]
        [Column(TypeName = "varchar")]
        [StringLength(6)]
        public string LoanId { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(15)]
        public string loan_type { get; set; }

        [Column(TypeName = "int")]
        public int duration { get; set; }
    }
}
