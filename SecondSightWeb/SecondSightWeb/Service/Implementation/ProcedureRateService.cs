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
    public class ProcedureRateService : IProcedureRateService
    {
        BaseDB<Models.ProcedureRate> baseDB;
        public ProcedureRateService()
        {
            baseDB = new BaseDB<Models.ProcedureRate>();
        }
        public Models.ProcedureRate Add(Models.ProcedureRate entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(Models.ProcedureRate entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<Models.ProcedureRate> GetAll()
        {
            return baseDB.GetAll().ToList();

        }

        public Models.ProcedureRate GetById(int id)
        {
            return baseDB.GetById(id);

        }

        public Models.ProcedureRate Update(Models.ProcedureRate entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}
