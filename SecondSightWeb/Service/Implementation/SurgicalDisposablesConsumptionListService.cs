using SecondSightSouthendEyeCentre.Data.DbIntractions;
using SecondSightWeb.Models;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Service.Implementation
{
    public class SurgicalDisposablesConsumptionListService : ISurgicalDisposablesConsumptionListService
    {
        BaseDB<SurgicalDisposablesConsumptionList> baseDB;
        public SurgicalDisposablesConsumptionListService()
        {
            baseDB = new BaseDB<SurgicalDisposablesConsumptionList>();
        }
        public SurgicalDisposablesConsumptionList Add(SurgicalDisposablesConsumptionList entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(SurgicalDisposablesConsumptionList entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<SurgicalDisposablesConsumptionList> GetAll()
        {
            return baseDB.GetAll().ToList();
        }

        public SurgicalDisposablesConsumptionList GetById(int id)
        {
            return baseDB.GetById(id);
        }

        public SurgicalDisposablesConsumptionList Update(SurgicalDisposablesConsumptionList entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}