using SecondSightSouthendEyeCentre.Data.DbIntractions;
using SecondSightWeb.Models;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Service.Implementation
{
    public class RefundBillService : IRefundBillService
    {
        BaseDB<RefundBill> baseDB;
        public RefundBillService()
        {
            baseDB = new BaseDB<RefundBill>();
        }
        public RefundBill Add(RefundBill entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(RefundBill entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<RefundBill> GetAll()
        {
            return baseDB.GetAll().ToList();
        }

        public RefundBill GetById(int id)
        {
            return baseDB.GetById(id);
        }

        public RefundBill Update(RefundBill entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}