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
    public class ConsultantExamination3Service : IConsultantExamination3Service
    {
        BaseDB<Models.ConsultantExamination3> baseDB;
        public ConsultantExamination3Service()
        {
            baseDB = new BaseDB<Models.ConsultantExamination3>();
        }
        public ConsultantExamination3 Add(ConsultantExamination3 entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(ConsultantExamination3 entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<ConsultantExamination3> GetAll()
        {
            return baseDB.GetAll().ToList();

        }

        public ConsultantExamination3 GetById(int id)
        {
            return baseDB.GetById(id);

        }

        public ConsultantExamination3 Update(ConsultantExamination3 entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}
