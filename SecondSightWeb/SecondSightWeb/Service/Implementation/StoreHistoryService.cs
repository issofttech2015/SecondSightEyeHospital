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
    public class StoreHistoryService : IStoreHistoryService
    {
        BaseDB<StoreHistory> baseDB;
        public StoreHistoryService()
        {
            baseDB = new BaseDB<StoreHistory>();
        }
        public StoreHistory Add(StoreHistory entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(StoreHistory entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<StoreHistory> GetAll()
        {
            return baseDB.GetAll().ToList();

        }

        public StoreHistory GetById(int id)
        {
            return baseDB.GetById(id);

        }

        public StoreHistory Update(StoreHistory entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}
