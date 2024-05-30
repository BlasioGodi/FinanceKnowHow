using FinanceKnowHow.Models;
using FinanceKnowHow.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinanceKnowHow.Controllers
{
    public class _HeaderModel : BasePageModel
    {
        private readonly BlogPostService _BlogPostService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SearchInput _searchQuery;
        public string CurrentUrl{ get; set; }
        public string query{ get; set; }
        public _HeaderModel(BlogPostService BlogPostService, IHttpContextAccessor httpContextAccessor)
        {
            _BlogPostService = BlogPostService;
            _httpContextAccessor = httpContextAccessor;
        }
        public void OnGet()
        {
            BlogPosts= _BlogPostService.GetBlogPosts(_httpContextAccessor.HttpContext);
            CurrentDateTime = DateTime.Now;
        }
    }
}