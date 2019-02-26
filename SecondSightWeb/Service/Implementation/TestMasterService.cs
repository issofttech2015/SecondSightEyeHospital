using SecondSightSouthendEyeCentre.Data.DbIntractions;
using SecondSightWeb.Models;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Service.Implementation
{
    public class TestMasterService : ITestMasterService
    {
        BaseDB<TestMaster> baseDB;

        public TestMasterService()
        {
            baseDB = new BaseDB<TestMaster>();
        }
        public TestMaster Add(TestMaster entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(TestMaster entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<TestMaster> GetAll()
        {
            return baseDB.GetAll().ToList();
        }

        public TestMaster GetById(int id)
        {
            return baseDB.GetById(id);
        }

        public TestMaster Update(TestMaster entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}