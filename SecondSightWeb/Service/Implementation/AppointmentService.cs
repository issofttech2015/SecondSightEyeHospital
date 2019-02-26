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
    public class AppointmentService : IAppointmentService
    {
        BaseDB<Appointment> baseDB;
        public AppointmentService()
        {
            baseDB = new BaseDB<Appointment>();
        }
        public Appointment Add(Appointment entity)
        {
            entity = baseDB.Add(entity);
            return entity;
        }

        public bool Delete(Appointment entity)
        {
            baseDB.Update(entity);
            return true;
        }

        public IEnumerable<Appointment> GetAll()
        {
            return baseDB.GetAll().ToList();

        }

        public Appointment GetById(int id)
        {
            return baseDB.GetById(id);

        }

        public Appointment Update(Appointment entity)
        {
            entity = baseDB.Update(entity);
            return entity;
        }
    }
}
