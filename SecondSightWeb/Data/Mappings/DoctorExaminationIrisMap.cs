using SecondSightWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Data.Mappings
{
    public class DoctorExaminationIrisMap:EntityTypeConfiguration<DoctorExaminationIris>
    {
        public DoctorExaminationIrisMap()
        {
            this.HasKey(t => t.DoctorExaminationIrisId);
            this.Property(t => t.DoctorExaminationIrisId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("DoctorExaminationIris");
        }
    }
}