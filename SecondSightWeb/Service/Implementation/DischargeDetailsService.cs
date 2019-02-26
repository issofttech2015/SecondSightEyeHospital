using SecondSightSouthendEyeCentre.Data.DbIntractions;
using SecondSightWeb.Models;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Service.Implementation
{
    public class DischargeDetailsService : IDischargeDetailsService
    {
        BaseDB<DischargeDetails> baseDB;
        public DischargeDetailsService()
        {
            baseDB = new BaseDB<DischargeDetails>();
        }
        public DischargeDetails Add(DischargeDetails entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(DischargeDetails entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<DischargeDetails> GetAll()
        {
            return baseDB.GetAll().ToList();
        }

        public DischargeDetails GetById(int id)
        {
            return baseDB.GetById(id);
        }

        public DischargeDetails Update(DischargeDetails entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}