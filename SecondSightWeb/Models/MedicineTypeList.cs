using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Models
{
    public class MedicineTypeList
    {
        [Key]
        public int MedicineTypeId { get; set; }
        [Required(ErrorMessage = "Please Enter Short Code")]
        [DisplayName("Short Code")]
        public string MedicineTypeShortCode { get; set; }
        [Required(ErrorMessage = "Please Enter Short Details")]
        [DisplayName("Medicine Type")]
        public string MedicineTypeName { get; set; }
    }

}
