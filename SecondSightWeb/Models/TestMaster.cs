using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Models
{
    public class TestMaster
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Test Details")]
        [DisplayName("Test Name")]
        public string TestName { get; set; }
    }
}