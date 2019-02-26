using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using System.Threading.Tasks;
using SecondSightSouthendEyeCentre.Models;

namespace SecondSightSouthendEyeCentre.Data.Mappings
{
    public class OTCahargesMap:EntityTypeConfiguration<OTCaharges>
    {
        public OTCahargesMap()
        {
            this.HasKey(t => t.OtCahargeId);
            this.Property(t => t.OtCahargeId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("OTCaharges");
        }
    }
}
