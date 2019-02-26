using SecondSightSouthendEyeCentre.Data.DbIntractions;
using SecondSightWeb.Models;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Service.Implementation
{
    public class DoctorExaminationOculerMovementService : IDoctorExaminationOculerMovementService
    {
        BaseDB<DoctorExaminationOculerMovement> baseDB;
        public DoctorExaminationOculerMovementService()
        {
            baseDB = new BaseDB<DoctorExaminationOculerMovement>();
        }
        public DoctorExaminationOculerMovement Add(DoctorExaminationOculerMovement entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(DoctorExaminationOculerMovement entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<DoctorExaminationOculerMovement> GetAll()
        {
            return baseDB.GetAll().ToList();
        }

        public DoctorExaminationOculerMovement GetById(int id)
        {
            return baseDB.GetById(id);
        }

        public DoctorExaminationOculerMovement Update(DoctorExaminationOculerMovement entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}