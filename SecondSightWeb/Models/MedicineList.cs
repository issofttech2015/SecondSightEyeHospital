using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Models
{
    public class MedicineList
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Enter Medicine Name")]
        [DisplayName("Medicine Name")]
        public string MedicineName { get; set; }
        [Required(ErrorMessage = "Enter Medicine Type")]
        [DisplayName("Medicine Type")]
        public int MedicineTypeId { get; set; }
    }
}