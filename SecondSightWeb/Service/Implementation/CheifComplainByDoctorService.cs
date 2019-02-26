using SecondSightSouthendEyeCentre.Data.DbIntractions;
using SecondSightWeb.Models;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Service.Implementation
{
    public class CheifComplainByDoctorService : ICheifComplainByDoctorService
    {
        BaseDB<CheifComplainByDoctor> baseDB;
        public CheifComplainByDoctorService()
        {
            baseDB = new BaseDB<CheifComplainByDoctor>();
        }

        public CheifComplainByDoctor Add(CheifComplainByDoctor entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(CheifComplainByDoctor entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<CheifComplainByDoctor> GetAll()
        {
            return baseDB.GetAll().ToList();
        }

        public CheifComplainByDoctor GetById(int id)
        {
            return baseDB.GetById(id);
        }

        public CheifComplainByDoctor Update(CheifComplainByDoctor entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}