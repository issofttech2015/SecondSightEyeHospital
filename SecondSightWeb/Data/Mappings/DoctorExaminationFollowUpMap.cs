using SecondSightWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Data.Mappings
{
    public class DoctorExaminationFollowUpMap:EntityTypeConfiguration<DoctorExaminationFollowUp>
    {
        public DoctorExaminationFollowUpMap()
        {
            this.HasKey(t => t.DoctorExaminationFollowUpId);
            this.Property(t => t.DoctorExaminationFollowUpId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("DoctorExaminationFollowUp");
        }
    }
}