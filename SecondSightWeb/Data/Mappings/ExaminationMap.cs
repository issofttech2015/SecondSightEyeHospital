using SecondSightSouthendEyeCentre.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre.Data.Mappings
{
    public class ExaminationMap:EntityTypeConfiguration<Examination>
    {
        public ExaminationMap()
        {
            this.HasKey(t => t.ExaminationId);
            this.Property(t => t.ExaminationId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("Examination");
        }
    }
}
