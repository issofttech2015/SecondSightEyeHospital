using SecondSightSouthendEyeCentre.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Areas.Admin.Models.EditModel
{
    public class EmployeeEditModel
    {
        public Employee Employee { get; set; }
        public EmployeeLog EemployeeLog { get; set; }
        public IEnumerable<Role> Roles { get; set; }
        public List<Genders> GenderList = new List<Genders>()
        {
            new Genders(){Gender="Male",IsSelected=true},
            new Genders(){Gender="Female",IsSelected=false}
        };
    }
    public class Genders
    {
        public string Gender { get; set; }
        public bool IsSelected { get; set; }
    }
}