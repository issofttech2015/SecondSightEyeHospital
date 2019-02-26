using SecondSightWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Data.Mappings
{
    public class BillDetailsMap:EntityTypeConfiguration<BillDetails>
    {
        public BillDetailsMap()
        {
            this.HasKey(t => t.BillDetailsId);
            this.Property(t => t.BillDetailsId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("BillDetails");
        }
    }
}