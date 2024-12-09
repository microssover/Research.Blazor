using Microsoft.AspNetCore.Mvc;

namespace Research.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "ApplicantRecords");
        }
    }
}
