using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void Delete(Admin t)
        {
            if (t == null)
            {
                throw new ArgumentNullException(nameof(t));
            }
            _adminDal.Delete(t);
        }

        public Admin GetById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID değeri 0 veya negatif olamaz.", nameof(id));
            }
            return _adminDal.GetById(id);
        }

        public List<Admin> GetListAll()
        {
            return _adminDal.GetListAll();
        }

        public void Insert(Admin t)
        {
            if (t == null)
            {
                throw new ArgumentNullException(nameof(t));
            }
            _adminDal.Insert(t);
        }

        public void Update(Admin t)
        {
            if (t == null)
            {
                throw new ArgumentNullException(nameof(t));
            }
            _adminDal.Update(t);
        }
    }
}