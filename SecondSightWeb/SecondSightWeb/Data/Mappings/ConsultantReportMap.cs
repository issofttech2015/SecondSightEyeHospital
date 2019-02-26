using SecondSightSouthendEyeCentre.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre.Data.Mappings
{
    public class ConsultantReportMap:EntityTypeConfiguration<ConsultantReport>
    {
        public ConsultantReportMap()
        {
            this.HasKey(t=>t.ConsultantReportId);
            this.Property(t => t.ConsultantReportId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);


            this.ToTable("ConsultantReport");
        }
    }
}
