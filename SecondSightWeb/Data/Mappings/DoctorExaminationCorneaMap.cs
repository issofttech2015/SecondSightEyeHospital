using SecondSightWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Data.Mappings
{
    public class DoctorExaminationCorneaMap:EntityTypeConfiguration<DoctorExaminationCornea>
    {
        public DoctorExaminationCorneaMap()
        {
            this.HasKey(t => t.DoctorExaminationCorneaId);
            this.Property(t => t.DoctorExaminationCorneaId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("DoctorExaminationCornea");
        }
    }
}