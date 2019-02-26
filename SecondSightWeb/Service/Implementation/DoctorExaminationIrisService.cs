using SecondSightSouthendEyeCentre.Data.DbIntractions;
using SecondSightWeb.Models;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Service.Implementation
{
    public class DoctorExaminationIrisService : IDoctorExaminationIrisService
    {
        BaseDB<DoctorExaminationIris> baseDB;
        public DoctorExaminationIrisService()
        {
            baseDB = new BaseDB<DoctorExaminationIris>();
        }
        public DoctorExaminationIris Add(DoctorExaminationIris entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(DoctorExaminationIris entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<DoctorExaminationIris> GetAll()
        {
            return baseDB.GetAll().ToList();
        }

        public DoctorExaminationIris GetById(int id)
        {
            return baseDB.GetById(id);
        }

        public DoctorExaminationIris Update(DoctorExaminationIris entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}