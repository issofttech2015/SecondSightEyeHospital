using SecondSightWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Data.Mappings
{
    public class DoctorExaminationOcularAlignmentMap:EntityTypeConfiguration<DoctorExaminationOcularAlignment>
    {
        public DoctorExaminationOcularAlignmentMap()
        {
            this.HasKey(t => t.DoctorExaminationOcularAlignmentId);
            this.Property(t => t.DoctorExaminationOcularAlignmentId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("DoctorExaminationOcularAlignment");
        }
    }
}