using SecondSightWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Data.Mappings
{
    public class DisposablesMap: EntityTypeConfiguration<Disposables>
    {
        public DisposablesMap()
        {
            this.HasKey(t => t.DisposableId);
            this.Property(t => t.DisposableId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("Disposables");
        }
    }
}