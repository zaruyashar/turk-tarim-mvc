using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error404()
        {
            return View();
        }
    }
}
