using FinanceKnowHow.Models;
using FinanceKnowHow.Services;
using FinanceKnowHow.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinanceKnowHow.Controllers 
{
    public class InvestmentsModel : BasePageModel
    {
        private readonly ILogger<InvestmentsModel> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly BlogPostService _blogPostService;
        public BlogPostService _investmentsBlogService;
        public BlogPostService _popularBlogService;
        public string DateSuffix { get; set; }
        public string Day { get; set; }
        public IEnumerable<BlogPost> PopularPosts { get; private set; }
        public IEnumerable<BlogPost> InvestmentPostItems { get; private set; }
        public PaginatedList<BlogPost> PaginatedList { get; private set; }
        public InvestmentsModel(ILogger<InvestmentsModel> logger, BlogPostService blogPostService, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor)
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
            _investmentsBlogService = new BlogPostService(_webHostEnvironment, "InvestmentsBlog.json");
            _popularBlogService = new BlogPostService(_webHostEnvironment, "PopularBlog.json");

            //Get Popular Posts
            PopularPosts = _popularBlogService.GetBlogPosts(_httpContextAccessor.HttpContext) ?? Enumerable.Empty<BlogPost>();

            //Get Investment Posts
            var investmentPosts = _investmentsBlogService.GetBlogPosts(HttpContext) ?? Enumerable.Empty<BlogPost>();
            var count = investmentPosts.Count();

            InvestmentPostItems = investmentPosts
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            //Paginated List Data
            PaginatedList = new PaginatedList<BlogPost>(InvestmentPostItems, count, currentPage, pageSize);

            return Page();
        }
    }
}