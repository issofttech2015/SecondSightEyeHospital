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
    public class ConsultantReportService : IConsultantReportService
    {
        BaseDB<ConsultantReport> baseDB;
        public ConsultantReportService()
        {
            baseDB = new BaseDB<ConsultantReport>();
        }
        public ConsultantReport Add(ConsultantReport entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(ConsultantReport entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<ConsultantReport> GetAll()
        {
            return baseDB.GetAll().ToList();

        }

        public ConsultantReport GetById(int id)
        {
            return baseDB.GetById(id);

        }

        public ConsultantReport Update(ConsultantReport entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}
