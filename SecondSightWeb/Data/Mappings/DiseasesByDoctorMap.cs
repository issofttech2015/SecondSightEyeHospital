using SecondSightWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Data.Mappings
{
    public class DiseasesByDoctorMap : EntityTypeConfiguration<DiseasesByDoctor>
    { 
        public DiseasesByDoctorMap()
        {
            this.HasKey(t => t.DiseasesByDoctorId);
            this.Property(t => t.DiseasesByDoctorId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("DiseasesByDoctor");
        }
    }
}