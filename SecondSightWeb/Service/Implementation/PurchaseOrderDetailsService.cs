using SecondSightSouthendEyeCentre.Data.DbIntractions;
using SecondSightWeb.Models;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Service.Implementation
{
    public class PurchaseOrderDetailsService : IPurchaseOrderDetailsService
    {
        BaseDB<PurchaseOrderDetails> baseDB;
        public PurchaseOrderDetailsService()
        {
            baseDB = new BaseDB<PurchaseOrderDetails>();
        }
        public PurchaseOrderDetails Add(PurchaseOrderDetails entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(PurchaseOrderDetails entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<PurchaseOrderDetails> GetAll()
        {
            return baseDB.GetAll().ToList();
        }

        public PurchaseOrderDetails GetById(int id)
        {
            return baseDB.GetById(id);
        }

        public PurchaseOrderDetails Update(PurchaseOrderDetails entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}