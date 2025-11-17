using Microsoft.AspNetCore.Mvc;
using JaemyPortfolio.Models;
using JaemyPortfolio.Data;
using System.Diagnostics;

namespace JaemyPortfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                // Get featured portfolio items
                var featuredPortfolioItems = _context.PortfolioItems
                    .Where(p => p.IsActive)
                    .OrderByDescending(p => p.CreatedAt)
                    .Take(3)
                    .ToList();

                // Get latest blog posts
                var latestBlogPosts = _context.BlogPosts
                    .Where(b => b.IsPublished)
                    .OrderByDescending(b => b.CreatedAt)
                    .Take(3)
                    .ToList();

                var viewModel = new HomeViewModel
                {
                    FeaturedPortfolioItems = featuredPortfolioItems,
                    LatestBlogPosts = latestBlogPosts
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while loading home page");
                return View(new HomeViewModel());
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
