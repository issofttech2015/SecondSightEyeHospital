using SecondSightSouthendEyeCentre.Data.DbIntractions;
using SecondSightWeb.Models;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Service.Implementation
{
    public class RefundBillDetailsService : IRefundBillDetailsService
    {
        BaseDB<RefundBillDetails> baseDB;
        public RefundBillDetailsService()
        {
            baseDB = new BaseDB<RefundBillDetails>();
        }
        public RefundBillDetails Add(RefundBillDetails entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(RefundBillDetails entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<RefundBillDetails> GetAll()
        {
            return baseDB.GetAll().ToList();
        }

        public RefundBillDetails GetById(int id)
        {
            return baseDB.GetById(id);
        }

        public RefundBillDetails Update(RefundBillDetails entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}