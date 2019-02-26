using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Models
{
    public class DossListSummary
    {
        [Key]
        public int Id { get; set; }
        public int? DossId { get; set; }
        public string Summary { get; set; }
        public virtual DossList DossList { get; set; }
    }
}