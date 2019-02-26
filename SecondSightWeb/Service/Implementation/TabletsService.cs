using SecondSightSouthendEyeCentre.Data.DbIntractions;
using SecondSightWeb.Models;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Service.Implementation
{
    public class TabletsService : ITabletsService
    {
        BaseDB<Tablets> baseDB;
        public TabletsService()
        {
            baseDB = new BaseDB<Tablets>();
        }
        public Tablets Add(Tablets entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(Tablets entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<Tablets> GetAll()
        {
            return baseDB.GetAll().ToList();
        }

        public Tablets GetById(int id)
        {
            return baseDB.GetById(id);
        }

        public Tablets Update(Tablets entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}