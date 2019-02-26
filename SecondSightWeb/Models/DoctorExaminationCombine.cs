using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Models
{
    public class DoctorExaminationCombine
    {
        [Key]
        public int DoctorExaminationCombineId { get; set; }
        public int DoctorExaminationGlassPrescriptionId { get; set; }
        public int DoctorExaminationLensId { get; set; }
        public int DoctorExaminationPupilId { get; set; }
        public int DoctorExaminationIrisId { get; set; }
        public int DoctorExaminationConjuctivaId { get; set; }
        public int DoctorExaminationDiagnosisId { get; set; }
        public int DoctorExaminationCorneaId { get; set; }
        public int DoctorExaminationIntraOcularPressureId { get; set; }
        public int DoctorExaminationFollowUpId { get; set; }
        public int TreatmentId { get; set; }
        public int DoctorExaminationGonioscopyId { get; set; }
        public DateTime Date { get; set; }
        public bool isDeleted { get; set; }
        public int? DoctorExaminationOcularAlignmentId { get; set; }
        public int? DoctorExaminationOculerMovementId { get; set; }
        public int? DoctorExaminationVitreousId { get; set; }
        public int? DoctorExaminationFundusId { get; set; }
    }
}