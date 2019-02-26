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
    public class EmployeeService : IEmployeeService
    {
        BaseDB<Models.Employee> baseDB;
        public EmployeeService()
        {
            baseDB = new BaseDB<Models.Employee>();
        }
        public Models.Employee Add(Models.Employee entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(Models.Employee entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<Models.Employee> GetAll()
        {
            return baseDB.GetAll().ToList();

        }

        public Models.Employee GetById(int id)
        {
            return baseDB.GetById(id);

        }

        public bool IsRegisteredEmployee(decimal contact)
        {
            decimal contactRes = 0;
            try
            {
                contactRes = baseDB.Get(m => m.Contact == contact).Contact;
                if (contactRes != 0)
                    return false;
            }
            catch(Exception ex)
            {
                return true;
            }
            return false;
        }

        public Models.Employee Update(Models.Employee entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}
