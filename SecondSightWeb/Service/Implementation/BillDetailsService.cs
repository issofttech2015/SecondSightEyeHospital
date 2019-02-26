using SecondSightSouthendEyeCentre.Data.DbIntractions;
using SecondSightWeb.Models;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Service.Implementation
{
    public class BillDetailsService : IBillDetailsService
    {
        BaseDB<BillDetails> baseDB;
        public BillDetailsService()
        {
            baseDB = new BaseDB<BillDetails>();
        }
        public BillDetails Add(BillDetails entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(BillDetails entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<BillDetails> GetAll()
        {
            return baseDB.GetAll().ToList();
        }

        public BillDetails GetById(int id)
        {
            return baseDB.GetById(id);
        }

        public BillDetails Update(BillDetails entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}