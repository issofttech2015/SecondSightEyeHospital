using SecondSightSouthendEyeCentre.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre.Data.Mappings
{
    public class TreatmentDetailsMap:EntityTypeConfiguration<TreatmentDetails>
    {
        public TreatmentDetailsMap()
        {
            this.HasKey(t => t.TreatmentDetailsId);
            this.Property(t => t.TreatmentDetailsId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("TreatmentDetails");
        }
    }
}
