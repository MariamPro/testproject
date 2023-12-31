using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asp_pro.Models
{
    public class Products
    {
        [Key]
        public int proId { get; set; }
        [Required]
        public string? proName { get; set; }
        [Required]
        public string? proDescription { get; set; }
        public decimal price { get; set; }
        //public string? pathImage { get; set; }
        //[NotMapped]
        //public IFormFile? FileProduct { get; set; }
        [Required]
        public int CateID { get; set; }
        [ForeignKey("CateID")]
        public virtual Category? category { get; set; }
    }
}
