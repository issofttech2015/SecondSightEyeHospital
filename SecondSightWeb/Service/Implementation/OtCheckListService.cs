using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SecondSightWeb.Models;
using SecondSightSouthendEyeCentre.Data.DbIntractions;

namespace SecondSightWeb.Service.Implementation
{
    public class OtCheckListService : IOtCheckListService
    {
        BaseDB<OtCheckList> baseDB;
        public OtCheckListService()
        {
            baseDB = new BaseDB<OtCheckList>();
        }
        public OtCheckList Add(OtCheckList entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(OtCheckList entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<OtCheckList> GetAll()
        {
            return baseDB.GetAll().ToList();
        }

        public OtCheckList GetById(int id)
        {
            return baseDB.GetById(id);
        }

        public OtCheckList Update(OtCheckList entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}