using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Areas.Admin.Models.ViewModels
{
    public class FirstTimeLoginViewModel
    {
        [Key]
        public int EmployeeId { get; set; }
        [DisplayName("Name")]
        public string Name { get; set; }
        [DisplayName("Contact Number")]
        [DisplayFormat(DataFormatString = "{0:0.##}", ApplyFormatInEditMode = true)]
        public decimal Contact { get; set; }
        [DisplayName("Old Pasword")]
        [Required(ErrorMessage = "Enter Old Pasword")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }
        [DisplayName("New Pasword")]
        [Required(ErrorMessage = "Enter new Pasword")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DisplayName("Confirm Pasword")]
        [Required(ErrorMessage = "Enter Confirm Pasword")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]
        public string ConfirmPassword { get; set; }

    }
}