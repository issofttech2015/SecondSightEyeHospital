using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Models
{
    public class PurchaseOrderDetails
    {
        [Key]
        public int PODId { get; set; }
        public int POID { get; set; } = 0;
        public int CategoryId { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public bool IsDelivered { get; set; } = false;
        public int DeliveredQty { get; set; } = 0;
    }

}