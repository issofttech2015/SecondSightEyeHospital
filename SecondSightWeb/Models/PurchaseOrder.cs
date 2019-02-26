using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Models
{

    public class PurchaseOrder
    {
        [Key]
        public int POID { get; set; }
        public int SupplierId { get; set; }
        public DateTime PODate { get; set; }
        public decimal PreviewAmount { get; set; }
        public decimal PurchaseAmount { get; set; }
        public int GeneratedBy { get; set; }
        public DateTime GeteratedTime { get; set; }
        public bool IsApproved { get; set; } = false;
        public bool IsRejected { get; set; } = false;
        public bool IsPurchased { get; set; } = false;
        public bool IsDelivered { get; set; } = false;
    }
}