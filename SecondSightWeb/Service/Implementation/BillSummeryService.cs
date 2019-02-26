using SecondSightSouthendEyeCentre.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecondSightSouthendEyeCentre.Models;
using SecondSightSouthendEyeCentre.Data.DbIntractions;

namespace SecondSightSouthendEyeCentre.Service.Implementation
{
    public class BillSummeryService : IBillSummeryService
    {
        BaseDB<BillSummery> baseDB;
        public BillSummeryService()
        {
            baseDB = new BaseDB<BillSummery>();
        }
        public BillSummery Add(BillSummery entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(BillSummery entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<BillSummery> GetAll()
        {
            return baseDB.GetAll().ToList();
        }

        public BillSummery GetById(int id)
        {
            return baseDB.GetById(id);
        }

        public BillSummery Update(BillSummery entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}
