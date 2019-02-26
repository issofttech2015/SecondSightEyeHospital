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
    public class CategoryMasterService : ICategoryMasterService
    {
        BaseDB<Models.CategoryMaster> baseDB;
        public CategoryMasterService()
        {
            baseDB = new BaseDB<Models.CategoryMaster>();
        }
        public Models.CategoryMaster Add(Models.CategoryMaster entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(Models.CategoryMaster entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<Models.CategoryMaster> GetAll()
        {
            return baseDB.GetAll().ToList();

        }

        public Models.CategoryMaster GetById(int id)
        {
            return baseDB.GetById(id);

        }

        public Models.CategoryMaster Update(Models.CategoryMaster entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}
