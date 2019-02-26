using SecondSightSouthendEyeCentre.Data.DbIntractions;
using SecondSightWeb.Models;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Service.Implementation
{
    public class SalePriceService : ISalePriceService
    {
        BaseDB<SalePrice> baseDB;

        public SalePriceService()
        {
            baseDB = new BaseDB<SalePrice>();
        }
        public SalePrice Add(SalePrice entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(SalePrice entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<SalePrice> GetAll()
        {
            return baseDB.GetAll().ToList();
        }

        public SalePrice GetById(int id)
        {
            return baseDB.GetById(id);
        }

        public SalePrice Update(SalePrice entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}