using SecondSightSouthendEyeCentre.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre.Data.Mappings
{
    public class OperarionDetailsMap:EntityTypeConfiguration<OperarionDetails>
    {
        public OperarionDetailsMap()
        {
            this.HasKey(t => t.OperationId);
            this.Property(t => t.OperationId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("OperarionDetails");
        }
    }
}
