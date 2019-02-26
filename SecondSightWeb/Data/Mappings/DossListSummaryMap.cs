using SecondSightWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Data.Mappings
{
    public class DossListSummaryMap:EntityTypeConfiguration<DossListSummary>
    {
        public DossListSummaryMap()
        {
            this.HasKey(t => t.Id);
            this.Property(t => t.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("DossListSummary");


            HasRequired(t => t.DossList).WithMany(c => c.DossListSummaries).HasForeignKey(t => t.DossId).WillCascadeOnDelete(false);
        }
    }
}