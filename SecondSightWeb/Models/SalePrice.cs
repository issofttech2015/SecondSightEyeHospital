using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Models
{
    public class SalePrice
    {
        [Key]
        public int SalePriceId { get; set; }
        public int? CategroyId { get; set; }
        [DisplayName("Saleing Price")]
        [Required(ErrorMessage = "Enter Saleing Price")]
        public decimal? SaleingPrice { get; set; }
        
        public bool? IsActive { get; set; } = true;
        [DisplayName("Added On")]
        [Required(ErrorMessage = "Enter Added On")]
        public DateTime? AddedOn { get; set; } = System.DateTime.Now;
        public DateTime? ClosedOn { get; set; }= System.DateTime.Now;
    }
}