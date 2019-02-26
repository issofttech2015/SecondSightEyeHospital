using SecondSightWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Data.Mappings
{
    public class DoctorExaminationFundusMap:EntityTypeConfiguration<DoctorExaminationFundus>
    {
        public DoctorExaminationFundusMap()
        {
            this.HasKey(t => t.DoctorExaminationFundusId);
            this.Property(t => t.DoctorExaminationFundusId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("DoctorExaminationFundus");
        }
    }
}