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
        public IEnumerable<BlogPost> GetBlogPosts()
        {
            using (var jsonFileReader = File.OpenText(_jsonFilePath))
            {
                return JsonSerializer.Deserialize<BlogPost[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }
        public BlogPost GetBlogPostById(int postId)
        {
            var blogPostId = GetBlogPosts();
            return blogPostId.FirstOrDefault(post => post.Id == postId);
        }

        public BlogPost GetBlogPostByTitle(string postTitle)
        {
            var blogPostTitle = GetBlogPosts();
            return blogPostTitle.FirstOrDefault(post => post.Title == postTitle);
        }

        public BlogPost GetBlogPostByPage(string postName)
        {
            var blogPostTitle = GetBlogPosts();
            return blogPostTitle.FirstOrDefault(post => post.PageName == postName);
        }
    }
}
