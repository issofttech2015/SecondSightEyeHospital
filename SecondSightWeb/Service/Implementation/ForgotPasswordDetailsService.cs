using SecondSightSouthendEyeCentre.Data.DbIntractions;
using SecondSightWeb.Models;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Service.Implementation
{
    public class ForgotPasswordDetailsService : IForgotPasswordDetailsService
    {
        BaseDB<ForgotPasswordDetails> baseDB;
        public ForgotPasswordDetailsService()
        {
            baseDB = new BaseDB<ForgotPasswordDetails>();
        }

        public ForgotPasswordDetails Add(ForgotPasswordDetails entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(ForgotPasswordDetails entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<ForgotPasswordDetails> GetAll()
        {
            return baseDB.GetAll().ToList();
        }

        public ForgotPasswordDetails GetById(int id)
        {
            return baseDB.GetById(id);
        }

        public ForgotPasswordDetails Update(ForgotPasswordDetails entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}