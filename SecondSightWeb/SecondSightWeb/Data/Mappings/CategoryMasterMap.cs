using SecondSightSouthendEyeCentre.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre.Data.Mappings
{
    public class CategoryMasterMap:EntityTypeConfiguration<SecondSightSouthendEyeCentre.Models.CategoryMaster>
    {
        public CategoryMasterMap()
        {
            this.HasKey(t => t.CategoryMasterId);
            this.Property(t => t.CategoryMasterId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("CategoryMaster");
        }
    }
}
