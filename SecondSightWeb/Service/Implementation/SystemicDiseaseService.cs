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
    public class SystemicDiseaseService : ISystemicDiseaseService
    {
        BaseDB<SystemicDisease> baseDB;
        public SystemicDiseaseService()
        {
            baseDB = new BaseDB<SystemicDisease>();
        }
        public SystemicDisease Add(SystemicDisease entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(SystemicDisease entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<SystemicDisease> GetAll()
        {
            return baseDB.GetAll().ToList();

        }

        public SystemicDisease GetById(int id)
        {
            return baseDB.GetById(id);

        }

        public SystemicDisease Update(SystemicDisease entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}
