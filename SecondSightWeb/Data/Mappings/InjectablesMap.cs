using SecondSightWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Data.Mappings
{
    public class InjectablesMap:EntityTypeConfiguration<Injectables>
    {
        public InjectablesMap()
        {
            this.HasKey(t => t.InjectableId);
            this.Property(t => t.InjectableId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("Injectables");
        }
    }
}