using System.ComponentModel.DataAnnotations;

namespace asp_pro.Models
{
    public class User
    {
        [Key]
        public int userId { get; set; }
        [Required]
        public string? username { get; set; }
        [Required]
        public string? password { get; set; }

        public string? Token { get; set; }
        [Required]
        public string? email { get; set; }
        [Required]
        public string? Role { get; set; }
    }
}
