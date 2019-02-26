using SecondSightSouthendEyeCentre.Data.DbIntractions;
using SecondSightWeb.Models;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Service.Implementation
{
    public class PastMedicalHistoryService : IPastMedicalHistoryService
    {
        BaseDB<PastMedicalHistory> baseDB;
        public PastMedicalHistoryService()
        {
            baseDB = new BaseDB<PastMedicalHistory>();
        }
        public PastMedicalHistory Add(PastMedicalHistory entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(PastMedicalHistory entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<PastMedicalHistory> GetAll()
        {
            return baseDB.GetAll().ToList();
        }

        public PastMedicalHistory GetById(int id)
        {
            return baseDB.GetById(id);
        }

        public PastMedicalHistory Update(PastMedicalHistory entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}