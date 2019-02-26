using SecondSightWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Data.Mappings
{
    public class SurgicalTabletsConsumptionListMap : EntityTypeConfiguration<SurgicalTabletsConsumptionList>
    {
        public SurgicalTabletsConsumptionListMap()
        {
            this.HasKey(t => t.SurgicalTabletId);
            this.Property(t => t.SurgicalTabletId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("SurgicalTabletsConsumptionList");
        }
    }
}