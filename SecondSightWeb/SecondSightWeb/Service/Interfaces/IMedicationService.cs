﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SecondSightSouthendEyeCentre.Models;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre.Service.Interfaces
{
    public interface IMedicationService : IBaseService<SecondSightSouthendEyeCentre.Models.Medication>, IBaseServiceext<SecondSightSouthendEyeCentre.Models.Medication>
    {
    }
}
