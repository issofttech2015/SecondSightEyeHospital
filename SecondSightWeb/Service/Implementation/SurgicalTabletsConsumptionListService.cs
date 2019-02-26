using SecondSightSouthendEyeCentre.Data.DbIntractions;
using SecondSightWeb.Models;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Service.Implementation
{
    public class SurgicalTabletsConsumptionListService : ISurgicalTabletsConsumptionListService
    {
        BaseDB<SurgicalTabletsConsumptionList> baseDB;
        public SurgicalTabletsConsumptionListService()
        {
            baseDB = new BaseDB<SurgicalTabletsConsumptionList>();
        }
        public SurgicalTabletsConsumptionList Add(SurgicalTabletsConsumptionList entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(SurgicalTabletsConsumptionList entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<SurgicalTabletsConsumptionList> GetAll()
        {
            return baseDB.GetAll().ToList();
        }

        public SurgicalTabletsConsumptionList GetById(int id)
        {
            return baseDB.GetById(id);
        }

        public SurgicalTabletsConsumptionList Update(SurgicalTabletsConsumptionList entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}