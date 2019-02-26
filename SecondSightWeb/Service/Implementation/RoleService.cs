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
    public class RoleService : IRoleService
    {
        BaseDB<Role> baseDB;
        public RoleService()
        {
            baseDB = new BaseDB<Role>();
        }
        public Role Add(Role entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(Role entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Role> GetAll()
        {
            return baseDB.GetAll().ToList();

        }

        public Role GetById(int id)
        {
            return baseDB.GetById(id);

        }

        public Role Update(Role entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}
