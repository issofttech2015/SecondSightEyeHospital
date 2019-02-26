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
    public class AlergyService : IAlergyService
    {
        BaseDB<Alergy> baseDB;
        public AlergyService()
        {
            baseDB = new BaseDB<Alergy>();
        }
        public Alergy Add(Alergy entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(Alergy entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<Alergy> GetAll()
        {
            return baseDB.GetAll().ToList();
        }

        public Alergy GetById(int id)
        {
            return baseDB.GetById(id);
        }

        public Alergy Update(Alergy entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}
