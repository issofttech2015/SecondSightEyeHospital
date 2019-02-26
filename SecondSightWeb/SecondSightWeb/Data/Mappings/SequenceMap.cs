using SecondSightSouthendEyeCentre.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre.Data.Mappings
{
    public class SequenceMap:EntityTypeConfiguration<Sequence>
    {
        public SequenceMap()
        {
            this.HasKey(t => t.SequenceId);
            this.Property(t => t.SequenceId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);


            this.ToTable("Sequence");
        }
    }
}
