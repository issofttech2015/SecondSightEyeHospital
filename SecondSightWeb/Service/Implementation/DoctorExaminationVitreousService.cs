using SecondSightSouthendEyeCentre.Data.DbIntractions;
using SecondSightWeb.Models;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Service.Implementation
{
    public class DoctorExaminationVitreousService : IDoctorExaminationVitreousService
    {
        BaseDB<DoctorExaminationVitreous> baseDB;
        public DoctorExaminationVitreousService()
        {
            baseDB = new BaseDB<DoctorExaminationVitreous>();
        }
        public DoctorExaminationVitreous Add(DoctorExaminationVitreous entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(DoctorExaminationVitreous entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<DoctorExaminationVitreous> GetAll()
        {
            return baseDB.GetAll().ToList();
        }

        public DoctorExaminationVitreous GetById(int id)
        {
            return baseDB.GetById(id);
        }

        public DoctorExaminationVitreous Update(DoctorExaminationVitreous entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}