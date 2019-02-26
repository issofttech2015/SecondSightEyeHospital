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
    public class ExaminationService : IExaminationService
    {
        BaseDB<Examination> baseDB;
        public ExaminationService()
        {
            baseDB = new BaseDB<Examination>();
        }
        public Examination Add(Examination entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(Examination entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<Examination> GetAll()
        {
            return baseDB.GetAll().ToList();

        }

        public Examination GetById(int id)
        {
            return baseDB.GetById(id);

        }

        public Examination Update(Examination entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}
