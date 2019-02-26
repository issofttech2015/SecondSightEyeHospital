using System;
using System.Collections.Generic;
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

        public string CategoryName { get; set; }

    }

}
