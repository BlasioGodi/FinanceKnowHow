using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FinanceKnowHow.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string? PageName { get; set; }
        public string? Category { get; set; }
        public string? Title { get; set; }
        public string? Highlight { get; set; }
        public string? Summary { get; set; }
        public string? Author { get; set; }
        public string? Content { get; set; }
        public string? PageLink{ get; set; }
        public DateTime PublishedDate { get; set; } = DateTime.Now; // Default to current date
        public DateTime UpdatedDate { get; set; } = DateTime.Now; // Default to current date

        [JsonPropertyName("img")]
        public string? ImageUrl { get; set; }
        [JsonPropertyName("imgAlt")]
        public string? ImageAlt { get; set; }
        [JsonPropertyName("read")]
        public string? Read { get; set; }
        public string? MetaDescription { get; set; }
        public string? MetaOgTitle { get; set; }
        public string? MetaOgDescription { get; set; }
        public string? MetaKeyWords { get; set; }
        [Required]
        public string? Query{ get; set; }
        public string? CurrentUrl { get; set; }
        public override string ToString() => JsonSerializer.Serialize<BlogPost>(this);
    }
}