using FinanceKnowHow.Models;
using FinanceKnowHow.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinanceKnowHow.Controllers
{
    public class BlogPostModel : BasePageModel
    {
        private readonly BlogPostService _blogPostService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BlogPostModel(BlogPostService blogPostService, IHttpContextAccessor httpContextAccessor)
        {
            _blogPostService = blogPostService;
            _httpContextAccessor = httpContextAccessor;
        }
        public BlogPost BlogPostId { get; private set; }
        public BlogPost BlogPostTitle { get; private set; }
        public BlogPost BlogPostPage { get; private set; }

        public IActionResult OnGet(int id, string title, DateTime date, string pageName) // Assuming the ID is used to identify the blog post
        {
            Theme = "light"; // Set the theme to light for this blog post page
            base.GetTheme(Theme);
            BlogPosts = _blogPostService.GetBlogPosts(_httpContextAccessor.HttpContext);
            BlogPostId = _blogPostService.GetBlogPostById(id, _httpContextAccessor.HttpContext);
            BlogPostTitle = _blogPostService.GetBlogPostByTitle(title, _httpContextAccessor.HttpContext);
            BlogPostPage = _blogPostService.GetBlogPostByPage(pageName, _httpContextAccessor.HttpContext);

            if (BlogPostPage == null)
            {
                return NotFound(); // Or handle the case where the blog post is not found
            }
            return Page();
        }
    }
}
