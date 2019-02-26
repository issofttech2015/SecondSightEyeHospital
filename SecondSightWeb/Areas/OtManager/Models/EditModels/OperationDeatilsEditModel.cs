using SecondSightSouthendEyeCentre;
using SecondSightSouthendEyeCentre.Models;
using SecondSightWeb.Areas.OtManager.Models.DTO;
using SecondSightWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Areas.OtManager.Models.EditModels
{
    public class OperationDetailsEditModel
    {
        public Patient Patient { get; set; }
        public OperarionDetails OperarionDetails { get; set; }
        public OperationSuggestion OperationSuggestion { get; set; }
        public IEnumerable<EmployeeShortInfo> Doctors { get; set; }
        public IEnumerable<OTChargeCategory> OTChargeCategories { get; set; }
        public IEnumerable<OTCharges> SurgicalProcedure { get; set; }
        public List<OtCheckList> OtCheckLists { get; set; }
        public int OperationId { get; set; }
        public IEnumerable<ExaminationDrops> ExaminationDrops { get; set; }
    }
}