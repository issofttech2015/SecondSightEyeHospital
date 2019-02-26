using SecondSightSouthendEyeCentre.Data.DbIntractions;
using SecondSightWeb.Models;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Service.Implementation
{
    public class OperationSuggestionService : IOperationSuggestionService
    {
        BaseDB<OperationSuggestion> baseDB;
        public OperationSuggestionService()
        {
            baseDB = new BaseDB<OperationSuggestion>();
        }
        public OperationSuggestion Add(OperationSuggestion entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(OperationSuggestion entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<OperationSuggestion> GetAll()
        {
            return baseDB.GetAll().ToList(); 
        }

        public OperationSuggestion GetById(int id)
        {
            return baseDB.GetById(id);
        }

        public OperationSuggestion Update(OperationSuggestion entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}