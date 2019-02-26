using SecondSightSouthendEyeCentre.Data.DbIntractions;
using SecondSightSouthendEyeCentre.Models;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Service.Implementation
{
    public class ExaminationDropsService : IExaminationDropsService
    {
        BaseDB<ExaminationDrops> baseDB;
        public ExaminationDropsService()
        {
            baseDB = new BaseDB<ExaminationDrops>();
        }
        public ExaminationDrops Add(ExaminationDrops entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(ExaminationDrops entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<ExaminationDrops> GetAll()
        {
            return baseDB.GetAll().ToList();
        }

        public ExaminationDrops GetById(int id)
        {
            return baseDB.GetById(id);
        }

        public ExaminationDrops Update(ExaminationDrops entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}