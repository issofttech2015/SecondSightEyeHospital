using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using System.Threading.Tasks;
using SecondSightSouthendEyeCentre.Models;

namespace SecondSightSouthendEyeCentre.Data.Mappings
{
    public class EmployeeLogMap:EntityTypeConfiguration<EmployeeLog>
    {
        public EmployeeLogMap()
        {
            this.HasKey(t => t.EmployeeId);
            this.Property(t => t.EmployeeId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("tblEmployeeLog");
        }
    }
}
