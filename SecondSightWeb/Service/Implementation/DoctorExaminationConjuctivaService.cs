using SecondSightSouthendEyeCentre.Data.DbIntractions;
using SecondSightWeb.Models;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Service.Implementation
{
    public class DoctorExaminationConjuctivaService : IDoctorExaminationConjuctivaService
    {
        BaseDB<DoctorExaminationConjuctiva> baseDB;
        public DoctorExaminationConjuctivaService()
        {
            baseDB = new BaseDB<DoctorExaminationConjuctiva>();
        }
        public DoctorExaminationConjuctiva Add(DoctorExaminationConjuctiva entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(DoctorExaminationConjuctiva entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<DoctorExaminationConjuctiva> GetAll()
        {
            return baseDB.GetAll().ToList();
        }

        public DoctorExaminationConjuctiva GetById(int id)
        {
            return baseDB.GetById(id);
        }

        public DoctorExaminationConjuctiva Update(DoctorExaminationConjuctiva entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}