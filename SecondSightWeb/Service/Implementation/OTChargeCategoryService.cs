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
    public class OTChargeCategoryService : IOTChargeCategoryService
    {
        BaseDB<OTChargeCategory> baseDB;
        public OTChargeCategoryService()
        {
            baseDB = new BaseDB<OTChargeCategory>();
        }
        public OTChargeCategory Add(OTChargeCategory entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(OTChargeCategory entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<OTChargeCategory> GetAll()
        {
            return baseDB.GetAll().ToList();

        }

        public OTChargeCategory GetById(int id)
        {
            return baseDB.GetById(id);

        }

        public OTChargeCategory Update(OTChargeCategory entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}
