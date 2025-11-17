using Microsoft.AspNetCore.Mvc;
using JaemyPortfolio.Data;
using Microsoft.EntityFrameworkCore;

namespace JaemyPortfolio.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly ILogger<PortfolioController> _logger;
        private readonly ApplicationDbContext _context;

        public PortfolioController(ILogger<PortfolioController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var portfolioItems = await _context.PortfolioItems
                    .Where(p => p.IsActive)
                    .OrderByDescending(p => p.CreatedAt)
                    .ToListAsync();

                return View(portfolioItems);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while loading portfolio page");
                return View(new List<Models.PortfolioItem>());
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var portfolioItem = await _context.PortfolioItems
                    .FirstOrDefaultAsync(p => p.Id == id);

                if (portfolioItem == null)
                {
                    return NotFound();
                }

                return View(portfolioItem);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while loading portfolio details for ID: {Id}", id);
                return NotFound();
            }
        }
    }
}
