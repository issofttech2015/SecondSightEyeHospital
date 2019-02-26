using SecondSightWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Data.Mappings
{
    public class DischargeDetailsMap:EntityTypeConfiguration<DischargeDetails>
    {
        public DischargeDetailsMap()
        {
            this.HasKey(t => t.DischargeDetailsId);
            this.Property(t => t.DischargeDetailsId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("DischargeDetails");
        }
    }
}