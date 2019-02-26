using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using SecondSightSouthendEyeCentre.Models;

namespace SecondSightSouthendEyeCentre.Data.Mappings
{
    public class ConsultantExamination1Map:EntityTypeConfiguration<SecondSightSouthendEyeCentre.Models.ConsultantExamination1>
    {
        public ConsultantExamination1Map()
        {
            this.HasKey(t => t.ConsultantExaminationId);
            this.Property(t => t.ConsultantExaminationId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("ConsultantExamination1");
        }
    }
}
