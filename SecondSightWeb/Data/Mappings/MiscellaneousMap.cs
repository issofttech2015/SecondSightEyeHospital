using SecondSightWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Data.Mappings
{
    public class MiscellaneousMap: EntityTypeConfiguration<Miscellaneous>
    {
        public MiscellaneousMap()
        {
            this.HasKey(t => t.MiscellaneousId);
            this.Property(t => t.MiscellaneousId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("Miscellaneous");
        }
    }
}