using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class SocialMediaManager : ISocialMediaService
    {
        ISocialMediaDal _socialMediaDal;

        public SocialMediaManager(ISocialMediaDal socialMediaDal)
        {
            _socialMediaDal = socialMediaDal;
        }

        public void Delete(SocialMedia t)
        {
            if (t == null)
            {
                throw new ArgumentNullException(nameof(t));
            }
            _socialMediaDal.Delete(t);
        }

        public SocialMedia GetById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID değeri 0 veya negatif olamaz.", nameof(id));
            }
            return _socialMediaDal.GetById(id);
        }

        public List<SocialMedia> GetListAll()
        {
            return _socialMediaDal.GetListAll();
        }

        public void Insert(SocialMedia t)
        {
            if (t == null)
            {
                throw new ArgumentNullException(nameof(t));
            }
            _socialMediaDal.Insert(t);
        }

        public void Update(SocialMedia t)
        {
            if (t == null)
            {
                throw new ArgumentNullException(nameof(t));
            }
            _socialMediaDal.Update(t);
        }
    }
}