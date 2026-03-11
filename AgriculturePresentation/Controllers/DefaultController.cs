using AgriculturePresentation.Models;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace AgriculturePresentation.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private readonly IContactService _contactService;

        public DefaultController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult SendMessage(ContactAddViewModel model)
        {
            Contact contact = new Contact()
            {
                Name = model.Name,
                Mail = model.Mail,
                Message = model.Message,
                Date = DateTime.Now
            };

            _contactService.Insert(contact);

            return RedirectToAction("Index");
        }

        public PartialViewResult ScriptPartial()
        {
            return PartialView();
        }
    }
}
