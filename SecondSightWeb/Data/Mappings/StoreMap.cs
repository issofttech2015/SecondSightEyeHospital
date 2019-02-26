using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using System.Threading.Tasks;
using SecondSightSouthendEyeCentre.Models;

namespace SecondSightSouthendEyeCentre.Data.Mappings
{
    public class StoreMap:EntityTypeConfiguration<Store>
    {
        public StoreMap()
        {
            this.HasKey(t => t.Storeid);
            this.Property(t => t.Storeid).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("tblStore");
        }
    }
}
