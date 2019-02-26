using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre.Data.Mappings
{
    public class MedicationMap:EntityTypeConfiguration<SecondSightSouthendEyeCentre.Models.Medication>
    {
        public MedicationMap()
        {
            this.HasKey(t => t.MedicationId);
            this.Property(t => t.MedicationId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("Medication");
        }
    }
}
