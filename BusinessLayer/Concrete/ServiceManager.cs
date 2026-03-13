using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class ServiceManager : IServiceService
    {
        private readonly IServiceDal _serviceDal;

        public ServiceManager(IServiceDal serviceDal)
        {
            _serviceDal = serviceDal;
        }

        public void Delete(Service t)
        {
            if (t == null)
            {
                throw new ArgumentNullException(nameof(t));
            }
            _serviceDal.Delete(t);
        }

        public Service GetById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID değeri 0 veya negatif olamaz.", nameof(id));
            }
            return _serviceDal.GetById(id);
        }

        public List<Service> GetListAll()
        {
            return _serviceDal.GetListAll();
        }

        public void Insert(Service t)
        {
            if (t == null)
            {
                throw new ArgumentNullException(nameof(t));
            }
            _serviceDal.Insert(t);
        }

        public void Update(Service t)
        {
            if (t == null)
            {
                throw new ArgumentNullException(nameof(t));
            }

            var value = _serviceDal.GetById(t.ServiceID);

            if (value != null)
            {
                value.Title = t.Title;
                value.Description = t.Description;
                value.Image = t.Image;

                _serviceDal.Update(value);
            }
        }
    }
}