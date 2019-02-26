using SecondSightSouthendEyeCentre.Data.DbIntractions;
using SecondSightSouthendEyeCentre.Models;
using SecondSightWeb.Models;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Service.Implementation
{
    public class PaymentDetalisService : IPaymentDetalisService
    {
        BaseDB<Models.PaymentDetalis> baseDB;
        BaseDB<Bill> baseDBBill;
        public PaymentDetalisService()
        {
            baseDB = new BaseDB<Models.PaymentDetalis>();
            baseDBBill = new BaseDB<Bill>();
        }
        public PaymentDetalis Add(PaymentDetalis entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(PaymentDetalis entity)
        {

            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<PaymentDetalis> GetAll()
        {
            return baseDB.GetAll().ToList();
        }

        public PaymentDetalis GetById(int id)
        {
            return baseDB.GetById(id);
        }

        public PaymentDetalis Update(PaymentDetalis entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}