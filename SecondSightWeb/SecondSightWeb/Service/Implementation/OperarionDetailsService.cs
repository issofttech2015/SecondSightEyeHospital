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
    public class OperarionDetailsService : IOperarionDetailsService
    {
        BaseDB<OperarionDetails> baseDB;
        public OperarionDetailsService()
        {
            baseDB = new BaseDB<OperarionDetails>();
        }
        public OperarionDetails Add(OperarionDetails entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(OperarionDetails entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<OperarionDetails> GetAll()
        {
            return baseDB.GetAll().ToList();

        }

        public OperarionDetails GetById(int id)
        {
            return baseDB.GetById(id);

        }

        public OperarionDetails Update(OperarionDetails entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}
