using SecondSightWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Data.Mappings
{
    public class PastOcularHistoryMap:EntityTypeConfiguration<PastOcularHistory>
    {
        public PastOcularHistoryMap()
        {
            this.HasKey(t => t.PastOcularHistoryId);
            this.Property(t => t.PastOcularHistoryId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("PastOcularHistory");
        }
    }
}