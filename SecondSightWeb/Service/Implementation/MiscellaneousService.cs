using SecondSightSouthendEyeCentre.Data.DbIntractions;
using SecondSightWeb.Models;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Service.Implementation
{
    public class MiscellaneousService : IMiscellaneousService
    {
        BaseDB<Miscellaneous> baseDB;
        public MiscellaneousService() {
            baseDB = new BaseDB<Miscellaneous>();
        }
        public Miscellaneous Add(Miscellaneous entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(Miscellaneous entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<Miscellaneous> GetAll()
        {
            return baseDB.GetAll().ToList();
        }

        public Miscellaneous GetById(int id)
        {
            return baseDB.GetById(id);
        }

        public Miscellaneous Update(Miscellaneous entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}