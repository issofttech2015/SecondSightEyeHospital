using SecondSightWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Data.Mappings
{
    public class PaymentDetalisMap:EntityTypeConfiguration<PaymentDetalis>
    {
        public PaymentDetalisMap()
        {
            this.HasKey(t => t.PaymentId);
            this.Property(t => t.PaymentId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("PaymentDetalis");
        }
    }
}