using FinanceKnowHow.Controllers;
using FinanceKnowHow.Models;

namespace FinanceKnowHow.ViewModels
{
    public class IndexBlogModel
    {
        public IndexModel IndexModel { get; set; }
        public PaginatedList <BlogPost> PaginatedList { get; set; }
    }
}
