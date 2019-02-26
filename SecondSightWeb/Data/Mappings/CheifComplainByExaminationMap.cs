using SecondSightWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Data.Mappings
{
    public class CheifComplainByExaminationMap: EntityTypeConfiguration<CheifComplainByExamination>
    {
        public CheifComplainByExaminationMap()
        {
            this.HasKey(t => t.CheifComplainByExaminationId);
            this.Property(t => t.CheifComplainByExaminationId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("CheifComplainByExamination");
        }
    }
}