using SecondSightWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Data.Mappings
{
    public class DoctorExaminationConjuctivaMap:EntityTypeConfiguration<DoctorExaminationConjuctiva>
    {
        public DoctorExaminationConjuctivaMap()
        {
            this.HasKey(t => t.DoctorExaminationConjuctivaId);
            this.Property(t => t.DoctorExaminationConjuctivaId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("DoctorExaminationConjuctiva");
        }
    }
}