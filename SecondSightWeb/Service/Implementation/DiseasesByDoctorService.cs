using SecondSightSouthendEyeCentre.Data.DbIntractions;
using SecondSightWeb.Models;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Service.Implementation
{
    public class DiseasesByDoctorService : IDiseasesByDoctorService
    {
        BaseDB<DiseasesByDoctor> baseDB;
        public DiseasesByDoctorService()
        {
            baseDB = new BaseDB<DiseasesByDoctor>();
        }

        public DiseasesByDoctor Add(DiseasesByDoctor entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(DiseasesByDoctor entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<DiseasesByDoctor> GetAll()
        {
            return baseDB.GetAll().ToList();
        }

        public DiseasesByDoctor GetById(int id)
        {
            return baseDB.GetById(id);
        }

        public DiseasesByDoctor Update(DiseasesByDoctor entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}