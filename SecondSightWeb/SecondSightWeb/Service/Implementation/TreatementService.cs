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
    public class TreatementService : ITreatementService
    {
        BaseDB<Treatement> baseDB;
        public TreatementService()
        {
            baseDB = new BaseDB<Treatement>();
        }
        public Treatement Add(Treatement entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(Treatement entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<Treatement> GetAll()
        {
            return baseDB.GetAll().ToList();

        }

        public Treatement GetById(int id)
        {
            return baseDB.GetById(id);

        }

        public Treatement Update(Treatement entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}
