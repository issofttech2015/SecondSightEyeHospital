using SecondSightSouthendEyeCentre.Data.DbIntractions;
using SecondSightWeb.Models;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Service.Implementation
{
    public class MedicineListService : IMedicineListService
    {
        BaseDB<MedicineList> baseDB;

        public MedicineListService()
        {
            baseDB = new BaseDB<MedicineList>();
        }
        public MedicineList Add(MedicineList entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }
        public bool Delete(MedicineList entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<MedicineList> GetAll()
        {
            return baseDB.GetAll().ToList();
        }

        public MedicineList GetById(int id)
        {
            return baseDB.GetById(id);
        }

        public MedicineList Update(MedicineList entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}