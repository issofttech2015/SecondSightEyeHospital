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
    public class OTCahargesService : IOTCahargesService
    {
        BaseDB<OTCaharges> baseDB;
        public OTCahargesService()
        {
            baseDB = new BaseDB<OTCaharges>();
        }
        public OTCaharges Add(OTCaharges entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(OTCaharges entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<OTCaharges> GetAll()
        {
            return baseDB.GetAll().ToList();

        }

        public OTCaharges GetById(int id)
        {
            return baseDB.GetById(id);

        }

        public OTCaharges Update(OTCaharges entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}
