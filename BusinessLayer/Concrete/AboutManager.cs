using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void Delete(About t)
        {
            if (t == null)
            {
                throw new ArgumentNullException(nameof(t));
            }
            _aboutDal.Delete(t);
        }

        public About GetById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID değeri 0 veya negatif olamaz.", nameof(id));
            }
            return _aboutDal.GetById(id);
        }

        public List<About> GetListAll()
        {
            return _aboutDal.GetListAll();
        }

        public void Insert(About t)
        {
            if (t == null)
            {
                throw new ArgumentNullException(nameof(t));
            }
            _aboutDal.Insert(t);
        }

        public void Update(About t)
        {
            if (t == null)
            {
                throw new ArgumentNullException(nameof(t));
            }
            _aboutDal.Update(t);
        }
    }
}