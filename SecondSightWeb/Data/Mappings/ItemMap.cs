using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using SecondSightSouthendEyeCentre.Models;

namespace SecondSightSouthendEyeCentre.Data.Mappings
{
    public class ItemMap:EntityTypeConfiguration<Item>
    {
        public ItemMap()
        {
            this.HasKey(t => t.ItemId);
            this.Property(t => t.ItemId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("tblItem");
        }
    }
}
