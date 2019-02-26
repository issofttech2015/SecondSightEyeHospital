using SecondSightSouthendEyeCentre.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre.Data.Mappings
{
    public class BillSummeryMap:EntityTypeConfiguration<BillSummery>
    {
        public BillSummeryMap()
        {
            this.HasKey(t => t.BillSummeryId);
            this.Property(t => t.BillSummeryId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("BillSummery");
        }
    }
}
