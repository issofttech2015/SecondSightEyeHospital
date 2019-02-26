using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Areas.OtManager.Models.EditModels
{
    public class ItemDetails
    {
        public string CategoryName { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public string ManufacturingDate { get; set; }
        public string ExperyDate { get; set; }
        public int Qty { get; set; }
    }

}