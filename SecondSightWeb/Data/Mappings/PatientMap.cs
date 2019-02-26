using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using System.Threading.Tasks;
using SecondSightSouthendEyeCentre.Models;

namespace SecondSightSouthendEyeCentre.Data.Mappings
{
    public class PatientMap:EntityTypeConfiguration<Patient>
    {
        public PatientMap()
        {
            this.HasKey(t => t.PatientId);
            this.Property(t => t.PatientId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("tblPatient");
        }
    }
}
