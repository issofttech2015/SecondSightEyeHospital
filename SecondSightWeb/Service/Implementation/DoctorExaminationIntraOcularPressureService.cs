using SecondSightSouthendEyeCentre.Data.DbIntractions;
using SecondSightWeb.Models;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Service.Implementation
{
    public class DoctorExaminationIntraOcularPressureService : IDoctorExaminationIntraOcularPressureService
    {
        BaseDB<DoctorExaminationIntraOcularPressure> baseDB;
        public DoctorExaminationIntraOcularPressureService()
        {
            baseDB = new BaseDB<DoctorExaminationIntraOcularPressure>();
        }
        public DoctorExaminationIntraOcularPressure Add(DoctorExaminationIntraOcularPressure entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(DoctorExaminationIntraOcularPressure entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<DoctorExaminationIntraOcularPressure> GetAll()
        {
            return baseDB.GetAll().ToList();
        }

        public DoctorExaminationIntraOcularPressure GetById(int id)
        {
            return baseDB.GetById(id);
        }

        public DoctorExaminationIntraOcularPressure Update(DoctorExaminationIntraOcularPressure entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}