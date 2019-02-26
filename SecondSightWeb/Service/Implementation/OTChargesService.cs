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
    public class OTChargesService : IOTChargesService
    {
        BaseDB<OTCharges> baseDB;
        public OTChargesService()
        {
            baseDB = new BaseDB<OTCharges>();
        }
        public OTCharges Add(OTCharges entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(OTCharges entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<OTCharges> GetAll()
        {
            return baseDB.GetAll().ToList();

        }

        public OTCharges GetById(int id)
        {
            return baseDB.GetById(id);

        }

        public OTCharges Update(OTCharges entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}
