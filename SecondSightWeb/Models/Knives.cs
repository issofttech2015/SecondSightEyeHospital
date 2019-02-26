using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Models
{

    public class Knives
    {
        [Key]
        public int KniveId { get; set; }

        public string KniveName { get; set; }

        public bool IsDeleted { get; set; } = false;

    }

}