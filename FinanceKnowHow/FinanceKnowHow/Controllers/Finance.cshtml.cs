using FinanceKnowHow.Models;
using FinanceKnowHow.Services;
using FinanceKnowHow.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinanceKnowHow.Controllers 
{
    public class FinanceModel : BasePageModel
    {
        private readonly ILogger<FinanceModel> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly BlogPostService _blogPostService;
        public BlogPostService _financeBlogService;
        public BlogPostService _popularBlogService;
        public string DateSuffix { get; set; }
        public string Day { get; set; }
        public IEnumerable<BlogPost> PopularPosts { get; private set; }
        public IEnumerable<BlogPost> FinancePostItems { get; private set; }
        public PaginatedList<BlogPost> PaginatedList { get; private set; }
        public FinanceModel(ILogger<FinanceModel> logger, BlogPostService blogPostService, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _blogPostService = blogPostService;
            _httpContextAccessor = httpContextAccessor;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult OnGet(int currentPage = 1, int pageSize = 6)
        {
            // Set the theme to light for this page
            Theme = "dark";
            base.GetTheme(Theme);

            //Initialize new Blog data
            _financeBlogService = new BlogPostService(_webHostEnvironment, "FinanceBlog.json");
            _popularBlogService = new BlogPostService(_webHostEnvironment, "PopularBlog.json");

            //Get Popular Posts
            PopularPosts = _popularBlogService.GetBlogPosts(_httpContextAccessor.HttpContext) ?? Enumerable.Empty<BlogPost>();

            //Get Finance Posts
            var financePosts = _financeBlogService.GetBlogPosts(HttpContext) ?? Enumerable.Empty<BlogPost>();
            var count = financePosts.Count();

            FinancePostItems = financePosts
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            //Paginated List Data
            PaginatedList = new PaginatedList<BlogPost>(FinancePostItems, count, currentPage, pageSize);

            return Page();
        }
    }
}