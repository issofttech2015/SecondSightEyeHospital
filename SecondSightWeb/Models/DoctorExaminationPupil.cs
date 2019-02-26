using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Models
{
    
    public class DoctorExaminationPupil
    {
        [Key]
        public int DoctorExaminationPupilId { get; set; }

        public string RESize { get; set; }

        public string REShape { get; set; }

        public string REReactionOfLight { get; set; }

        public string RERemarks { get; set; }

        public string REUpperLidMargin { get; set; }

        public string RELowerLidMargin { get; set; }

        public string REUpperLash { get; set; }

        public string RELowerLash { get; set; }

        public string REUpperPunctum { get; set; }

        public string RELowerPunctum { get; set; }

        public string RESpecialConditions { get; set; }

        public string LESize { get; set; }

        public string LEShape { get; set; }

        public string LEReactionOfLight { get; set; }

        public string LERemarks { get; set; }

        public string LEUpperLidMargin { get; set; }

        public string LELowerLidMargin { get; set; }

        public string LEUpperLash { get; set; }

        public string LELowerLash { get; set; }

        public string LEUpperPunctum { get; set; }

        public string LELowerPunctum { get; set; }

        public string LESpecialConditions { get; set; }

    }
}