using Microsoft.AspNetCore.Mvc;
using JaemyPortfolio.Data;
using Microsoft.EntityFrameworkCore;

namespace JaemyPortfolio.Controllers
{
    public class BlogController : Controller
    {
        private readonly ILogger<BlogController> _logger;
        private readonly ApplicationDbContext _context;

        public BlogController(ILogger<BlogController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var blogPosts = await _context.BlogPosts
                    .Where(b => b.IsPublished)
                    .OrderByDescending(b => b.CreatedAt)
                    .ToListAsync();

                return View(blogPosts);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while loading blog page");
                return View(new List<Models.BlogPost>());
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var blogPost = await _context.BlogPosts
                    .FirstOrDefaultAsync(b => b.Id == id && b.IsPublished);

                if (blogPost == null)
                {
                    return NotFound();
                }

                return View(blogPost);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while loading blog post details for ID: {Id}", id);
                return NotFound();
            }
        }
    }
}
