using SecondSightWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Data.Mappings
{
    public class KnivesMap:EntityTypeConfiguration<Knives>
    {
        public KnivesMap()
        {
            this.HasKey(t => t.KniveId);
            this.Property(t => t.KniveId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("Knives");
        }
    }
}