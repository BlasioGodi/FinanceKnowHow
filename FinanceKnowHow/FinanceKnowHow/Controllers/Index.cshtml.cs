using FinanceKnowHow.Models;
using FinanceKnowHow.Services;
using FinanceKnowHow.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinanceKnowHow.Controllers 
{ 
    public class IndexModel : BasePageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public BlogPostService _BlogPostService;
        public BlogPostService _swiperBlogService;
        public BlogPostService _financeBlogService;
        public BlogPostService _tradingBlogService;
        public BlogPostService _economicsBlogService;
        public BlogPostService _personalBlogService;
        public BlogPostService _investmentBlogService;
        public BlogPostService _trendingBlogService;
        public string DateSuffix { get; set; }
        public string Day { get; set; }
        public IEnumerable<BlogPost> BlogPosts { get; private set; }
        public IEnumerable<BlogPost> TopPosts { get; private set; }
        public IEnumerable<BlogPost> FinancePosts { get; private set; }
        public IEnumerable<BlogPost> TradingPosts { get; private set; }
        public IEnumerable<BlogPost> EconomicsPosts { get; private set; }
        public IEnumerable<BlogPost> PersonalPosts { get; private set; }
        public IEnumerable<BlogPost> InvestmentPosts { get; private set; }
        public IEnumerable<BlogPost> TrendingPosts { get; private set; }

        public IndexModel(ILogger<IndexModel> logger, BlogPostService blogPostService, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _BlogPostService = blogPostService;
            _httpContextAccessor = httpContextAccessor;
            _webHostEnvironment = webHostEnvironment;
        }

        public void OnGet()
        {
            //Initialize new Blog data
            _swiperBlogService = new BlogPostService(_webHostEnvironment, "TopBlog.json");
            _financeBlogService = new BlogPostService(_webHostEnvironment, "FinanceBlog.json");
            _tradingBlogService = new BlogPostService(_webHostEnvironment, "TradingBlog.json");
            _economicsBlogService = new BlogPostService(_webHostEnvironment, "EconomicsBlog.json");
            _personalBlogService = new BlogPostService(_webHostEnvironment, "PersonalBlog.json");
            _investmentBlogService = new BlogPostService(_webHostEnvironment, "InvestmentsBlog.json");
            _trendingBlogService = new BlogPostService(_webHostEnvironment, "TrendingBlog.json");

            Theme = "dark"; // Set the theme to light for this index page
            base.GetTheme(Theme);

            BlogPosts = _BlogPostService.GetBlogPosts(_httpContextAccessor.HttpContext);
            TopPosts = _swiperBlogService.GetBlogPosts(_httpContextAccessor.HttpContext);
            FinancePosts = _financeBlogService.GetBlogPosts(_httpContextAccessor.HttpContext);
            TradingPosts = _tradingBlogService.GetBlogPosts(_httpContextAccessor.HttpContext);
            EconomicsPosts = _economicsBlogService.GetBlogPosts(_httpContextAccessor.HttpContext);
            PersonalPosts = _personalBlogService.GetBlogPosts(_httpContextAccessor.HttpContext);
            InvestmentPosts = _investmentBlogService.GetBlogPosts(_httpContextAccessor.HttpContext);
            TrendingPosts = _trendingBlogService.GetBlogPosts(_httpContextAccessor.HttpContext);
        }
    }
}