using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
    public class GalleryImageController : AdminBaseController
    {
        private readonly IGalleryImageService _galleryImageService;

        public GalleryImageController(IGalleryImageService galleryImageService)
        {
            _galleryImageService = galleryImageService;
        }

        public IActionResult Index()
        {
            var values = _galleryImageService.GetListAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddGalleryImage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddGalleryImage(GalleryImage galleryImage)
        {
            GalleryImageValidator validationRules = new GalleryImageValidator();
            ValidationResult result = validationRules.Validate(galleryImage);

            if (result.IsValid)
            {
                _galleryImageService.Insert(galleryImage);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult DeleteGalleryImage(int id)
        {
            var value = _galleryImageService.GetById(id);
            if (value == null)
            {
                return NotFound();
            }
            _galleryImageService.Delete(value);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult EditGalleryImage(int id)
        {
            var value = _galleryImageService.GetById(id);
            if (value == null)
            {
                return NotFound();
            }
            return View(value);
        }


        [HttpPost]
        public IActionResult EditGalleryImage(GalleryImage galleryImage)
        {
            GalleryImageValidator validationRules = new GalleryImageValidator();
            ValidationResult result = validationRules.Validate(galleryImage);

            if (result.IsValid)
            {
                _galleryImageService.Update(galleryImage);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
