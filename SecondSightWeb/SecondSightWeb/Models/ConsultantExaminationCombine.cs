using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre.Models
{
    public class ConsultantExaminationCombine
    {
        public int ConsultantExaminationCombineId { get; set; }

        public int? ConsultantExaminationId1 { get; set; }

        public int? ConsultantExaminationId2 { get; set; }

        public int? ConsultantExaminationId3 { get; set; }

        public int? PatientId { get; set; }

        public int? ConsultantId { get; set; }

    }

}
