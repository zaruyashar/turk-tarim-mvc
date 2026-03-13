using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repository;
using DataAccessLayer.Contexts;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfAnnouncementDal : GenericRepository<Announcement>, IAnnouncementDal
    {
        public EfAnnouncementDal(AgricultureContext context) : base(context)
        {
        }

        public void AnnouncementStatusToFalse(int id)
        {
            var p = _context.Announcements.Find(id);
            if (p != null)
            {
                p.Status = false;
                _context.SaveChanges();
            }
        }

        public void AnnouncementStatusToTrue(int id)
        {
            var p = _context.Announcements.Find(id);
            if (p != null)
            {
                p.Status = true;
                _context.SaveChanges();
            }
        }
    }
}