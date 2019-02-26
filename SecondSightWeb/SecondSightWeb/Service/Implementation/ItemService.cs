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
    public class ItemService : IItemService
    {
        BaseDB<Item> baseDB;
        public ItemService()
        {
            baseDB = new BaseDB<Item>();
        }
        public Item Add(Item entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(Item entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<Item> GetAll()
        {
            return baseDB.GetAll().ToList();

        }

        public Item GetById(int id)
        {
            return baseDB.GetById(id);

        }

        public Item Update(Item entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}
