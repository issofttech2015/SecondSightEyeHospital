using SecondSightSouthendEyeCentre.Data.DbIntractions;
using SecondSightWeb.Models;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Service.Implementation
{
    public class MedicineTypeListService : IMedicineTypeListService
    {
        BaseDB<MedicineTypeList> baseDB;
        public MedicineTypeListService()
        {
            baseDB = new BaseDB<MedicineTypeList>();
        }
        public MedicineTypeList Add(MedicineTypeList entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(MedicineTypeList entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<MedicineTypeList> GetAll()
        {
            return baseDB.GetAll().ToList();
        }

        public MedicineTypeList GetById(int id)
        {
            return baseDB.GetById(id);
        }

        public MedicineTypeList Update(MedicineTypeList entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}