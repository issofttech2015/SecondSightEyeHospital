using SecondSightSouthendEyeCentre.Data.DbIntractions;
using SecondSightWeb.Models;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Service.Implementation
{
    public class DisposablesService : IDisposablesService
    {
        BaseDB<Disposables> baseDB;
        public DisposablesService()
        {
            baseDB = new BaseDB<Disposables>();
        }
        public Disposables Add(Disposables entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(Disposables entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<Disposables> GetAll()
        {
            return baseDB.GetAll().ToList();
        }

        public Disposables GetById(int id)
        {
            return baseDB.GetById(id);
        }

        public Disposables Update(Disposables entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}