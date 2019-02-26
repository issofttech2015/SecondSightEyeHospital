using SecondSightSouthendEyeCentre.Models;
using SecondSightWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Areas.Inventory.Models.EditModel
{
    public class CategroyEditModel
    {
        public Category Category { get; set; } //For Accessing properties of that class
        public Store Store { get; set; } //For Accessing properties of that class
        public StoreHistory StoreHistory { get; set; } //For Accessing properties of that class
        public SalePrice SalePrice { get; set; }//For Accessing properties of that class
        public IEnumerable<CategoryMaster> CategoryMasters { get; set; }//For Dropdown
        public IEnumerable<Supplier> Supplier { get; set; }//For Dropdown
    }
}