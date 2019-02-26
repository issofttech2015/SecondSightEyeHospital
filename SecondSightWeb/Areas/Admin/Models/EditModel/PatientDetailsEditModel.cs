using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Areas.Admin.Models.EditModel
{
    public class PatientDetailsEditModel
    {
        [Key]
        public int PatientId { get; set; }
        [Display(Name = "Pat Code")]
        public string PatCode { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Gender { get; set; }
        [Display(Name = "DOB")]
        [DataType(DataType.DateTime)]
        public DateTime DateofBirth { get; set; }

        public int? Age { get; set; }

        public string Nationality { get; set; }
        [Display(Name = "Address")]
        public string ResidanceAddress { get; set; }

        public string Email { get; set; }
        [Display(Name = "Guardian First Name")]
        public string GuardianFirstName { get; set; }
        [Display(Name = "Guardian Last Name")]
        public string GuardianLastName { get; set; }
        [Display(Name = "Guardian Contact")]
        //[StringLength(10, ErrorMessage = "Enter a 10 digit mobile number")]
        public string GuardianContact { get; set; }
        [Display(Name = "Guardian Relate As")]
        public string GuardianRelateAs { get; set; }

        public string Ocupation { get; set; }
        //[StringLength(12, ErrorMessage = "Enter a 12 digit Adhar number")]
        public Decimal Adhar { get; set; }
    }
}