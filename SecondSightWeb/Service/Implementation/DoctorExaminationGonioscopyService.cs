using SecondSightSouthendEyeCentre.Data.DbIntractions;
using SecondSightWeb.Models;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Service.Implementation
{
    public class DoctorExaminationGonioscopyService : IDoctorExaminationGonioscopyService
    {
        BaseDB<DoctorExaminationGonioscopy> baseDB;
        public DoctorExaminationGonioscopyService()
        {
            baseDB = new BaseDB<DoctorExaminationGonioscopy>();
        }
        public DoctorExaminationGonioscopy Add(DoctorExaminationGonioscopy entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(DoctorExaminationGonioscopy entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<DoctorExaminationGonioscopy> GetAll()
        {
            return baseDB.GetAll().ToList();
        }

        public DoctorExaminationGonioscopy GetById(int id)
        {
            return baseDB.GetById(id);
        }

        public DoctorExaminationGonioscopy Update(DoctorExaminationGonioscopy entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}