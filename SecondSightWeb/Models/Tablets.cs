using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Models
{

    public class Tablets
    {
        [Key]
        public int TabletId { get; set; }

        public string TabletName { get; set; }

        public bool IsDeleted { get; set; } = false;

    }
}