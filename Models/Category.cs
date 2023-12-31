using System.ComponentModel.DataAnnotations;

namespace asp_pro.Models
{
    public class Category
    {
        [Key]
        public int cateId { get; set; }
        [Required]
        public string? cateName { get; set; }
        [Required]
        public string? cateDescription { get; set; }

    }
}
