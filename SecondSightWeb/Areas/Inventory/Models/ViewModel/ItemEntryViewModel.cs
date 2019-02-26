﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Areas.Inventory.Models.ViewModel
{
    public class ItemEntryViewModel
    {
        [Key]
        public int POID { get; set; }
        [Required(ErrorMessage = "Please Enter Supplier Details")]
        [DisplayName("Supplier Name")]
        public string SupplierName { get; set; }
        [DisplayName("Purchase Order Date")]
        public DateTime? PODate { get; set; }
        
        [DisplayName("Purchase Amount")]
        public decimal? PurchaseAmount { get; set; }
        [DisplayName("Generated By")]
        public string GeneratedBy { get; set; }
        [DisplayName("Geterated Time")]
        public DateTime? GeteratedTime { get; set; }
    }
}