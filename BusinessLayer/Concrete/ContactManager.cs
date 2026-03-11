using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void Delete(Contact t)
        {
            if (t == null)
            {
                throw new ArgumentNullException(nameof(t));
            }
            _contactDal.Delete(t);
        }

        public Contact GetById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID değeri 0 veya negatif olamaz.", nameof(id));
            }
            return _contactDal.GetById(id);
        }

        public List<Contact> GetListAll()
        {
            return _contactDal.GetListAll();
        }

        public void Insert(Contact t)
        {
            if (t == null)
            {
                throw new ArgumentNullException(nameof(t));
            }
            _contactDal.Insert(t);
        }

        public void Update(Contact t)
        {
            if (t == null)
            {
                throw new ArgumentNullException(nameof(t));
            }
            _contactDal.Update(t);
        }
    }
}