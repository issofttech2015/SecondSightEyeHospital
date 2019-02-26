using SecondSightWeb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Areas.Admin.Models.ViewModels
{
    [NotMapped]
    public class MedicineListEditModel:MedicineList
    {
        public IEnumerable<MedicineTypeList> MedicineTypeList { get; set; }
    }
    [NotMapped]
    public class MedicineListViewModel
    {
        public int Id { get; set; }
        public string MedicineName { get; set; }
        public string MedicineTypeShortCode { get; set; }
        public string MedicineTypeName { get; set; }
    }
}