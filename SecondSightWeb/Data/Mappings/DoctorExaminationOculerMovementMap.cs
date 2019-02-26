using SecondSightWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Data.Mappings
{
    public class DoctorExaminationOculerMovementMap:EntityTypeConfiguration<DoctorExaminationOculerMovement>
    {
        public DoctorExaminationOculerMovementMap()
        {
            this.HasKey(t => t.DoctorExaminationOculerMovementId);
            this.Property(t => t.DoctorExaminationOculerMovementId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("DoctorExaminationOculerMovement");
        }
    }
}