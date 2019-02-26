using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SecondSightSouthendEyeCentre.Data.DbIntractions;
using SecondSightWeb.Service.Interfaces;
using SecondSightWeb.Models;

namespace SecondSightWeb.Service.Implementation
{
    public class InjectablesService : IInjectablesService
    {
        BaseDB<Injectables> baseDB;
        public InjectablesService()
        {
            baseDB = new BaseDB<Injectables>();
        }
        public Injectables Add(Injectables entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(Injectables entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<Injectables> GetAll()
        {
            return baseDB.GetAll().ToList();
        }

        public Injectables GetById(int id)
        {
            return baseDB.GetById(id);
        }

        public Injectables Update(Injectables entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}