using SecondSightSouthendEyeCentre.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecondSightSouthendEyeCentre.Models;
using SecondSightSouthendEyeCentre.Data.DbIntractions;

namespace SecondSightSouthendEyeCentre.Service.Implementation
{
    public class CheifComplainListService : ICheifComplainListService
    {
        BaseDB<CheifComplainList> baseDB;
        public CheifComplainListService()
        {
            baseDB = new BaseDB<CheifComplainList>();
        }
        public CheifComplainList Add(CheifComplainList entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(CheifComplainList entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<CheifComplainList> GetAll()
        {
            return baseDB.GetAll().ToList();

        }

        public CheifComplainList GetById(int id)
        {
            return baseDB.GetById(id);

        }

        public CheifComplainList Update(CheifComplainList entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}
