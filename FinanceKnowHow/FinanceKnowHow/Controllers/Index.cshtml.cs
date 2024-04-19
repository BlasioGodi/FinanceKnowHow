using FinanceKnowHow.Models;
using FinanceKnowHow.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinanceKnowHow.Controllers 
{ 
    public class IndexModel : BasePageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public BlogPostService _BlogPostService;
        public IEnumerable<BlogPost> BlogPosts { get; private set; }

        public IndexModel(ILogger<IndexModel> logger, BlogPostService blogPostService)
        {
            _logger = logger;
            _BlogPostService = blogPostService;
        }

        public void OnGet()
        {
            Theme = "dark"; // Set the theme to light for this index page
            base.GetTheme(Theme);

            BlogPosts= _BlogPostService.GetBlogPosts();
        }
    }
}