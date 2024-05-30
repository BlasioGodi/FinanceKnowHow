using System.Text.Json;
using FinanceKnowHow.Models;
using Microsoft.AspNetCore.Hosting;

namespace FinanceKnowHow.Services
{
    public class BlogPostService
    {
        private readonly string _jsonFilePath;
        public IWebHostEnvironment _webHostEnvironment { get; }
        public BlogPostService(IWebHostEnvironment webHostEnvironment, string jsonFileName = "BlogList.json")
        {
            _webHostEnvironment = webHostEnvironment;
            _jsonFilePath = Path.Combine(webHostEnvironment.WebRootPath, "data", jsonFileName);
        }
        public IEnumerable<BlogPost> GetBlogPostsNoHttp()
        {
            using (var jsonFileReader = File.OpenText(_jsonFilePath))
            {
                var blogPosts = JsonSerializer.Deserialize<BlogPost[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                return blogPosts;
            }
        }
        public IEnumerable<BlogPost> GetBlogPosts(HttpContext httpContext)
        {
            //To be Refactored. Get the http url
            var currentPageUrl = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}"; 

            using (var jsonFileReader = File.OpenText(_jsonFilePath))
            {
                var blogPosts = JsonSerializer.Deserialize<BlogPost[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                // Set the PageLink property for each BlogPost object to the current page URL
                foreach (var blogPost in blogPosts)
                {
                    blogPost.PageLink = currentPageUrl;
                }

                return blogPosts;
            }
        }
        public BlogPost GetBlogPostById(int postId, HttpContext httpContext)
        {
            var blogPostId = GetBlogPosts(httpContext);
            return blogPostId.FirstOrDefault(post => post.Id == postId);
        }

        public BlogPost GetBlogPostByTitle(string postTitle, HttpContext httpContext)
        {
            var blogPostTitle = GetBlogPosts(httpContext);
            return blogPostTitle.FirstOrDefault(post => post.Title == postTitle);
        }

        public BlogPost GetBlogPostByPage(string postName, HttpContext httpContext)
        {
            var blogPostTitle = GetBlogPosts(httpContext);
            return blogPostTitle.FirstOrDefault(post => post.PageName == postName);
        }
    }
}
