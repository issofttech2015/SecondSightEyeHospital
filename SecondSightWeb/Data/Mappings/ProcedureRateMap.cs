using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre.Data.Mappings
{
    public class ProcedureRateMap:EntityTypeConfiguration<SecondSightSouthendEyeCentre.Models.ProcedureRate>
    {
        public ProcedureRateMap()
        {
            this.HasKey(t => t.Id);
            this.Property(t => t.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("ProcedureRate");
        }
    }
}
