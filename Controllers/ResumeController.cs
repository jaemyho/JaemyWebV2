using Microsoft.AspNetCore.Mvc;

namespace JaemyPortfolio.Controllers
{
    public class ResumeController : Controller
    {
        private readonly ILogger<ResumeController> _logger;

        public ResumeController(ILogger<ResumeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while loading resume page");
                throw;
            }
        }

        public IActionResult Download()
        {
            try
            {
                // In a real application, you would serve the actual PDF file
                // For now, we'll return a placeholder response
                return Json(new { message = "Resume download functionality would be implemented here" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while downloading resume");
                return BadRequest();
            }
        }
    }
}
