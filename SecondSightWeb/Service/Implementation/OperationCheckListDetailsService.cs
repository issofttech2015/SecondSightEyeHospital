using SecondSightSouthendEyeCentre.Data.DbIntractions;
using SecondSightWeb.Models;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Service.Implementation
{
    public class OperationCheckListDetailsService : IOperationCheckListDetailsService
    {
        BaseDB<OperationCheckListDetails> baseDB;
        public OperationCheckListDetailsService()
        {
            baseDB = new BaseDB<OperationCheckListDetails>();
        }
        public OperationCheckListDetails Add(OperationCheckListDetails entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(OperationCheckListDetails entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<OperationCheckListDetails> GetAll()
        {
            return baseDB.GetAll().ToList();
        }

        public OperationCheckListDetails GetById(int id)
        {
            return baseDB.GetById(id);
        }

        public OperationCheckListDetails Update(OperationCheckListDetails entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}