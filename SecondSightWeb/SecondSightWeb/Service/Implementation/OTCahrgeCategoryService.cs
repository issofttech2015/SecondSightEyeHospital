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
    public class OTCahrgeCategoryService : IOTCahrgeCategoryService
    {
        BaseDB<OTCahrgeCategory> baseDB;
        public OTCahrgeCategoryService()
        {
            baseDB = new BaseDB<OTCahrgeCategory>();
        }
        public OTCahrgeCategory Add(OTCahrgeCategory entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(OTCahrgeCategory entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<OTCahrgeCategory> GetAll()
        {
            return baseDB.GetAll().ToList();

        }

        public OTCahrgeCategory GetById(int id)
        {
            return baseDB.GetById(id);

        }

        public OTCahrgeCategory Update(OTCahrgeCategory entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}
