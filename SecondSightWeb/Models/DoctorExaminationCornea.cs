using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Models
{
    public class DoctorExaminationCornea
    {
        [Key]
        public int DoctorExaminationCorneaId { get; set; }

        public string RESclera { get; set; }

        public string RECornea { get; set; }

        public string REAnteriorChamberCentralDepth { get; set; }

        public string REAnteriorChamberPeripheralDepth { get; set; }

        public string REVonHenricksGrading { get; set; }

        public string RESpecialConditions { get; set; }

        public string LESclera { get; set; }

        public string LECornea { get; set; }

        public string LEAnteriorChamberCentralDepth { get; set; }

        public string LEAnteriorChamberPeripheralDepth { get; set; }

        public string LEVonHenricksGrading { get; set; }

        public string LESpecialConditions { get; set; }

    }
}