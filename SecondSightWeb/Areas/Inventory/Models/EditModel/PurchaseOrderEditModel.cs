using SecondSightSouthendEyeCentre.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Areas.Inventory.Models.EditModel
{
    public class PurchaseOrderEditModel
    {
        public IEnumerable<CategoryMaster> CategoryMasters { get; set; }
        public IEnumerable<Category> CategoryNames { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Supplier> Suppliers { get; set; }
        public int CategoryMasterId { get; set; } = 0;
        public string CategoryNamesSelected { get; set; } = "Abc";
        public int CategoryId { get; set; } = 1;
        public int SupplierId { get; set; } = 0;
    }
}