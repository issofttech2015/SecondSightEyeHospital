using SecondSightWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Data.Mappings
{
    public class DoctorExaminationLensMap:EntityTypeConfiguration<DoctorExaminationLens>
    {
        public DoctorExaminationLensMap()
        {
            this.HasKey(t => t.DoctorExaminationLensId);
            this.Property(t => t.DoctorExaminationLensId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("DoctorExaminationLens");
        }
    }
}