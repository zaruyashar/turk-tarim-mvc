using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class TeamManager : ITeamService
    {
        private readonly ITeamDal _teamDal;

        public TeamManager(ITeamDal teamDal)
        {
            _teamDal = teamDal;
        }

        public void Delete(Team t)
        {
            if (t == null)
            {
                throw new ArgumentNullException(nameof(t));
            }
            _teamDal.Delete(t);
        }

        public Team GetById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID değeri 0 veya negatif olamaz.", nameof(id));
            }
            return _teamDal.GetById(id);
        }

        public List<Team> GetListAll()
        {
            return _teamDal.GetListAll();
        }

        public void Insert(Team t)
        {
            if (t == null)
            {
                throw new ArgumentNullException(nameof(t));
            }
            _teamDal.Insert(t);
        }

        public void Update(Team t)
        {
            if (t == null)
            {
                throw new ArgumentNullException(nameof(t));
            }
            _teamDal.Update(t);
        }
    }
}