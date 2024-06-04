using Annytab.Stemmer;
using FinanceKnowHow.Models;
using FinanceKnowHow.Services;
using FinanceKnowHow.ViewModels;
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
        public IActionResult SearchResults(string query, int currentPage = 1, int pageSize = 6)
        {
            //Convert the query to Lowercase to make the search case-insensitive
            query = query.ToLower();
            ViewBag.Query = query;

            var results = _blogPostService.GetBlogPosts(_httpContextAccessor.HttpContext)
                .Where(p => p.PageName.ToLower().Contains(query) ||
                             p.Highlight.ToLower().Contains(query) ||
                             p.Title.ToLower().Contains(query) ||
                             ContainsStem(p.PageName, query) ||
                             ContainsStem(p.Highlight, query) ||
                             ContainsStem(p.Title, query))
                .ToList();

            //Pagination Call for Search Results
            var count = results.Count();
            var searchItems = results
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize) 
                .ToList();

            var paginatedList = new PaginatedList<BlogPost>(searchItems, count, currentPage, pageSize);

            if (!searchItems.Any())
            {
                ViewBag.Message = "No search results found.";
            }

            return View("_searchResults", paginatedList);
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
