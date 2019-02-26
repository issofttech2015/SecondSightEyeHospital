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
    public class ConsultantExaminationCombineService : IConsultantExaminationCombineService
    {
        BaseDB<ConsultantExaminationCombine> baseDB;
        public ConsultantExaminationCombineService()
        {
            baseDB = new BaseDB<ConsultantExaminationCombine>();
        }
        public ConsultantExaminationCombine Add(ConsultantExaminationCombine entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(ConsultantExaminationCombine entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<ConsultantExaminationCombine> GetAll()
        {
            return baseDB.GetAll().ToList();

        }

        public ConsultantExaminationCombine GetById(int id)
        {
            return baseDB.GetById(id);

        }

        public ConsultantExaminationCombine Update(ConsultantExaminationCombine entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}
