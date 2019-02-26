using SecondSightSouthendEyeCentre.Data.DbIntractions;
using SecondSightWeb.Models;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Service.Implementation
{
    public class DoctorExaminationFundusService : IDoctorExaminationFundusService
    {
        BaseDB<DoctorExaminationFundus> baseDB;
        public DoctorExaminationFundusService()
        {
            baseDB = new BaseDB<DoctorExaminationFundus>();
        }
        public DoctorExaminationFundus Add(DoctorExaminationFundus entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(DoctorExaminationFundus entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<DoctorExaminationFundus> GetAll()
        {
            return baseDB.GetAll().ToList();
        }

        public DoctorExaminationFundus GetById(int id)
        {
            return baseDB.GetById(id);
        }

        public DoctorExaminationFundus Update(DoctorExaminationFundus entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}