using FinanceKnowHow.Models;
using FinanceKnowHow.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinanceKnowHow.Controllers
{
    public class ArchiveModel : BasePageModel
    {
        public BlogPostService _BlogPostService;
        public IWebHostEnvironment _WebHostEnvironment { get; }
        public int TakeValue { get; set; }
        public ArchiveModel(BlogPostService BlogPostService, IWebHostEnvironment WebHostEnvironment)
        {
            _BlogPostService = BlogPostService;
            _WebHostEnvironment = WebHostEnvironment;
        }

        public void SetBlogPosts(BlogPostService blogPostService, int initialTake)
        {
            var setPostsInitial = blogPostService.GetBlogPosts().Take(initialTake);
            var setPostsTotal = blogPostService.GetBlogPosts();
        }
        public void OnGet()
        {
            //Set Take Value
            TakeValue = 3;

            var financeBlogService = new BlogPostService(_WebHostEnvironment, "FinanceBlog.json");
            var tradingBlogService = new BlogPostService(_WebHostEnvironment, "TradingBlog.json");
            var economicsBlogService = new BlogPostService(_WebHostEnvironment, "EconomicsBlog.json");
            var investmentsBlogService = new BlogPostService(_WebHostEnvironment, "InvestmentsBlog.json");
            var personalBlogService = new BlogPostService(_WebHostEnvironment, "PersonalBlog.json");

            FinancePosts = financeBlogService.GetBlogPosts().Take(3);
            FinanceTotal = financeBlogService.GetBlogPosts();

            TradingPosts = tradingBlogService.GetBlogPosts().Take(3);
            TradingTotal = tradingBlogService.GetBlogPosts();

            EconomicsPosts = economicsBlogService.GetBlogPosts().Take(3);
            EconomicsTotal = economicsBlogService.GetBlogPosts();

            InvestmentPosts = investmentsBlogService.GetBlogPosts().Take(3);
            InvestmentTotal = investmentsBlogService.GetBlogPosts();

            PersonalPosts = personalBlogService.GetBlogPosts().Take(3);
            PersonalTotal = personalBlogService.GetBlogPosts();

            BlogPosts = _BlogPostService.GetBlogPosts().Take(3);
            TotalPosts = _BlogPostService.GetBlogPosts();

            CurrentDateTime = DateTime.Now;
        }
    }
}