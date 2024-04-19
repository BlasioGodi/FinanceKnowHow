                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  using FinanceKnowHow.Models;
using FinanceKnowHow.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace FinanceKnowHow.Controllers
{
    public class LoadMoreController : Controller
    {
        private readonly BlogPostService _blogPostService;
        public IWebHostEnvironment _WebHostEnvironment { get; }
        public IEnumerable<BlogPost> BlogPosts { get; set; }
       
        public LoadMoreController(BlogPostService blogPostService, IWebHostEnvironment webHostEnvironment)
        {
            _blogPostService = blogPostService;
            _WebHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("/LoadMore/GetBlogs")]
        public IActionResult GetBlogs(string blogServiceUrl,int skip, int take)
        {
            try
            {
                var blogPostService = new BlogPostService(_WebHostEnvironment, blogServiceUrl);

                BlogPosts = blogPostService.GetBlogPosts().Skip(skip).Take(take);
                return PartialView("_additionalBlogs", BlogPosts);
            }
            catch (Exception ex)
            {
                return PartialView("_errorPartial", "An error occured while fetching data: "+ ex.Message);
            }
            
        }
        [HttpGet("/LoadMore/GetCount")]
        public IActionResult GetCount(int skip, int take)
        {
            var getData = _blogPostService.GetBlogPosts().Skip(skip).Take(take);
            return Json(getData);
        }
    }
}
