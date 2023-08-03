using System.ComponentModel.DataAnnotations;

namespace com.portfolio2.web.Models
{
    public class UserProfile
    {
        [Key]
        public int Id { get; set; }
        [StringLength(150)]
        [Required]
        public string FullName { get; set; }
        [StringLength(250)]
        [Required]
        public string Title { get; set; }
        [StringLength(2000)]
        public string? AboutMe { get; set; }
        public string? Resume { get; set; }
        public string? Photo { get; set; }
    }
}
