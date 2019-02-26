using SecondSightSouthendEyeCentre.Data.DbIntractions;
using SecondSightWeb.Models;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Service.Implementation
{
    public class SuggestedTestsService : ISuggestedTestsService
    {
        BaseDB<SuggestedTests> baseDB;
        public SuggestedTestsService()
        {
            baseDB = new BaseDB<SuggestedTests>();
        }
        public SuggestedTests Add(SuggestedTests entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(SuggestedTests entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<SuggestedTests> GetAll()
        {
            return baseDB.GetAll().ToList();
        }

        public SuggestedTests GetById(int id)
        {
            return baseDB.GetById(id);
        }

        public SuggestedTests Update(SuggestedTests entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}