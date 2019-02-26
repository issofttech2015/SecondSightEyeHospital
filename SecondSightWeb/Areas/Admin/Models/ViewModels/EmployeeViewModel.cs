using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Areas.Admin.Models.ViewModels
{
    public class EmployeeViewModel
    {
        [Key]
        public int EmployeeId { get; set; }
        [DisplayName("Name")]
        public string EmployeeName { get; set; }
        public string Role { get; set; }
        [DisplayName("Mobile Number")]
        public string MobileNumber { get; set; }
        [DisplayName("Qualifaction")]
        public string EducationalQualification { get; set; }
    }
}