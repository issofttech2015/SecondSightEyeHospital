using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Models
{
    public class DoctorExaminationFundus
    {
        [Key]
        public int DoctorExaminationFundusId { get; set; }
        public string REFundusUp { get; set; }
        public string REFundusDown { get; set; }
        public string RESpecialConditions { get; set; }
        public string LEFundusUp { get; set; }
        public string LEFundusDown { get; set; }
        public string LESpecialConditions { get; set; }
    }
}