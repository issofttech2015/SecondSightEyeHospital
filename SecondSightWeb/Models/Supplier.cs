using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }
        [Required(ErrorMessage = "Please Enter Supplier Details")]
        [DisplayName("Supplier Name")]
        public string SupplierName { get; set; }
    }
}
