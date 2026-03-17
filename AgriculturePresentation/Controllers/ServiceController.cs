using AgriculturePresentation.Models;
using BusinessLayer.Abstract;
using DocumentFormat.OpenXml.Office2010.Excel;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AgriculturePresentation.Controllers
{
    public class ServiceController : AdminBaseController
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public IActionResult Index()
        {
            var values = _serviceService.GetListAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddService()
        {
            return View(new ServiceAddViewModel());
        }

        [HttpPost]
        public IActionResult AddService(ServiceAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                _serviceService.Insert(new Service()
                {
                    Title = model.Title,
                    Image = model.Image,
                    Description = model.Description
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult DeleteService(int id)
        {
            int[] protectedIds = { 13, 14, 15, 16 };
            if (protectedIds.Contains(id))
            {
                TempData["ProtectedData"] = "Bu hizmet portföy sunumu için koruma altındadır ve silinemez. Anlayışınız için teşekkürler!";
                return RedirectToAction("Index");
            }

            var values = _serviceService.GetById(id);
            if (values == null)
            {
                return NotFound();
            }
            _serviceService.Delete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditService(int id)
        {
            var values = _serviceService.GetById(id);
            if (values == null)
            {
                return RedirectToAction("Index");
            }
            return View(values);
        }


        [HttpPost]
        public IActionResult EditService(Service service)
        {
            int[] protectedIds = { 13, 14, 15, 16 };
            if (protectedIds.Contains(service.ServiceID))
            {
                TempData["ProtectedData"] = "Bu hizmet portföy sunumu için koruma altındadır ve değiştirilemez. Anlayışınız için teşekkürler!";
                return RedirectToAction("Index");
            }

            _serviceService.Update(service);
            return RedirectToAction("Index");
        }
    }
}
