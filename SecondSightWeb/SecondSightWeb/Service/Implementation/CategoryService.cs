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
    public class CategoryService : ICategoryService
    {
        BaseDB<Category> baseDB;
        public CategoryService()
        {
            baseDB = new BaseDB<Category>();
        }
        public Category Add(Category entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(Category entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<Category> GetAll()
        {
            return baseDB.GetAll().ToList();

        }

        public Category GetById(int id)
        {
            return baseDB.GetById(id);

        }

        public Category Update(Category entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}
