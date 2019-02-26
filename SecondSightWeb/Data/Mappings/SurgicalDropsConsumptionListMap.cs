using SecondSightWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Data.Mappings
{
    public class SurgicalDropsConsumptionListMap : EntityTypeConfiguration<SurgicalDropsConsumptionList>
    {
        public SurgicalDropsConsumptionListMap()
        {
            this.HasKey(t => t.SurgicalDropId);
            this.Property(t => t.SurgicalDropId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("SurgicalDropsConsumptionList");
        }
    }
}