using SecondSightWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Data.Mappings
{
    public class TabletsMap: EntityTypeConfiguration<Tablets>
    {
        public TabletsMap()
        {
            this.HasKey(t => t.TabletId);
            this.Property(t => t.TabletId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("Tablets");
        }
    }
}