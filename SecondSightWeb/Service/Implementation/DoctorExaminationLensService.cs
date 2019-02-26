using SecondSightSouthendEyeCentre.Data.DbIntractions;
using SecondSightWeb.Models;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Service.Implementation
{
    public class DoctorExaminationLensService : IDoctorExaminationLensService
    {
        BaseDB<DoctorExaminationLens> baseDB;
        public DoctorExaminationLensService()
        {
            baseDB = new BaseDB<DoctorExaminationLens>();
        }
        public DoctorExaminationLens Add(DoctorExaminationLens entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(DoctorExaminationLens entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<DoctorExaminationLens> GetAll()
        {
            return baseDB.GetAll().ToList();
        }

        public DoctorExaminationLens GetById(int id)
        {
            return baseDB.GetById(id);
        }

        public DoctorExaminationLens Update(DoctorExaminationLens entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}