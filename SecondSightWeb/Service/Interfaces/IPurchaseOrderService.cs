﻿using SecondSightSouthendEyeCentre.Service.Interfaces;
using SecondSightWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondSightWeb.Service.Interfaces
{
    interface IPurchaseOrderService:IBaseService<PurchaseOrder>,IBaseServiceext<PurchaseOrder>
    {
    }
}
