using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using SecondSightSouthendEyeCentre.Models;

namespace SecondSightSouthendEyeCentre.Data.Mappings
{
    public class CategoryMap:EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            this.HasKey(t => t.CategoryId);
            this.Property(t => t.CategoryId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("tblCategoryMaster");
        }
    }
}
