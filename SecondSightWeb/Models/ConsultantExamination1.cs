using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre.Models
{
    public class ConsultantExamination1
    {
        public int ConsultantExaminationId { get; set; }

        public int? PatientId { get; set; }

        public int? ConsultantId { get; set; }

        public string ARSPHRE { get; set; }

        public string ARCYLRE { get; set; }

        public string ARAXISRE { get; set; }

        public string ARSPHLE { get; set; }

        public string ARCYLLE { get; set; }

        public string ARAXISLE { get; set; }

        public string NCTOD { get; set; }

        public string NCTOS { get; set; }
        public DateTime ExaminationDate { get; set; }

    }

}
