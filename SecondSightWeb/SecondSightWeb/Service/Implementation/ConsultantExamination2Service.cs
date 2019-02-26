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
    public class ConsultantExamination2Service : IConsultantExamination2Service
    {
        BaseDB<Models.ConsultantExamination2> baseDB;
        public ConsultantExamination2Service()
        {
            baseDB = new BaseDB<Models.ConsultantExamination2>();
        }
        public Models.ConsultantExamination2 Add(Models.ConsultantExamination2 entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(Models.ConsultantExamination2 entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<Models.ConsultantExamination2> GetAll()
        {
            return baseDB.GetAll().ToList();

        }

        public Models.ConsultantExamination2 GetById(int id)
        {
            return baseDB.GetById(id);

        }

        public Models.ConsultantExamination2 Update(Models.ConsultantExamination2 entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}
