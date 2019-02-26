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
    public class BillService : IBillService
    {
        BaseDB<Bill> baseDB;
        public BillService()
        {
            baseDB = new BaseDB<Bill>();
        }
        public Bill Add(Bill entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(Bill entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<Bill> GetAll()
        {
            return baseDB.GetAll().ToList();
        }

        public Bill GetById(int id)
        {
            return baseDB.GetById(id);

        }

        public Bill Update(Bill entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}
