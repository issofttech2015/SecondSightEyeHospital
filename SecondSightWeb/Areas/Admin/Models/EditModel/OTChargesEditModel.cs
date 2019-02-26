using SecondSightSouthendEyeCentre.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Areas.Admin.Models.EditModel
{
    public class OTChargesEditModel
    {
        public OTCharges OTCaharges { get; set; }//For Accessing properties of that class
        public IEnumerable<OTChargeCategory> OTChargeCategory { get; set; }//For Dropdown
    }
}