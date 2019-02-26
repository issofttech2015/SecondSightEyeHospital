using SecondSightWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Data.Mappings
{
    public class SalePriceMap : EntityTypeConfiguration<SalePrice>
    {
        public SalePriceMap()
        {
            this.HasKey(x => x.SalePriceId);
            this.Property(x => x.SalePriceId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("SalePrice");
        }

    }
}