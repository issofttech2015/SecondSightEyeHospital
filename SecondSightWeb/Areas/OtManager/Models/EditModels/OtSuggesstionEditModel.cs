using SecondSightSouthendEyeCentre;
using SecondSightSouthendEyeCentre.Models;
using SecondSightWeb.Areas.Admin.Models.EditModel;
using SecondSightWeb.Areas.OtManager.Models.DTO;
using SecondSightWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Areas.OtManager.Models.EditModels
{
    public class OtSuggesstionEditModel
    {
        public OperationSuggestion OperationSuggestion { get; set; }
        public EmployeeShortInfo Patient { get; set; }
        public IEnumerable<EmployeeShortInfo> Employees { get; set; }
        public IEnumerable<SecondSightSouthendEyeCentre.Models.Patient> Patients { get; set; }
        public IEnumerable<OTCharges> OTCharges { get; set; }
        public IEnumerable<OTChargeCategory> OtChargeCategories { get; set; }
        public IEnumerable<AppointmentDTO> Appointments { get; set; }
        public int OtCategoryId { get; set; }
        public List<Genders> EyeList = new List<Genders>()
        {
            new Genders(){Gender="LEFT EYE",IsSelected=true},
            new Genders(){Gender="RIGHT EYE",IsSelected=true},
        };
    }

}