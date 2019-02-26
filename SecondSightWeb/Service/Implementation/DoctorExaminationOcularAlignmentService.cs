using SecondSightSouthendEyeCentre.Data.DbIntractions;
using SecondSightWeb.Models;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Service.Implementation
{
    public class DoctorExaminationOcularAlignmentService : IDoctorExaminationOcularAlignmentService
    {
        BaseDB<DoctorExaminationOcularAlignment> baseDB;
        public DoctorExaminationOcularAlignmentService()
        {
            baseDB = new BaseDB<DoctorExaminationOcularAlignment>();
        }
        public DoctorExaminationOcularAlignment Add(DoctorExaminationOcularAlignment entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(DoctorExaminationOcularAlignment entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<DoctorExaminationOcularAlignment> GetAll()
        {
            return baseDB.GetAll().ToList();
        }

        public DoctorExaminationOcularAlignment GetById(int id)
        {
            return baseDB.GetById(id);
        }

        public DoctorExaminationOcularAlignment Update(DoctorExaminationOcularAlignment entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}