using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using System.Threading.Tasks;
using SecondSightSouthendEyeCentre.Models;

namespace SecondSightSouthendEyeCentre.Data.Mappings
{
    public class StoreHistoryMap:EntityTypeConfiguration<StoreHistory>
    {
        public StoreHistoryMap()
        {
            this.HasKey(t => t.StoreHistoryId);
            this.Property(t => t.StoreHistoryId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("tblStoreHistory");
        }
    }
}
