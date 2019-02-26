using SecondSightWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Data.Mappings
{
    public class CheifComplainByDoctorMap : EntityTypeConfiguration<CheifComplainByDoctor>
    {
        public CheifComplainByDoctorMap()
        {
            this.HasKey(t => t.CheifComplainByDoctorId);
            this.Property(t => t.CheifComplainByDoctorId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("CheifComplainByDoctor");
        }
    }
}