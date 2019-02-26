using SecondSightSouthendEyeCentre.Data.DbIntractions;
using SecondSightWeb.Models;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Service.Implementation
{
    public class PastOcularHistoryService : IPastOcularHistoryService
    {
        BaseDB<PastOcularHistory> baseDB;
        public PastOcularHistoryService()
        {
            baseDB = new BaseDB<PastOcularHistory>();
        }
        public PastOcularHistory Add(PastOcularHistory entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(PastOcularHistory entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<PastOcularHistory> GetAll()
        {
            return baseDB.GetAll().ToList();
        }

        public PastOcularHistory GetById(int id)
        {
            return baseDB.GetById(id);
        }

        public PastOcularHistory Update(PastOcularHistory entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}