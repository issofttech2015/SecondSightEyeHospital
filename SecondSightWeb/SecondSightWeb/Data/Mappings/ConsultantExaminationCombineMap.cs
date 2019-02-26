using SecondSightSouthendEyeCentre.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre.Data.Mappings
{
    public class ConsultantExaminationCombineMap:EntityTypeConfiguration<ConsultantExaminationCombine>
    {
        public ConsultantExaminationCombineMap()
        {
            this.HasKey(t => t.ConsultantExaminationCombineId);
            this.Property(t => t.ConsultantExaminationCombineId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("ConsultantExaminationCombine");
        }
    }
}
