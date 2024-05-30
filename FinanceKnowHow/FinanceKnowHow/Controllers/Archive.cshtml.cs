using FinanceKnowHow.Models;
using FinanceKnowHow.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinanceKnowHow.Controllers
{
    public class ArchiveModel : BasePageModel
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BlogPostService _BlogPostService;
        public IWebHostEnvironment _WebHostEnvironment { get; }
        public int TakeValue { get; set; }
        public string CurrentUrl { get; set; }
        public ArchiveModel(BlogPostService BlogPostService, IWebHostEnvironment WebHostEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            _BlogPostService = BlogPostService;
            _WebHostEnvironment = WebHostEnvironment;
            _httpContextAccessor= httpContextAccessor;
        }

        // public void SetBlogPosts(BlogPostService blogPostService, int initialTake)
        // {
        //     var setPostsInitial = blogPostService.GetBlogPosts(_httpContextAccessor.HttpContext).Take(initialTake);
        //     var setPostsTotal = blogPostService.GetBlogPosts(_httpContextAccessor.HttpContext);
        // }
        public void OnGet()
        {
            //Set Take Value
            TakeValue = 3;

            var financeBlogService = new BlogPostService(_WebHostEnvironment, "FinanceBlog.json");
            var tradingBlogService = new BlogPostService(_WebHostEnvironment, "TradingBlog.json");
            var economicsBlogService = new BlogPostService(_WebHostEnvironment, "EconomicsBlog.json");
            var investmentsBlogService = new BlogPostService(_WebHostEnvironment, "InvestmentsBlog.json");
            var personalBlogService = new BlogPostService(_WebHostEnvironment, "PersonalBlog.json");
            var popularPostsService = new BlogPostService(_WebHostEnvironment, "PopularBlog.json");

            BlogPosts = _BlogPostService.GetBlogPosts(_httpContextAccessor.HttpContext).Take(3);
            TotalPosts = _BlogPostService.GetBlogPosts(_httpContextAccessor.HttpContext);

            FinancePosts = financeBlogService.GetBlogPosts(_httpContextAccessor.HttpContext).Take(3);
            FinanceTotal = financeBlogService.GetBlogPosts(_httpContextAccessor.HttpContext);

            TradingPosts = tradingBlogService.GetBlogPosts(_httpContextAccessor.HttpContext).Take(3);
            TradingTotal = tradingBlogService.GetBlogPosts(_httpContextAccessor.HttpContext);

            EconomicsPosts = economicsBlogService.GetBlogPosts(_httpContextAccessor.HttpContext).Take(3);
            EconomicsTotal = economicsBlogService.GetBlogPosts(_httpContextAccessor.HttpContext);

            InvestmentPosts = investmentsBlogService.GetBlogPosts(_httpContextAccessor.HttpContext).Take(3);
            InvestmentTotal = investmentsBlogService.GetBlogPosts(_httpContextAccessor.HttpContext);

            PersonalPosts = personalBlogService.GetBlogPosts(_httpContextAccessor.HttpContext).Take(3);
            PersonalTotal = personalBlogService.GetBlogPosts(_httpContextAccessor.HttpContext);

            PopularPosts = popularPostsService.GetBlogPosts(_httpContextAccessor.HttpContext);

            CurrentDateTime = DateTime.Now;
        }
    }
}