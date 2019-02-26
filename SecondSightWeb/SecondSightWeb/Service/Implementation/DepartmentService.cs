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
    public class DepartmentService : IDepartmentService
    {
        BaseDB<Department> baseDB;
        public DepartmentService()
        {
            baseDB = new BaseDB<Department>();
        }
        public Department Add(Department entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(Department entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<Department> GetAll()
        {
            return baseDB.GetAll().ToList();

        }

        public Department GetById(int id)
        {
            return baseDB.GetById(id);

        }

        public Department Update(Department entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}
