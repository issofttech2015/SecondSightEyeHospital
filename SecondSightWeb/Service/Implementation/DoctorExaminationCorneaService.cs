using SecondSightSouthendEyeCentre.Data.DbIntractions;
using SecondSightWeb.Models;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Service.Implementation
{
    public class DoctorExaminationCorneaService : IDoctorExaminationCorneaService
    {
        BaseDB<DoctorExaminationCornea> baseDB;
        public DoctorExaminationCorneaService()
        {
            baseDB = new BaseDB<DoctorExaminationCornea>();
        }
        public DoctorExaminationCornea Add(DoctorExaminationCornea entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(DoctorExaminationCornea entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<DoctorExaminationCornea> GetAll()
        {
            return baseDB.GetAll().ToList();
        }

        public DoctorExaminationCornea GetById(int id)
        {
            return baseDB.GetById(id);
        }

        public DoctorExaminationCornea Update(DoctorExaminationCornea entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}