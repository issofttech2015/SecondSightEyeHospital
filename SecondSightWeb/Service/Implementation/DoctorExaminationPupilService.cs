using SecondSightSouthendEyeCentre.Data.DbIntractions;
using SecondSightWeb.Models;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Service.Implementation
{
    public class DoctorExaminationPupilService : IDoctorExaminationPupilService
    {
        BaseDB<DoctorExaminationPupil> baseDB;
        public DoctorExaminationPupilService()
        {
            baseDB = new BaseDB<DoctorExaminationPupil>();
        }
        public DoctorExaminationPupil Add(DoctorExaminationPupil entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(DoctorExaminationPupil entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<DoctorExaminationPupil> GetAll()
        {
            return baseDB.GetAll().ToList();
        }

        public DoctorExaminationPupil GetById(int id)
        {
            return baseDB.GetById(id);
        }

        public DoctorExaminationPupil Update(DoctorExaminationPupil entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}