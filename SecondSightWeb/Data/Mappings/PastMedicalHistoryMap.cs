using SecondSightWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Data.Mappings
{
    public class PastMedicalHistoryMap:EntityTypeConfiguration<PastMedicalHistory>
    {
        public PastMedicalHistoryMap()
        {
            this.HasKey(t => t.PastMedicalHistoryId);
            this.Property(t => t.PastMedicalHistoryId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("PastMedicalHistory");
        }
    }
}