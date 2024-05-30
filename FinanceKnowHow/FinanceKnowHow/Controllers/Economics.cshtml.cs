using FinanceKnowHow.Models;
using FinanceKnowHow.Services;
using FinanceKnowHow.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FinanceKnowHow.Controllers 
{ 
    public class EconomicsModel : BasePageModel
    {
        private readonly ILogger<EconomicsModel> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly BlogPostService _blogPostService;
        public BlogPostService _economicsBlogService;
        public BlogPostService _popularBlogService;
        public string DateSuffix { get; set; }
        public string Day { get; set; }
        public IEnumerable<BlogPost> PopularPosts { get; private set; }
        public IEnumerable<BlogPost> EconomicsPostItems { get; private set; }
        public PaginatedList<BlogPost> PaginatedList { get; private set; }
        public EconomicsModel(ILogger<EconomicsModel> logger, BlogPostService blogPostService, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor)
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
            _economicsBlogService = new BlogPostService(_webHostEnvironment, "EconomicsBlog.json");
            _popularBlogService = new BlogPostService(_webHostEnvironment, "PopularBlog.json");

            //Get Popular Posts
            PopularPosts = _popularBlogService.GetBlogPosts(_httpContextAccessor.HttpContext) ?? Enumerable.Empty<BlogPost>();

            //Get Economics Posts
            var economicsPosts = _economicsBlogService.GetBlogPosts(HttpContext) ?? Enumerable.Empty<BlogPost>();
            var count = economicsPosts.Count();

            EconomicsPostItems = economicsPosts
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            //Paginated List Data
            PaginatedList = new PaginatedList<BlogPost>(EconomicsPostItems, count, currentPage, pageSize);

            return Page();
        }
    }
}