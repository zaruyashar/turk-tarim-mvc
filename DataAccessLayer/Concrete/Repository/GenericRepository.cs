using DataAccessLayer.Abstract;
using DataAccessLayer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Concrete.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        protected readonly AgricultureContext _context;

        public GenericRepository(AgricultureContext context)
        {
            _context = context;
        }

        public void Delete(T t)
        {
            _context.Remove(t);
            _context.SaveChanges();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id)!;
        }

        public List<T> GetListAll()
        {
            return _context.Set<T>().ToList();
        }

        public void Insert(T t)
        {
            _context.Add(t);
            _context.SaveChanges();
        }

        public void Update(T t)
        {
            var trackedEntity = _context.ChangeTracker.Entries<T>()
                        .FirstOrDefault(x => x.Entity == t);

            if (trackedEntity == null)
            {
                _context.Update(t);
            }

            _context.SaveChanges();
        }
    }
}