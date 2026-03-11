using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class AddressManager : IAddressService
    {
        IAddressDal _addressDal;

        public AddressManager(IAddressDal addressDal)
        {
            _addressDal = addressDal;
        }

        public void Delete(Address t)
        {
            if (t == null)
            {
                throw new ArgumentNullException(nameof(t));
            }
            _addressDal.Delete(t);
        }

        public Address GetById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID değeri 0 veya negatif olamaz.", nameof(id));
            }
            return _addressDal.GetById(id);
        }

        public List<Address> GetListAll()
        {
            return _addressDal.GetListAll();
        }

        public void Insert(Address t)
        {
            if (t == null)
            {
                throw new ArgumentNullException(nameof(t));
            }
            _addressDal.Insert(t);
        }

        public void Update(Address t)
        {
            if (t == null)
            {
                throw new ArgumentNullException(nameof(t));
            }
            _addressDal.Update(t);
        }
    }
}