using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using System.Threading.Tasks;
using SecondSightSouthendEyeCentre.Models;

namespace SecondSightSouthendEyeCentre.Data.Mappings
{
    public class SystemicDiseaseMap:EntityTypeConfiguration<SystemicDisease>
    {
        public SystemicDiseaseMap()
        {
            this.HasKey(t => t.DiseaseId);
            this.Property(t => t.DiseaseId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("SystemicDisease");
        }
    }
}
