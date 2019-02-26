using SecondSightSouthendEyeCentre.Data.DbIntractions;
using SecondSightWeb.Models;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Service.Implementation
{
    public class DossListSummaryService : IDossListSummaryService
    {
        BaseDB<DossListSummary> baseDB;
        public DossListSummaryService()
        {
            baseDB = new BaseDB<DossListSummary>();
        }
        public DossListSummary Add(DossListSummary entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(DossListSummary entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<DossListSummary> GetAll()
        {
            return baseDB.GetAll().ToList();
        }

        public DossListSummary GetById(int id)
        {
            return baseDB.GetById(id);
        }

        public DossListSummary Update(DossListSummary entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}