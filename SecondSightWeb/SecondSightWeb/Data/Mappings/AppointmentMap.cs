using SecondSightSouthendEyeCentre.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre.Data.Mappings
{
    public class AppointmentMap:EntityTypeConfiguration<Appointment>
    {
        public AppointmentMap()
        {
            this.HasKey(t => t.AppointmentId);
            this.Property(t => t.AppointmentId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("Appointment");
        }
    }
}
