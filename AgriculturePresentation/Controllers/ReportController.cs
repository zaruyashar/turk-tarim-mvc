using AgriculturePresentation.Models;
using BusinessLayer.Abstract;
using ClosedXML.Excel;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace AgriculturePresentation.Controllers
{
    public class ReportController : AdminBaseController
    {
        private readonly IContactService _contactService;
        private readonly IAnnouncementService _announcementService;

        public ReportController(IContactService contactService, IAnnouncementService announcementService)
        {
            _contactService = contactService;
            _announcementService = announcementService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StaticReport()
        {
            ExcelPackage.License.SetNonCommercialPersonal("Nejla");

            ExcelPackage excelPackage = new ExcelPackage();
            var workBook = excelPackage.Workbook.Worksheets.Add("Dosya1");

            workBook.Cells[1, 1].Value = "Ürün Adı";
            workBook.Cells[1, 2].Value = "Ürün Kategorisi";
            workBook.Cells[1, 3].Value = "Ürün Stoku";

            workBook.Cells[2, 1].Value = "Mercimek";
            workBook.Cells[2, 2].Value = "Bakliyat";
            workBook.Cells[2, 3].Value = "785 kg";

            workBook.Cells[3, 1].Value = "Buğday";
            workBook.Cells[3, 2].Value = "Bakliyat";
            workBook.Cells[3, 3].Value = "1.986 kg";

            workBook.Cells[4, 1].Value = "Havuç";
            workBook.Cells[4, 2].Value = "Sebze";
            workBook.Cells[4, 3].Value = "167 kg";

            var bytes = excelPackage.GetAsByteArray();

            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "BakliyatRaporu.xlsx");
        }

        public List<ContactModel> ContactList()
        {
            var values = _contactService.GetListAll();
            return values.Select(x => new ContactModel
            {
                ContactID = x.ContactID,
                ContactName = x.Name,
                ContactDate = x.Date,
                ContactMail = x.Mail,
                ContactMessage = x.Message
            }).ToList();
        }

        public IActionResult ContactReport()
        {
            using (var workBook = new XLWorkbook())
            {
                IXLWorksheet workSheet = workBook.Worksheets.Add("Mesaj Listesi");
                workSheet.Cell(1, 1).Value = "Mesaj ID";
                workSheet.Cell(1, 2).Value = "Mesajı Gönderen";
                workSheet.Cell(1, 3).Value = "E-posta Adresi";
                workSheet.Cell(1, 4).Value = "Mesaj İçeriği";
                workSheet.Cell(1, 5).Value = "Mesaj Tarihi";

                int contactRowCount = 2;
                foreach (var item in ContactList())
                {
                    workSheet.Cell(contactRowCount, 1).Value = item.ContactID;
                    workSheet.Cell(contactRowCount, 2).Value = item.ContactName;
                    workSheet.Cell(contactRowCount, 3).Value = item.ContactMail;
                    workSheet.Cell(contactRowCount, 4).Value = item.ContactMessage;
                    workSheet.Cell(contactRowCount, 5).Value = item.ContactDate;

                    contactRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MesajRaporu.xlsx");
                }
            }
        }

        public List<AnnouncementModel> AnnouncementList()
        {
            var values = _announcementService.GetListAll();
            return values.Select(x => new AnnouncementModel
            {
                Id = x.AnnouncementID,
                Status = x.Status,
                Date = x.Date,
                Description = x.Description,
                Title = x.Title
            }).ToList();
        }

        public IActionResult AnnouncementReport()
        {
            using (var workBook = new XLWorkbook())
            {
                IXLWorksheet workSheet = workBook.Worksheets.Add("Duyuru Listesi");
                workSheet.Cell(1, 1).Value = "Duyuru ID";
                workSheet.Cell(1, 2).Value = "Duyuru Başlığı";
                workSheet.Cell(1, 3).Value = "Duyuru Tarihi";
                workSheet.Cell(1, 4).Value = "Duyuru İçeriği";
                workSheet.Cell(1, 5).Value = "Durum";

                int contactRowCount = 2;
                foreach (var item in AnnouncementList())
                {
                    workSheet.Cell(contactRowCount, 1).Value = item.Id;
                    workSheet.Cell(contactRowCount, 2).Value = item.Title;
                    workSheet.Cell(contactRowCount, 3).Value = item.Date;
                    workSheet.Cell(contactRowCount, 4).Value = item.Description;
                    workSheet.Cell(contactRowCount, 5).Value = item.Status;

                    contactRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "DuyuruRaporu.xlsx");
                }
            }
        }
    }
}
