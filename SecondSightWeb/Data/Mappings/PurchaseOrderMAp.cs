using SecondSightWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Data.Mappings
{
    public class PurchaseOrderMap:EntityTypeConfiguration<PurchaseOrder>
    {
        public PurchaseOrderMap()
        {
            this.HasKey(t => t.POID);
            this.Property(t => t.POID).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("PurchaseOrder");
        }
    }
}