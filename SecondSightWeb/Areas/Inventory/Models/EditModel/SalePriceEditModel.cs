using SecondSightSouthendEyeCentre.Models;
using SecondSightWeb.Areas.Inventory.Models.DTO;
using SecondSightWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Areas.Inventory.Models.EditModel
{
    public class SalePriceEditModel
    {
        public IEnumerable<CategoryMaster> CategoryMasters { get; set; }
        public IEnumerable<Category> CategoryNames { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public SalePrice SalePrice { get; set; }//For Accessing properties of that class
        public Category Category { get; set; }
    }
}