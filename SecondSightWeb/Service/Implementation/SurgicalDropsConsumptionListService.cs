using SecondSightSouthendEyeCentre.Data.DbIntractions;
using SecondSightWeb.Models;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Service.Implementation
{
    public class SurgicalDropsConsumptionListService : ISurgicalDropsConsumptionListService
    {
        BaseDB<SurgicalDropsConsumptionList> baseDB;
        public SurgicalDropsConsumptionListService()
        {
            baseDB = new BaseDB<SurgicalDropsConsumptionList>();
        }
        public SurgicalDropsConsumptionList Add(SurgicalDropsConsumptionList entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(SurgicalDropsConsumptionList entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<SurgicalDropsConsumptionList> GetAll()
        {
            return baseDB.GetAll().ToList();
        }

        public SurgicalDropsConsumptionList GetById(int id)
        {
            return baseDB.GetById(id);
        }

        public SurgicalDropsConsumptionList Update(SurgicalDropsConsumptionList entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}