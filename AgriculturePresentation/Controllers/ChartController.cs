using AgriculturePresentation.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
    public class ChartController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProductChart()
        {
            List<ProductClass> productClasses = new List<ProductClass>();

            productClasses.Add(new ProductClass
            {
                ProductName = "Buğday",
                ProductValue = 850
            });

            productClasses.Add(new ProductClass
            {
                ProductName = "Mercimek",
                ProductValue = 480
            });

            productClasses.Add(new ProductClass
            {
                ProductName = "Arpa",
                ProductValue = 250
            });

            productClasses.Add(new ProductClass
            {
                ProductName = "Pirinç",
                ProductValue = 120
            });

            productClasses.Add(new ProductClass
            {
                ProductName = "Domates",
                ProductValue = 960
            });

            return Json(new { jsonlist = productClasses });
        }
    }
}
