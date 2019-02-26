using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Models
{

    public class Miscellaneous
    {
        [Key]
        public int MiscellaneousId { get; set; }

        public string MiscellaneousName { get; set; }

        public bool IsDeleted { get; set; } = false;

    }

}