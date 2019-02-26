using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre
{
    public class CategoryMaster
    {
        public int CategoryMasterId { get; set; }
        public string CategoryName { get; set; }
    }
    public class Ctegory
    {
        public int CategoryId { get; set; }
        public string ItemName { get; set; }
        public string ItemDesc { get; set; }
        public int CategoryMasterId { get; set; }
        public string Type { get; set; }
        public string Unit { get; set; }
        public string AssetTag { get; set; } = "No";
        public int ReOrderLevel { get; set; } = 0;
    }
}
