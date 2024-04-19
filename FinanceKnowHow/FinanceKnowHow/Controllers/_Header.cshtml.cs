using FinanceKnowHow.Models;
using FinanceKnowHow.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinanceKnowHow.Controllers
{
    public class _HeaderModel : BasePageModel
    {
        private readonly BlogPostService _BlogPostService;
        public _HeaderModel(BlogPostService BlogPostService)
        {
            _BlogPostService = BlogPostService;
        }
        public void OnGet()
        {
            BlogPosts= _BlogPostService.GetBlogPosts();
            CurrentDateTime = DateTime.Now;
        }
    }
}