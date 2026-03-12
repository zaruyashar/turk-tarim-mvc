using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
    public class ContactController : AdminBaseController
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            var values = _contactService.GetListAll().OrderByDescending(x => x.ContactID).ToList();
            return View(values);
        }

        public IActionResult DeleteMessage(int id)
        {
            var value = _contactService.GetById(id);
            if (value == null)
            {
                return NotFound();
            }
            _contactService.Delete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult MessageDetails(int id)
        {
            var value = _contactService.GetById(id);
            if (value == null)
            {
                return NotFound();
            }

            if (!value.IsRead)
            {
                value.IsRead = true;
                _contactService.Update(value);
            }

            return View(value);
        }
    }
}
