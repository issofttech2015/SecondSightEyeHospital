using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre.Data.Mappings
{
    public class ConsultantExamination2Map: EntityTypeConfiguration<SecondSightSouthendEyeCentre.Models.ConsultantExamination2>
    {
        public ConsultantExamination2Map()
        {
            this.HasKey(t => t.ConsultantExaminationId);
            this.Property(t => t.ConsultantExaminationId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("ConsultantExamination2");
        }
    }
}
