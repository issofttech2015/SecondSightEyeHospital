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
    public class EmployeeLogService : IEmployeeLogService
    {
        BaseDB<EmployeeLog> baseDB;
        public EmployeeLogService()
        {
            baseDB = new BaseDB<EmployeeLog>();
        }
        public EmployeeLog Add(EmployeeLog entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(EmployeeLog entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<EmployeeLog> GetAll()
        {
            return baseDB.GetAll().ToList();

        }

        public EmployeeLog GetById(int id)
        {
            return baseDB.GetById(id);

        }

        public EmployeeLog Update(EmployeeLog entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}
