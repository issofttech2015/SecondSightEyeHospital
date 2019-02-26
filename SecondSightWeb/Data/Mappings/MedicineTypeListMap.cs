using SecondSightWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Data.Mappings
{
    public class MedicineTypeListMap:EntityTypeConfiguration<MedicineTypeList>
    {
        public MedicineTypeListMap()
        {
            this.HasKey(t => t.MedicineTypeId);
            this.Property(t => t.MedicineTypeId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("MedicineTypeList");
        }
    }
}