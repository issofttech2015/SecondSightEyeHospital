using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Models
{
    public class DoctorExaminationOculerMovement
    {
        [Key]
        public int DoctorExaminationOculerMovementId { get; set; }

        public string REOculerMovement { get; set; }

        public string LEOculerMovement { get; set; }

    }
}