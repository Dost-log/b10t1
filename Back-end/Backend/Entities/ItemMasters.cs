using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Backend.Entities
{
    public class ItemMasters
    {

        [Key]
        [Column(TypeName = "varchar")]
        [StringLength(6)]
        public string itemId { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(25)]
        public string descprition { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(25)]
        public string make { get; set; }

        [Column(TypeName = "char")]
        public char status { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(20)]
        public string category { get; set; }

        [Column(TypeName = "int")]
        
        public int valuation { get; set; }

    }
}
