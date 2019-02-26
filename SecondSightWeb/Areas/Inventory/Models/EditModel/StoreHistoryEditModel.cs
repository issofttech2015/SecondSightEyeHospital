using SecondSightSouthendEyeCentre.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Areas.Inventory.Models.EditModel
{
    public class StoreHistoryEditModel
    {
        public Category Category { get; set; } //For Accessing properties of that class
        public Store Store { get; set; } //For Accessing properties of that class
        public StoreHistory StoreHistory { get; set; } //For Accessing properties of that class
        public CategoryMaster CategoryMasters { get; set; }//For Accessing properties of that class
        public IEnumerable<Supplier> Supplier { get; set; }//For Dropdown
    }
}