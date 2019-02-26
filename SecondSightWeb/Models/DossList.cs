using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Models
{
    public class DossList
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Short Details")]
        [DisplayName("Short Code")]
        public string ShortCodeDoss { get; set; }
        [Required(ErrorMessage = "Please Enter Doss Details")]
        [DisplayName("Doss Details")]
        public string DossName { get; set; }
        public virtual ICollection<DossListSummary> DossListSummaries { get; set; }
    }
}