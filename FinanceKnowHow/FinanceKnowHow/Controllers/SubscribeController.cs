using Annytab.Stemmer;
using FinanceKnowHow.Models;
using FinanceKnowHow.Services;
using FinanceKnowHow.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FinanceKnowHow.Controllers
{
    public class SubscribeController : Controller
    {
        private readonly BlogPostService _blogPostService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SubscribeController(BlogPostService blogPostService, IHttpContextAccessor httpContextAccessor)
        {
            _blogPostService = blogPostService;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}
