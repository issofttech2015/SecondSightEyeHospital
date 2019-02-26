using SecondSightSouthendEyeCentre.Data.DbIntractions;
using SecondSightWeb.Models;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Service.Implementation
{
    public class CheifComplainByExaminationService : ICheifComplainByExaminationService
    {
        BaseDB<CheifComplainByExamination> baseDB;
        public CheifComplainByExaminationService()
        {
            baseDB = new BaseDB<CheifComplainByExamination>();
        }
        public CheifComplainByExamination Add(CheifComplainByExamination entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(CheifComplainByExamination entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<CheifComplainByExamination> GetAll()
        {
            return baseDB.GetAll().ToList();
        }

        public CheifComplainByExamination GetById(int id)
        {
            return baseDB.GetById(id);
        }

        public CheifComplainByExamination Update(CheifComplainByExamination entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}