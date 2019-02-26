using SecondSightWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Data.Mappings
{
    public class SurgicalKnivesConsumptionListMap : EntityTypeConfiguration<SurgicalKnivesConsumptionList>
    {
        public SurgicalKnivesConsumptionListMap()
        {
            this.HasKey(t => t.SurgicalKniveId);
            this.Property(t => t.SurgicalKniveId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("SurgicalKnivesConsumptionList");
        }
    }
}