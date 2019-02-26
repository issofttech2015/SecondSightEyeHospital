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
    public class PatientService : IPatientService
    {
        BaseDB<Patient> baseDB;
        public PatientService()
        {
            baseDB = new BaseDB<Patient>();
        }
        public Patient Add(Patient entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(Patient entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<Patient> GetAll()
        {
            return baseDB.GetAll().ToList();

        }

        public Patient GetById(int id)
        {
            return baseDB.GetById(id);

        }

        public Patient Update(Patient entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}
