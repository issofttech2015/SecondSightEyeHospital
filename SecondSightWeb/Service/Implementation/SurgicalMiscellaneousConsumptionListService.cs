using SecondSightSouthendEyeCentre.Data.DbIntractions;
using SecondSightWeb.Models;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Service.Implementation
{
    public class SurgicalMiscellaneousConsumptionListService : ISurgicalMiscellaneousConsumptionListService
    {
        BaseDB<SurgicalMiscellaneousConsumptionList> baseDB;
        public SurgicalMiscellaneousConsumptionListService()
        {
            baseDB = new BaseDB<SurgicalMiscellaneousConsumptionList>();
        }
        public SurgicalMiscellaneousConsumptionList Add(SurgicalMiscellaneousConsumptionList entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(SurgicalMiscellaneousConsumptionList entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<SurgicalMiscellaneousConsumptionList> GetAll()
        {
            return baseDB.GetAll().ToList();
        }

        public SurgicalMiscellaneousConsumptionList GetById(int id)
        {
            return baseDB.GetById(id);
        }

        public SurgicalMiscellaneousConsumptionList Update(SurgicalMiscellaneousConsumptionList entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}