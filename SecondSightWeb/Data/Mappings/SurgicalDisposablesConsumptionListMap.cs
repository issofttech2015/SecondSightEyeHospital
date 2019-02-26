using SecondSightWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Data.Mappings
{
    public class SurgicalDisposablesConsumptionListMap:EntityTypeConfiguration<SurgicalDisposablesConsumptionList>
    {
        public SurgicalDisposablesConsumptionListMap()
        {
            this.HasKey(t => t.SurgicalDisposableId);
            this.Property(t => t.SurgicalDisposableId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("SurgicalDisposablesConsumptionList");
        }
    }
}