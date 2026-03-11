using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class AnnouncementManager : IAnnouncementService
    {
        private readonly IAnnouncementDal _announcementDal;

        public AnnouncementManager(IAnnouncementDal announcementDal)
        {
            _announcementDal = announcementDal;
        }

        public void AnnouncementStatusToFalse(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID değeri 0 veya negatif olamaz.", nameof(id));
            }
            _announcementDal.AnnouncementStatusToFalse(id);
        }

        public void AnnouncementStatusToTrue(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID değeri 0 veya negatif olamaz.", nameof(id));
            }
            _announcementDal.AnnouncementStatusToTrue(id);
        }

        public void Delete(Announcement t)
        {
            if (t == null)
            {
                throw new ArgumentNullException(nameof(t));
            }
            _announcementDal.Delete(t);
        }

        public Announcement GetById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID değeri 0 veya negatif olamaz.", nameof(id));
            }
            return _announcementDal.GetById(id);
        }

        public List<Announcement> GetListAll()
        {
            return _announcementDal.GetListAll();
        }

        public void Insert(Announcement t)
        {
            if (t == null)
            {
                throw new ArgumentNullException(nameof(t));
            }
            _announcementDal.Insert(t);
        }

        public void Update(Announcement t)
        {
            if (t == null)
            {
                throw new ArgumentNullException(nameof(t));
            }
            _announcementDal.Update(t);
        }
    }
}