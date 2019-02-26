using SecondSightSouthendEyeCentre.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SecondSightSouthendEyeCentre.Data.Mappings
{
    public class DropsNameMap:EntityTypeConfiguration<ExaminationDrops>
    {
        public DropsNameMap()
        {
            this.HasKey(t => t.Id);
            this.Property(t => t.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("ExaminationDrops");
        }
    }
}