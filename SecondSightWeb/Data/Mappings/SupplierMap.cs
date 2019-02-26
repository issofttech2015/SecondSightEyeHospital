using SecondSightSouthendEyeCentre.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre.Data.Mappings
{
    public class SupplierMap:EntityTypeConfiguration<Supplier>
    {
        public SupplierMap()
        {
            this.HasKey(t => t.SupplierId);
            this.Property(t => t.SupplierId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("Supplier");
        }
    }
}
