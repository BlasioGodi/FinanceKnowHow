using System.ComponentModel.DataAnnotations;

namespace FinanceKnowHow.Models
{
    public class SubscribeFrom
    {
        [Required]
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? Surname { get; set;}
        public List<string>? City { get; set; }
        public List<string>? Country { get; set; }

    }
}
