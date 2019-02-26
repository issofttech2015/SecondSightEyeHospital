using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre.Data.Mappings
{
    public class EmployeeMap:EntityTypeConfiguration<SecondSightSouthendEyeCentre.Models.Employee>
    {
        public EmployeeMap()
        {
            this.HasKey(t => t.EmployeeId);
            this.Property(t => t.EmployeeId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("tblEmployee");
        }
    }
}
