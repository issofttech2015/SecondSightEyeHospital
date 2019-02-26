using SecondSightSouthendEyeCentre.Data.DbIntractions;
using SecondSightWeb.Models;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Service.Implementation
{
    public class DoctorExaminationDiagnosisService : IDoctorExaminationDiagnosisService
    {
        BaseDB<DoctorExaminationDiagnosis> baseDB;
        public DoctorExaminationDiagnosisService()
        {
            baseDB = new BaseDB<DoctorExaminationDiagnosis>();
        }
        public DoctorExaminationDiagnosis Add(DoctorExaminationDiagnosis entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(DoctorExaminationDiagnosis entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<DoctorExaminationDiagnosis> GetAll()
        {
            return baseDB.GetAll().ToList();
        }

        public DoctorExaminationDiagnosis GetById(int id)
        {
            return baseDB.GetById(id);
        }

        public DoctorExaminationDiagnosis Update(DoctorExaminationDiagnosis entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}