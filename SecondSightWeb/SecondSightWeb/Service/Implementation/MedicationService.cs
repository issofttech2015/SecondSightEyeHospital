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
    public class MedicationService : IMedicationService
    {
        BaseDB<Models.Medication> baseDB;
        public MedicationService()
        {
            baseDB = new BaseDB<Models.Medication>();
        }
        public Models.Medication Add(Models.Medication entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(Models.Medication entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<Models.Medication> GetAll()
        {
            return baseDB.GetAll().ToList();

        }

        public Models.Medication GetById(int id)
        {
            return baseDB.GetById(id);

        }

        public Models.Medication Update(Models.Medication entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}
