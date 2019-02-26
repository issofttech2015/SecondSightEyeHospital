using SecondSightSouthendEyeCentre.Data.DbIntractions;
using SecondSightWeb.Models;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Service.Implementation
{
    public class DoctorExaminationFollowUpService : IDoctorExaminationFollowUpService
    {
        BaseDB<DoctorExaminationFollowUp> baseDB;
        public DoctorExaminationFollowUpService()
        {
            baseDB = new BaseDB<DoctorExaminationFollowUp>();
        }
        public DoctorExaminationFollowUp Add(DoctorExaminationFollowUp entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(DoctorExaminationFollowUp entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<DoctorExaminationFollowUp> GetAll()
        {
            return baseDB.GetAll().ToList();
        }

        public DoctorExaminationFollowUp GetById(int id)
        {
            return baseDB.GetById(id);
        }

        public DoctorExaminationFollowUp Update(DoctorExaminationFollowUp entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}