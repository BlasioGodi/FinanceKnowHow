using FinanceKnowHow.Models;
using FinanceKnowHow.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinanceKnowHow.Controllers
{
    public class _FooterModel : BasePageModel
    {
        private readonly BlogPostService _BlogPostService;
        public _FooterModel( BlogPostService BlogPostService)
        {
            _BlogPostService = BlogPostService;
        }
        public void OnGet()
        {
            BlogPosts = _BlogPostService.GetBlogPosts();
        }
    }
}
