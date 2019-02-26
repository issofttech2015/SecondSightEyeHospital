using SecondSightWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Data.Mappings
{
    public class RefundBillDetailsMap : EntityTypeConfiguration<RefundBillDetails>
    {
        public RefundBillDetailsMap()
        {
            this.HasKey(t => t.RefundBillDetailsId);
            this.Property(t => t.RefundBillDetailsId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("RefundBillDetails");
        }
    }
}