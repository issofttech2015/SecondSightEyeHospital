using SecondSightWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Data.Mappings
{
    public class SurgicalMiscellaneousConsumptionListMap : EntityTypeConfiguration<SurgicalMiscellaneousConsumptionList>
    {
        public SurgicalMiscellaneousConsumptionListMap()
        {
            this.HasKey(t => t.SurgicalMiscellaneousId);
            this.Property(t => t.SurgicalMiscellaneousId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("SurgicalMiscellaneousConsumptionList");
        }
    }
}