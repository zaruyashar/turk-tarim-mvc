using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

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

        [HttpPost]
        public IActionResult DeleteMessage(int id)
        {
            int[] protectedIds = { 12, 47, 48 };
            if (protectedIds.Contains(id))
            {
                TempData["ProtectedData"] = "Bu mesaj portföy sunumu için koruma altındadır ve silinemez. Anlayışınız için teşekkürler!";
                return RedirectToAction("Index");
            }

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

            int[] protectedIds = { 12, 47, 48 };
            if (!value.IsRead && !protectedIds.Contains(id))
            {
                value.IsRead = true;
                _contactService.Update(value);
            }

            return View(value);
        }
    }
}
