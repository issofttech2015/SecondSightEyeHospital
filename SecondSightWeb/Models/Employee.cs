using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [DisplayName("First Name")]
        [Required(ErrorMessage ="Enter Firstname")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Enter Lastname")]
        public string LastName { get; set; }
        [DisplayName("Middle Name")]
        public string OtherName { get; set; }
        [Required(ErrorMessage = "Please select Gender")]
        public string Gender { get; set; }
        public DateTime DateofBirth { get; set; } = System.DateTime.Now;

        public string Nationality { get; set; } = "Indian";

        public int? Age { get; set; }=0;
        [Required(ErrorMessage = "Enter Contact")]
        [DisplayFormat(DataFormatString = "{0:0.##}", ApplyFormatInEditMode = true)]
        public decimal Contact { get; set; }
        [Required(ErrorMessage = "Enter Qualification")]
        public string Qualification { get; set; }

        public int DepartmentId { get; set; } = 1;

        public string Designation { get; set; }

        public string ResidanceAddress { get; set; }

        public DateTime DateJoined { get; set; } = DateTime.Now;
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage ="Must enter email, This is the user id")]
        public string Email { get; set; }
        [DisplayName("Reference Name")]
        public string ReferanceName { get; set; }
        [DisplayName("Reference Contact")]
        [DisplayFormat(DataFormatString = "{0:0.##}", ApplyFormatInEditMode =true)]
        public decimal? RefrenceContact { get; set; }

        public string ImageName { get; set; }

        public string ImagePath { get; set; }

    }

}
