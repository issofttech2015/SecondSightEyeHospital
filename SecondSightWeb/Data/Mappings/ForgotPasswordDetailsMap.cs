using SecondSightWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Data.Mappings
{
    public class ForgotPasswordDetailsMap: EntityTypeConfiguration<ForgotPasswordDetails>
    {
        public ForgotPasswordDetailsMap()
        {
            this.HasKey(t => t.ForgotPasswordId);
            this.Property(t => t.ForgotPasswordId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("ForgotPasswordDetails");
        }
    }
}