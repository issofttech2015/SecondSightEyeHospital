using SecondSightWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Data.Mappings
{
    public class OperationCheckListDetailsMap:EntityTypeConfiguration<OperationCheckListDetails>
    {
        public OperationCheckListDetailsMap()
        {
            this.HasKey(t => t.DetailsId);
            this.Property(t => t.DetailsId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("OperationCheckListDetails");
        }
    }
}