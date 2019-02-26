using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Models
{
    public class OtCheckList
    {
        public int Id { get; set; }
        public string CheckList { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsSelected { get; set; }
    }
}