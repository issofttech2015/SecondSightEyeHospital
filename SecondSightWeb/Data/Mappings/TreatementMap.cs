using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using System.Threading.Tasks;
using SecondSightSouthendEyeCentre.Models;

namespace SecondSightSouthendEyeCentre.Data.Mappings
{
    public class TreatementMap:EntityTypeConfiguration<Treatement>
    {
        public TreatementMap()
        {
            this.HasKey(t => t.TreatmentId);
            this.Property(t => t.TreatmentId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("Treatement");
        }
    }
}
