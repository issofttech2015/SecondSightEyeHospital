using SecondSightWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Data.Mappings
{
    public class OperationSuggestionMap:EntityTypeConfiguration<OperationSuggestion>
    {
        public OperationSuggestionMap()
        {
            this.HasKey(t => t.Id);
            this.Property(t => t.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("OperationSuggestion");
        }
    }
}