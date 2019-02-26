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
    public class ConsultantExamination1Service : IConsultantExamination1Service
    {
        BaseDB<Models.ConsultantExamination1> baseDB;
        public ConsultantExamination1Service()
        {
            baseDB = new BaseDB<Models.ConsultantExamination1>();
        }
        public Models.ConsultantExamination1 Add(Models.ConsultantExamination1 entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(Models.ConsultantExamination1 entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<Models.ConsultantExamination1> GetAll()
        {
            return baseDB.GetAll().ToList();

        }

        public Models.ConsultantExamination1 GetById(int id)
        {
            return baseDB.GetById(id);

        }

        public Models.ConsultantExamination1 Update(Models.ConsultantExamination1 entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}
