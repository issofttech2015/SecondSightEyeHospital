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
    public class SequenceService : ISequenceService
    {
        BaseDB<Sequence> baseDB;
        public SequenceService()
        {
            baseDB = new BaseDB<Sequence>();
        }
        public Sequence Add(Sequence entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(Sequence entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<Sequence> GetAll()
        {
            return baseDB.GetAll().ToList();

        }

        public Sequence GetById(int id)
        {
            return baseDB.GetById(id);
        }

        public Sequence Update(Sequence entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}
