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
    public class SupplierService : ISupplierService
    {
        BaseDB<Supplier> baseDB;
        public SupplierService()
        {
            baseDB = new BaseDB<Supplier>();
        }
        public Supplier Add(Supplier entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(Supplier entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<Supplier> GetAll()
        {
            return baseDB.GetAll().ToList();
        }

        public Supplier GetById(int id)
        {
            return baseDB.GetById(id);
        }

        public Supplier Update(Supplier entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}
