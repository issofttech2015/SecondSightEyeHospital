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
    public class DiseasesService : IDiseasesService
    {
        BaseDB<Diseases> baseDB;
        public DiseasesService()
        {
            baseDB = new BaseDB<Diseases>();
        }
        public Diseases Add(Diseases entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(Diseases entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<Diseases> GetAll()
        {
            return baseDB.GetAll().ToList();

        }

        public Diseases GetById(int id)
        {
            return baseDB.GetById(id);

        }

        public Diseases Update(Diseases entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}
