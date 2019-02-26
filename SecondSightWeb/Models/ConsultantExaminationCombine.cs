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

        public int ConsultantExaminationId1 { get; set; }

        public int ConsultantExaminationId2 { get; set; } = 0;

        public int ConsultantExaminationId3 { get; set; } = 0;

        public int PatientId { get; set; }

        public int ConsultantId { get; set; }

        public DateTime Date { get; set; } = System.DateTime.Now;
        public int AppointmentId { get; set; }


    }

}
