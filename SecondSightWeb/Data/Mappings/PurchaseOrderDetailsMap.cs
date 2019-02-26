using SecondSightWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Data.Mappings
{
    public class PurchaseOrderDetailsMap:EntityTypeConfiguration<PurchaseOrderDetails>
    {
        public PurchaseOrderDetailsMap()
        {
            this.HasKey(t => t.PODId);
            this.Property(t => t.PODId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("PurchaseOrderDetails");
        }
    }
}