using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Areas.Inventory.Models.DTO
{
    public class CategoryDTO
    {
        public int? CategoryId { get; set; } = 1;

        public string ItemName { get; set; }

        public string ItemDescription { get; set; }

        public int? CategoryMasterId { get; set; } = 1;

        public string Type { get; set; }

        public string Unit { get; set; }

        public string AssetTag { get; set; }

        public int? ReOrderLevel { get; set; }
    }
}