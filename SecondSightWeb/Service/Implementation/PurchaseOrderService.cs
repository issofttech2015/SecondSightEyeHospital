using SecondSightSouthendEyeCentre.Data.DbIntractions;
using SecondSightWeb.Models;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Service.Implementation
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        BaseDB<PurchaseOrder> baseDB;
        public PurchaseOrderService()
        {
            baseDB = new BaseDB<PurchaseOrder>();
        }
        public PurchaseOrder Add(PurchaseOrder entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(PurchaseOrder entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<PurchaseOrder> GetAll()
        {
            return baseDB.GetAll().ToList();
        }

        public PurchaseOrder GetById(int id)
        {
            return baseDB.GetById(id);
        }

        public PurchaseOrder Update(PurchaseOrder entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}