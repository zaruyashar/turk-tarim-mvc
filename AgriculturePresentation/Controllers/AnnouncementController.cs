using BusinessLayer.Abstract;
using DocumentFormat.OpenXml.Office2010.Excel;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
    public class AnnouncementController : AdminBaseController
    {
        private readonly IAnnouncementService _announcementService;

        public AnnouncementController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        public IActionResult Index()
        {
            var values = _announcementService.GetListAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddAnnouncement()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAnnouncement(Announcement announcement)
        {
            announcement.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            announcement.Status = false;
            _announcementService.Insert(announcement);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteAnnouncement(int id)
        {
            int[] protectedIds = { 3, 6, 8 };
            if (protectedIds.Contains(id))
            {
                TempData["ProtectedData"] = "Bu duyuru portföy sunumu için koruma altındadır ve silinemez. Anlayışınız için teşekkürler!";
                return RedirectToAction("Index");
            }

            var values = _announcementService.GetById(id);
            if (values == null)
            {
                return NotFound();
            }
            _announcementService.Delete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditAnnouncement(int id)
        {
            var values = _announcementService.GetById(id);
            if (values == null)
            {
                return NotFound();
            }
            return View(values);
        }

        [HttpPost]
        public IActionResult EditAnnouncement(Announcement announcement)
        {
            int[] protectedIds = { 3, 6, 8 };
            if (protectedIds.Contains(announcement.AnnouncementID))
            {
                TempData["ProtectedData"] = "Bu duyuru portföy sunumu için koruma altındadır ve değiştirilemez. Anlayışınız için teşekkürler!";
                return RedirectToAction("Index");
            }

            var value = _announcementService.GetById(announcement.AnnouncementID);
            value.Title = announcement.Title;
            value.Description = announcement.Description;
            value.Date = announcement.Date;

            _announcementService.Update(value);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ChangeStatusToTrue(int id)
        {
            int[] protectedIds = { 3, 6, 8 };
            if (protectedIds.Contains(id))
            {
                TempData["ProtectedData"] = "Bu duyuru portföy sunumu için koruma altındadır ve değiştirilemez. Anlayışınız için teşekkürler!";
                return RedirectToAction("Index");
            }

            _announcementService.AnnouncementStatusToTrue(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ChangeStatusToFalse(int id)
        {
            int[] protectedIds = { 3, 6, 8 };
            if (protectedIds.Contains(id))
            {
                TempData["ProtectedData"] = "Bu duyuru portföy sunumu için koruma altındadır ve değiştirilemez. Anlayışınız için teşekkürler!";
                return RedirectToAction("Index");
            }

            _announcementService.AnnouncementStatusToFalse(id);
            return RedirectToAction("Index");
        }

    }
}
