using SecondSightWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Data.Mappings
{
    public class DoctorExaminationGlassPrescriptionMap:EntityTypeConfiguration<DoctorExaminationGlassPrescription>
    {
        public DoctorExaminationGlassPrescriptionMap()
        {
            this.HasKey(t => t.DoctorExaminationGlassPrescriptionId);
            this.Property(t => t.DoctorExaminationGlassPrescriptionId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("DoctorExaminationGlassPrescription");
        }
    }
}