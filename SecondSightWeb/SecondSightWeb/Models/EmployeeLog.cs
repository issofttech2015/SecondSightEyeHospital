using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre.Models
{
    public class EmployeeLog
    {
        public int EmployeeId { get; set; }

        public string UserId { get; set; }

        public string Password { get; set; }

        public bool? IsLogIn { get; set; }

        public DateTime? LastLogIn { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public int? UpdatedBy { get; set; }

        public bool? IsDeleted { get; set; }

        public int RoleId { get; set; }

    }

}
