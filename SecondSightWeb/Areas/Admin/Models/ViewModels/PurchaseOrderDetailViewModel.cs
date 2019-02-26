using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Areas.Admin.Models.ViewModel
{
    public class PurchaseOrderDetailViewModel
    {
        [DisplayName("Categroy")]
        public string CategoryMasterName { get; set; }
        [DisplayName("Name")]
        public string CategroyName { get; set; }
        [DisplayName("Description")]
        public string CategroyDescription { get; set; }
        [DisplayName("Required Qty")]
        public int Qty { get; set; }
        public decimal Price { get; set; }
    }
}