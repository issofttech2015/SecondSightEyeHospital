using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre.Data.Mappings
{
    public class DiseasesMap:EntityTypeConfiguration<SecondSightSouthendEyeCentre.Models.Diseases>
    {
        public DiseasesMap()
        {
            this.HasKey(t => t.DiseasesId);
            this.Property(t => t.DiseasesId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("Diseases");
        }
    }
}
