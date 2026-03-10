using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AgriculturePresentation.ViewComponents
{
    public class _NavbarMessageComponent : ViewComponent
    {
        private readonly IContactService _contactService;

        public _NavbarMessageComponent(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _contactService.GetListAll().OrderByDescending(x => x.Date).Take(3).ToList();
            return View(values);
        }
    }
}
