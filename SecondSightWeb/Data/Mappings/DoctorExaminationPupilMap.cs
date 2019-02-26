using SecondSightWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Data.Mappings
{
    public class DoctorExaminationPupilMap:EntityTypeConfiguration<DoctorExaminationPupil>
    {
        public DoctorExaminationPupilMap()
        {
            this.HasKey(t => t.DoctorExaminationPupilId);
            this.Property(t => t.DoctorExaminationPupilId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("DoctorExaminationPupil");
        }
    }
}