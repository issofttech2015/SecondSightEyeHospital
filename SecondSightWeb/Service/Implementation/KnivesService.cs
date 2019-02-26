using SecondSightSouthendEyeCentre.Data.DbIntractions;
using SecondSightWeb.Models;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Service.Implementation
{
    public class KnivesService : IKnivesService
    {
        BaseDB<Knives> baseDB;
        public KnivesService()
        {
            baseDB = new BaseDB<Knives>();
        }
        public Knives Add(Knives entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(Knives entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<Knives> GetAll()
        {
            return baseDB.GetAll().ToList();
        }

        public Knives GetById(int id)
        {
            return baseDB.GetById(id);
        }

        public Knives Update(Knives entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}