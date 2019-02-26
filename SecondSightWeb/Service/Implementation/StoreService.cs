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
    public class StoreService : IStoreService
    {
        BaseDB<Store> baseDB;
        public StoreService()
        {
            baseDB = new BaseDB<Store>();
        }
        public Store Add(Store entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(Store entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<Store> GetAll()
        {
            return baseDB.GetAll().ToList();

        }

        public Store GetById(int id)
        {
            return baseDB.GetById(id);

        }

        public Store Update(Store entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}
