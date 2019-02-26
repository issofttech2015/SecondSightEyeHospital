using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        public string ItemName { get; set; }

        public string ItemDescription { get; set; }

        public int? CategoryMasterId { get; set; }

        public string Type { get; set; }

        public string Unit { get; set; }

        public string AssetTag { get; set; }

        public int? ReOrderLevel { get; set; }

    }

}
