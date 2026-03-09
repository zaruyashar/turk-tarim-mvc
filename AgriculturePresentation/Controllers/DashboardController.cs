using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
    public class DashboardController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
