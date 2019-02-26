using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Models
{
    public class Injectables
    {
        [Key]
        public int InjectableId { get; set; }

        public string InjectableName { get; set; }

        public bool IsDeleted { get; set; } = false;

    }
}