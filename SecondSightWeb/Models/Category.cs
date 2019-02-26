using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Item Name")]
        [Required(ErrorMessage = "Enter Item Name")]
        public string ItemName { get; set; }
        [DisplayName("Item Description")]
        [Required(ErrorMessage = "Enter Item Description")]
        public string ItemDescription { get; set; }
        [DisplayName("Category Type")]
        [Required(ErrorMessage = "Category Type")]
        public int? CategoryMasterId { get; set; }
        [DisplayName("Type")]
        [Required(ErrorMessage = "Enter Type")]
        public string Type { get; set; }
        [DisplayName("Unit")]
        [Required(ErrorMessage = "Enter Unit")]
        public string Unit { get; set; }
        [DisplayName("AssetTag")]
        [Required(ErrorMessage = "Enter Asset Tag")]
        public string AssetTag { get; set; }
        [DisplayName("Re-Order Level")]
        [Required(ErrorMessage = "Enter Re-Order Level")]
        public int? ReOrderLevel { get; set; }

    }

}
