using System.ComponentModel.DataAnnotations;

namespace FinanceKnowHow.Models
{
    public class SearchInput
    {
        [Required]
        public string query { get; set; }
    }
}
