using SecondSightSouthendEyeCentre.Data.DbIntractions;
using SecondSightWeb.Models;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Service.Implementation
{
    public class SurgicalKnivesConsumptionListService : ISurgicalKnivesConsumptionListService
    {
        BaseDB<SurgicalKnivesConsumptionList> baseDB;
        public SurgicalKnivesConsumptionListService()
        {
            baseDB = new BaseDB<SurgicalKnivesConsumptionList>();
        }
        public SurgicalKnivesConsumptionList Add(SurgicalKnivesConsumptionList entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(SurgicalKnivesConsumptionList entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<SurgicalKnivesConsumptionList> GetAll()
        {
            return baseDB.GetAll().ToList();
        }

        public SurgicalKnivesConsumptionList GetById(int id)
        {
            return baseDB.GetById(id);
        }

        public SurgicalKnivesConsumptionList Update(SurgicalKnivesConsumptionList entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}