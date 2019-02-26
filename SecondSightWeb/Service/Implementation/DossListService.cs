using SecondSightSouthendEyeCentre.Data.DbIntractions;
using SecondSightWeb.Models;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Service.Implementation
{
    public class DossListService : IDossListService
    {
        BaseDB<DossList> baseDB;
        public DossListService()
        {
            baseDB = new BaseDB<DossList>();
        }
        
        public DossList Add(DossList entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(DossList entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<DossList> GetAll()
        {
            return baseDB.GetAll().ToList();
        }

        public DossList GetById(int id)
        {
            return baseDB.GetById(id);
        }

        public DossList Update(DossList entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}