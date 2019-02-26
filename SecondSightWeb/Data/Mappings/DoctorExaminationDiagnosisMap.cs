using SecondSightWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Data.Mappings
{
    public class DoctorExaminationDiagnosisMap:EntityTypeConfiguration<DoctorExaminationDiagnosis>
    {
        public DoctorExaminationDiagnosisMap()
        {
            this.HasKey(t => t.DoctorExaminationDiagnosisId);
            this.Property(t => t.DoctorExaminationDiagnosisId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("DoctorExaminationDiagnosis");
        }
    }
}