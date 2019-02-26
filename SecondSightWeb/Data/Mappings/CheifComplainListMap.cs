using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using SecondSightSouthendEyeCentre.Models;

namespace SecondSightSouthendEyeCentre.Data.Mappings
{
    public class CheifComplainListMap:EntityTypeConfiguration<CheifComplainList>
    {
        public CheifComplainListMap()
        {
            this.HasKey(t => t.Id);
            this.Property(t => t.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("CheifComplainList");
        }
    }
}
