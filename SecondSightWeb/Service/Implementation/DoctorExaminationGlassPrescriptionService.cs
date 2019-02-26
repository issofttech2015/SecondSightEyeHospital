using SecondSightSouthendEyeCentre.Data.DbIntractions;
using SecondSightWeb.Models;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Service.Implementation
{
    public class DoctorExaminationGlassPrescriptionService : IDoctorExaminationGlassPrescriptionService
    {
        BaseDB<DoctorExaminationGlassPrescription> baseDB;
        public DoctorExaminationGlassPrescriptionService()
        {
            baseDB = new BaseDB<DoctorExaminationGlassPrescription>();
        }
        public DoctorExaminationGlassPrescription Add(DoctorExaminationGlassPrescription entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(DoctorExaminationGlassPrescription entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<DoctorExaminationGlassPrescription> GetAll()
        {
            return baseDB.GetAll().ToList();
        }

        public DoctorExaminationGlassPrescription GetById(int id)
        {
            return baseDB.GetById(id);
        }

        public DoctorExaminationGlassPrescription Update(DoctorExaminationGlassPrescription entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}