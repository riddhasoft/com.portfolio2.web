using com.portfolio2.web.Attributes;
using System.ComponentModel.DataAnnotations;

namespace com.portfolio2.web.Models
{
    public class Portfolio
    {
        public int Id { get; set; }
        [MyString(20)]
        public string Name { get; set; }
        [StringLength(50,MinimumLength =5)]
        public string Category { get; set; }
        public string? BgImage { get; set; }
    }
}
