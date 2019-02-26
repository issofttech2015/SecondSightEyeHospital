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
    public class TreatmentDetailsService : ITreatmentDetailsService
    {
        BaseDB<TreatmentDetails> baseDB;
        public TreatmentDetailsService()
        {
            baseDB = new BaseDB<TreatmentDetails>();
        }
        public TreatmentDetails Add(TreatmentDetails entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(TreatmentDetails entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<TreatmentDetails> GetAll()
        {
            return baseDB.GetAll().ToList();

        }

        public TreatmentDetails GetById(int id)
        {
            return baseDB.GetById(id);

        }

        public TreatmentDetails Update(TreatmentDetails entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}
