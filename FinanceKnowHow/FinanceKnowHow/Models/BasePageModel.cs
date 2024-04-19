using FinanceKnowHow.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections;

namespace FinanceKnowHow.Models
{
    public class BasePageModel : PageModel
    {
        public IEnumerable<BlogPost> BlogPosts { get; set; }
        public IEnumerable<BlogPost> TotalPosts { get; set; }
        public IEnumerable<BlogPost> FinancePosts { get; set; }
        public IEnumerable<BlogPost> FinanceTotal { get; set; }
        public IEnumerable<BlogPost> InvestmentPosts { get; set; }
        public IEnumerable<BlogPost> InvestmentTotal { get; set; }
        public IEnumerable<BlogPost> TradingPosts { get; set; }
        public IEnumerable<BlogPost> TradingTotal { get; set; }
        public IEnumerable<BlogPost> EconomicsPosts { get; set; }
        public IEnumerable<BlogPost> EconomicsTotal { get; set; }
        public IEnumerable<BlogPost> PersonalPosts { get; set; }
        public IEnumerable<BlogPost> PersonalTotal { get; set; }
        public List<string> Economics { get; set; }
        public List<string> Trading { get; set; }
        public List<string> Investments { get; set; }
        public List<string> Business { get; set; }
        public List<string> PersonalFinance { get; set; }
        public List<string> ServiceName { get; set; }
        public List<string> ProjectTitle { get; set; }
        public List<string> SocialIcons { get; set; }
        public List<string> SocialList { get; set; }
        public string Theme { get; set; } = "light"; // Default to light
        public DateTime CurrentDateTime { get; set; }
        public void GetTheme(string Theme)
        {
            if (Theme == "light")
            {
                ConfigureLightTheme();
            }
            else
            {
                ConfigureDarkTheme();
            }
        }
        private void ConfigureLightTheme()
        {
            ViewData["Social-List-Light"] = ".social-list .bi , .social-list .fa, .social-list .fa-brands{color: #606060;}";
        }
        private void ConfigureDarkTheme()
        {
            ViewData["Social-List-Dark"] = ".social-list .bi , .social-list .fa, .social-list .fa-brands{color: #f8f9fa;}";
        }
    }
}
