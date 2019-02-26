using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using SecondSightSouthendEyeCentre.Models;

namespace SecondSightSouthendEyeCentre.Data.Mappings
{
    public class DepartmentMap:EntityTypeConfiguration<Department>
    {
        public DepartmentMap()
        {
            this.HasKey(t => t.DepartmentId);
            this.Property(t => t.DepartmentId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);


            this.ToTable("tblDepartment");
        }
    }
}
