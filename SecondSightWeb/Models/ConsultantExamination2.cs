using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre.Models
{
    public class ConsultantExamination2
    {
        public int ConsultantExaminationId { get; set; }

        public int? PatientId { get; set; }

        public int? ConsultantId { get; set; }

        public string CheifComplain { get; set; }

        public string CheifComplainDuration { get; set; }
        public string SystematicDisease { get; set; }
        public string SystematicDiseaseDuration { get; set; }
        public string Alegry { get; set; }
        public string AlegryDuration { get; set; }
        public string PastHistory { get; set; }

        public string FamilyHistory { get; set; }

        public string CurrentTreatment { get; set; }

        public string CurrentInvestigation { get; set; }

        public string VAODUnaided { get; set; }

        public string VAODAided { get; set; }

        public string VAODWithph { get; set; }

        public string VAOSUnaided { get; set; }

        public string VAOSAided { get; set; }

        public string VAOSWithph { get; set; }

        public string VAUnaidedODRemarks { get; set; }

        public string VAAidedODRemarks { get; set; }

        public string VAwithPhODRemarks { get; set; }

        public string VAUnaidedOSRemarks { get; set; }

        public string VAAidedOSRemarks { get; set; }

        public string VAwithPhOSRemarks { get; set; }

        public DateTime? ExaminationDate { get; set; }

    }


}
