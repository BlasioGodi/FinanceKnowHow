using FinanceKnowHow.Models;
using FinanceKnowHow.Services;
using FinanceKnowHow.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FinanceKnowHow.Controllers
{
    //PaginationController to be used in MVC with Endpoints
    public class PaginationController : Controller
    {
        private readonly BlogPostService _blogPostService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<IndexModel> _logger;

        public PaginationController( ILogger<IndexModel>logger,  BlogPostService blogPostService, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            _blogPostService = blogPostService;
            _webHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index(int currentPage = 1, int pageSize = 10)
        {
            var blogPosts = _blogPostService.GetBlogPosts(_httpContextAccessor.HttpContext) ?? Enumerable.Empty<BlogPost>();

            var count = blogPosts.Count();
            var items = blogPosts
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var paginatedList = new PaginatedList<BlogPost>(items,count,currentPage,pageSize);

            //Passing Services to the Composite Model
            var viewModel = new IndexBlogModel()
            {
                IndexModel = new IndexModel(_logger, _blogPostService, _webHostEnvironment, _httpContextAccessor),
                PaginatedList = paginatedList 
            };

            return View(viewModel);
        }
    }
}
