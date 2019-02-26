using SecondSightSouthendEyeCentre.Data.DbIntractions;
using SecondSightWeb.Models;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Service.Implementation
{
    public class SurgicalInjectableConsumptionListService : ISurgicalInjectableConsumptionListService
    {
        BaseDB<SurgicalInjectableConsumptionList> baseDB;
        public SurgicalInjectableConsumptionListService()
        {
            baseDB = new BaseDB<SurgicalInjectableConsumptionList>();
        }
        public SurgicalInjectableConsumptionList Add(SurgicalInjectableConsumptionList entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(SurgicalInjectableConsumptionList entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<SurgicalInjectableConsumptionList> GetAll()
        {
            return baseDB.GetAll().ToList();
        }

        public SurgicalInjectableConsumptionList GetById(int id)
        {
            return baseDB.GetById(id);
        }

        public SurgicalInjectableConsumptionList Update(SurgicalInjectableConsumptionList entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}