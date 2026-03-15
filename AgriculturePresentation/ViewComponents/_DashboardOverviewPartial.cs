using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace AgriculturePresentation.ViewComponents
{
    public class _DashboardOverviewPartial : ViewComponent
    {
        private readonly ITeamService _teamService;
        private readonly IServiceService _serviceService;
        private readonly IContactService _contactService;
        private readonly IAnnouncementService _announcementService;

        public _DashboardOverviewPartial(
            ITeamService teamService,
            IServiceService serviceService,
            IContactService contactService,
            IAnnouncementService announcementService)
        {
            _teamService = teamService;
            _serviceService = serviceService;
            _contactService = contactService;
            _announcementService = announcementService;
        }

        public IViewComponentResult Invoke()
        {
            // Count() işlemleri
            ViewBag.teamCount = _teamService.GetListAll().Count();
            ViewBag.serviceCount = _serviceService.GetListAll().Count();
            ViewBag.messageCount = _contactService.GetListAll().Count();

            // Geçerli ayın mesaj sayısı
            ViewBag.currentMonthMessage = _contactService.GetListAll()
                .Count(x => x.Date.Month == DateTime.Now.Month && x.Date.Year == DateTime.Now.Year);

            // Duyuru durumları
            ViewBag.announcementTrue = _announcementService.GetListAll().Count(x => x.Status == true);
            ViewBag.announcementFalse = _announcementService.GetListAll().Count(x => x.Status == false);

            // Dashboard overview ekip bölümü dinamik hale getirildi
            ViewBag.Teams = _teamService.GetListAll();

            return View();
        }
    }
}