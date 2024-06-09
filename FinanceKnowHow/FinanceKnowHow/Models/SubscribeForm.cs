using System.ComponentModel.DataAnnotations;

namespace FinanceKnowHow.Models
{
    public class SubscribeForm
    {
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? Surname { get; set;}
        [Required]
        public List<string>? City { get; set; }
        [Required]
        public List<string>? Country { get; set; }

    }
}
