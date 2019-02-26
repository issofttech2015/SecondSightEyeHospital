using SecondSightWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Data.Mappings
{
    public class SurgicalInjectableConsumptionListMap : EntityTypeConfiguration<SurgicalInjectableConsumptionList>
    {
        public SurgicalInjectableConsumptionListMap()
        {
            this.HasKey(t => t.SurgicalInjectableId);
            this.Property(t => t.SurgicalInjectableId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("SurgicalInjectableConsumptionList");
        }
    }
}