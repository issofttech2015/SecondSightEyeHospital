using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Areas.Admin.Models.ViewModels
{
    public class ResetPasswordViewModel
    {
        [Key]
        public int EmployeeId { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter Contact")]
        [DisplayFormat(DataFormatString = "{0:0.##}", ApplyFormatInEditMode = true)]
        public decimal Contact { get; set; }
        [Required(ErrorMessage = "Must enter email, This is the user id")]
        public string Email { get; set; }
        public DateTime RequestTime { get; set; }
        public string RequestIP { get; set; }
        [Required(ErrorMessage = "Enter Password")]
        public string Password { get; set; }
        public int ForgotPasswordId { get; set; }
    }
}