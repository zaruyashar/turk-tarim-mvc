using BusinessLayer.Abstract;
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

        public IActionResult DeleteAnnouncement(int id)
        {
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
            var value = _announcementService.GetById(announcement.AnnouncementID);

            value.Title = announcement.Title;
            value.Description = announcement.Description;
            value.Date = announcement.Date;

            _announcementService.Update(value);
            return RedirectToAction("Index");
        }

        public IActionResult ChangeStatusToTrue(int id)
        {
            _announcementService.AnnouncementStatusToTrue(id);
            return RedirectToAction("Index");
        }

        public IActionResult ChangeStatusToFalse(int id)
        {
            _announcementService.AnnouncementStatusToFalse(id);
            return RedirectToAction("Index");
        }

    }
}
