using SecondSightWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Data.Mappings
{
    public class DoctorExaminationGonioscopyMap:EntityTypeConfiguration<DoctorExaminationGonioscopy>
    {
        public DoctorExaminationGonioscopyMap()
        {
            this.HasKey(t => t.DoctorExaminationGonioscopyId);
            this.Property(t => t.DoctorExaminationGonioscopyId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("DoctorExaminationGonioscopy");
        }
    }
}