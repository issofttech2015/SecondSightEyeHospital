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

        public int? CheifComplain { get; set; }

        public int? SystematicDisease { get; set; }

        public int? Alegry { get; set; }

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

        public string VAODRemarks { get; set; }

        public string VAOSRemarks { get; set; }

    }

}
