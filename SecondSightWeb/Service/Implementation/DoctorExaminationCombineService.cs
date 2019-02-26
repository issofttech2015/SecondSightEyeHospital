using SecondSightSouthendEyeCentre.Data.DbIntractions;
using SecondSightWeb.Models;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Service.Implementation
{
    public class DoctorExaminationCombineService : IDoctorExaminationCombineService
    {
        BaseDB<DoctorExaminationCombine> baseDB;
        public DoctorExaminationCombineService()
        {
            baseDB = new BaseDB<DoctorExaminationCombine>();
        }
        public DoctorExaminationCombine Add(DoctorExaminationCombine entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(DoctorExaminationCombine entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<DoctorExaminationCombine> GetAll()
        {
            return baseDB.GetAll().ToList();
        }

        public DoctorExaminationCombine GetById(int id)
        {
            return baseDB.GetById(id);
        }

        public DoctorExaminationCombine Update(DoctorExaminationCombine entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}