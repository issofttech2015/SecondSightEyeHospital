using SecondSightWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Data.Mappings
{
    public class DoctorExaminationVitreousMap:EntityTypeConfiguration<DoctorExaminationVitreous>
    {
        public DoctorExaminationVitreousMap()
        {
            this.HasKey(t => t.DoctorExaminationVitreousId);
            this.Property(t => t.DoctorExaminationVitreousId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("DoctorExaminationVitreous");
        }
    }
}