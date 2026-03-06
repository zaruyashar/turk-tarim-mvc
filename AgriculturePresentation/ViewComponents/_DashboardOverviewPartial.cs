using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgriculturePresentation.ViewComponents
{
    public class _DashboardOverviewPartial : ViewComponent
    {
        AgricultureContext c = new AgricultureContext();
        public IViewComponentResult Invoke()
        {
            ViewBag.teamCount = c.Teams.Count();
            ViewBag.serviceCount = c.Services.Count();
            ViewBag.messageCount = c.Contacts.Count();
            ViewBag.currentMonthMessage = c.Contacts
                                        .Where(x => x.Date.Month == DateTime.Now.Month
                                          && x.Date.Year == DateTime.Now.Year)
                                          .Count();


            ViewBag.announcementTrue = c.Announcements.Where(x => x.Status == true).Count();
            ViewBag.announcementFalse = c.Announcements.Where(x => x.Status == false).Count();

            ViewBag.urunPazarlama = c.Teams.Where(x => x.Title == "Ürün Pazarlama").Select(y => y.PersonName).FirstOrDefault();
            ViewBag.bakliyatYonetimi = c.Teams.Where(x => x.Title == "Bakliyat Yönetimi").Select(y => y.PersonName).FirstOrDefault();
            ViewBag.ekimUzmani = c.Teams.Where(x => x.Title == "Ekim Uzmanı").Select(y => y.PersonName).FirstOrDefault();
            ViewBag.sutUreticisi = c.Teams.Where(x => x.Title == "Süt Üreticisi").Select(y => y.PersonName).FirstOrDefault();
            return View();
        }
    }
}