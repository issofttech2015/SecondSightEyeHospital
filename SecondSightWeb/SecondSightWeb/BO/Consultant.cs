using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre
{
    public class Consultant
    {
        public int ConsultantExaminationId { get; set; }
        public int PatientId { get; set; }
        public int ConsultantId { get; set; }

    }
    public class ConsultantExamination1:Consultant
    { 
        public string ARSPHRE { get; set; }
        public string ARCYLRE { get; set; }
        public string ARAXISRE { get; set; }
        public string ARSPHLE { get; set; }
        public string ARCYLLE { get; set; }
        public string ARAXISLE { get; set; }
        public string NCTOD { get; set; }
        public string NCTOS { get; set; }
    }
    public class ConsultantExamination2:Consultant
    {
        public int CheifComplain { get; set; }
        public int SystematicDisease { get; set; }
        public int Alegry { get; set; }
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
    public class ConsulatntExamination3:Consultant
    {
        public string RatinoscopyPENTOL { get; set; }
        public string RatinoscopyTROPYCALCYPLUS { get; set; }
        public string RatinoscopyATROPIN { get; set; }
        public string PupilOD1 { get; set; }
        public string PupilOD2 { get; set; }
        public string PupilOS1 { get; set; }
        public string PupilOS2 { get; set; }
        public string RappOS { get; set; }
        public string RappOD { get; set; }
        public string AmslergridOS { get; set; }
        public string AmslergridOD { get; set; }
        public string SyringOD { get; set; }
        public string SyringOS { get; set; }
    }
    
}
