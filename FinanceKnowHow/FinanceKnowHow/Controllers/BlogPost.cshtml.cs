using FinanceKnowHow.Models;
using FinanceKnowHow.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinanceKnowHow.Controllers
{
    public class BlogPostModel : BasePageModel
    {
        private readonly BlogPostService _blogPostService;
        public BlogPostModel(BlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }
        public BlogPost BlogPostId { get; private set; }
        public BlogPost BlogPostTitle { get; private set; }
        public BlogPost BlogPostPage { get; private set; }

        public IActionResult OnGet(int id, string title, DateTime date, string pageName) // Assuming the ID is used to identify the blog post
        {
            Theme = "light"; // Set the theme to light for this blog post page
            base.GetTheme(Theme);
            BlogPosts = _blogPostService.GetBlogPosts();
            BlogPostId = _blogPostService.GetBlogPostById(id);
            BlogPostTitle = _blogPostService.GetBlogPostByTitle(title);
            BlogPostPage = _blogPostService.GetBlogPostByPage(pageName);

            if (BlogPostPage == null)
            {
                return NotFound(); // Or handle the case where the blog post is not found
            }
            return Page();
        }
    }
}
