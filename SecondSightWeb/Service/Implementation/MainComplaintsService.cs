using SecondSightSouthendEyeCentre.Data.DbIntractions;
using SecondSightWeb.Models;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Service.Implementation
{
    public class MainComplaintsService : IMainComplaintsService
    {
        BaseDB<MainComplaints> baseDB;
        public MainComplaintsService()
        {
            baseDB = new BaseDB<MainComplaints>();
        }
        public MainComplaints Add(MainComplaints entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(MainComplaints entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<MainComplaints> GetAll()
        {
            return baseDB.GetAll().ToList();
        }

        public MainComplaints GetById(int id)
        {
            return baseDB.GetById(id);
        }

        public MainComplaints Update(MainComplaints entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}