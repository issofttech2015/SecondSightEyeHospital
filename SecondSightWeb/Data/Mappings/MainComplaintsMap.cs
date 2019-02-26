using SecondSightWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Data.Mappings
{
    public class MainComplaintsMap:EntityTypeConfiguration<MainComplaints>
    {
        public MainComplaintsMap()
        {
            this.HasKey(t => t.MainComplaintsId);
            this.Property(t => t.MainComplaintsId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.ToTable("MainComplaints");
        }
    }
}