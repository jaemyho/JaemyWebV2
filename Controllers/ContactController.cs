using Microsoft.AspNetCore.Mvc;
using JaemyPortfolio.Data;
using JaemyPortfolio.Models;

namespace JaemyPortfolio.Controllers
{
    public class ContactController : Controller
    {
        private readonly ILogger<ContactController> _logger;
        private readonly ApplicationDbContext _context;

        public ContactController(ILogger<ContactController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while loading contact page");
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(ContactMessage model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.ContactMessages.Add(model);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = "Thank you for your message! I'll get back to you soon.";
                    return RedirectToAction(nameof(Index));
                }

                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while processing contact form");
                TempData["ErrorMessage"] = "Sorry, there was an error sending your message. Please try again.";
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Success()
        {
            return View();
        }
    }
}
