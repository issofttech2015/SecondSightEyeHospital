﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SecondSightSouthendEyeCentre.Models;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre.Service.Interfaces
{
    public interface IAppointmentService : IBaseService<Appointment>, IBaseServiceext<Appointment>
    {
    }
}
