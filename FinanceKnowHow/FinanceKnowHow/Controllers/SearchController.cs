using Annytab.Stemmer;
using FinanceKnowHow.Models;
using FinanceKnowHow.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinanceKnowHow.Controllers
{
    public class SearchController : Controller
    {
        private readonly BlogPostService _blogPostService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public IEnumerable<BlogPost> BlogPosts;

        public SearchController(BlogPostService blogPostService, IHttpContextAccessor httpContextAccessor)
        {
            _blogPostService = blogPostService;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Search Algorithm
        [HttpGet]
        public IActionResult SearchResults(string query)
        {
            //Convert the query to Lowercase to make the search case-insensitive
            query = query.ToLower();

            var results = _blogPostService.GetBlogPosts(_httpContextAccessor.HttpContext)
                .Where(p => p.PageName.ToLower().Contains(query) ||
                             p.Highlight.ToLower().Contains(query) ||
                             p.Title.ToLower().Contains(query) ||
                             ContainsStem(p.PageName, query) ||
                             ContainsStem(p.Highlight, query) ||
                             ContainsStem(p.Title, query))
                .ToList();

            if (!results.Any())
            {
                ViewBag.Message = "No search results found.";
            }

            return View("_searchResults", results);
        }

        //Method to check if a text contains a stem of a word
        private bool ContainsStem(string text, string query)
        {
            var stemmer = new EnglishStemmer();
            var words = text.Split(' ');

            foreach (var word in words)
            {
                if (stemmer.GetSteamWord(word.ToLower()).Contains(query))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
