using SecondSightWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Data.Mappings
{
    public class DoctorExaminationCombineMap:EntityTypeConfiguration<DoctorExaminationCombine>
    {
        public DoctorExaminationCombineMap()
        {
            this.HasKey(t => t.DoctorExaminationCombineId);
            this.Property(t => t.DoctorExaminationCombineId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("DoctorExaminationCombine");
        }
    }
}