using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre.Models
{
    public class CategoryMaster
    {
        [Key]
        public int CategoryMasterId { get; set; }
        [Required(ErrorMessage = "Please Enter Category Details")]
        [DisplayName("Category Details")]
        public string CategoryName { get; set; }

    }

}
