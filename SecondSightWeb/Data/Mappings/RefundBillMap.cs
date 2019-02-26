using SecondSightWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Data.Mappings
{
    public class RefundBillMap : EntityTypeConfiguration<RefundBill>
    {
        public RefundBillMap()
        {
            this.HasKey(t => t.RefundBillId);
            this.Property(t => t.RefundBillId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("RefundBill");
        }
    }
}