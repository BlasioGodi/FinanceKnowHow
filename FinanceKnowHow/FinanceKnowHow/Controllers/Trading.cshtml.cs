using FinanceKnowHow.Models;
using FinanceKnowHow.Services;
using FinanceKnowHow.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FinanceKnowHow.Controllers 
{ 
    public class TradingModel : BasePageModel
    {
        private readonly ILogger<TradingModel> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly BlogPostService _blogPostService;
        public BlogPostService _tradingBlogService;
        public  BlogPostService _popularBlogService;
        public string DateSuffix { get; set; }
        public string Day { get; set; }
        public IEnumerable<BlogPost> PopularPosts { get; private set; }
        public IEnumerable<BlogPost> TradingPostItems { get; private set; }
        public PaginatedList<BlogPost> PaginatedList { get; private set; } 
        public TradingModel(ILogger<TradingModel> logger, BlogPostService blogPostService, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor)
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
            _tradingBlogService = new BlogPostService(_webHostEnvironment, "TradingBlog.json");
            _popularBlogService = new BlogPostService(_webHostEnvironment, "PopularBlog.json");

            //Get Popular Posts
            PopularPosts = _popularBlogService.GetBlogPosts(_httpContextAccessor.HttpContext) ?? Enumerable.Empty<BlogPost>();

            //Get Trading Posts
            var tradingPosts = _tradingBlogService.GetBlogPosts(HttpContext) ?? Enumerable.Empty<BlogPost>();
            var count = tradingPosts.Count();

            TradingPostItems = tradingPosts
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            //Paginated List Data
            PaginatedList = new PaginatedList<BlogPost>(TradingPostItems, count, currentPage, pageSize);

            return Page();
        }
    }
}