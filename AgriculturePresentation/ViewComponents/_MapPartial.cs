using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AgriculturePresentation.ViewComponents
{
    public class _MapPartial : ViewComponent
    {
        private readonly AgricultureContext _context;

        public _MapPartial(AgricultureContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.Addresses
                        .OrderBy(x => x.AddressID)
                        .Select(x => x.MapInfo)
                        .FirstOrDefault();
            ViewBag.v = values;
            return View();
        }
    }
}