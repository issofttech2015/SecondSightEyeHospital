using SecondSightSouthendEyeCentre.Models;
using SecondSightWeb.Areas.OtManager.Models.DTO;
using SecondSightWeb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Areas.OtManager.Models.ViewModels
{
    public class SurgicalConsumptionViewModel
    {
        public IEnumerable<OpeartionDetailsDTO> OpeartionDetailsDTO { get; set; }
        public IEnumerable<Knives> Knives { get; set; }
        public IEnumerable<ExaminationDrops> ExaminationDrops { get; set; }
        public IEnumerable<Injectables> Injectables { get; set; }
        public IEnumerable<Disposables> Disposables { get; set; }
        public IEnumerable<Tablets> Tablets { get; set; }
        public IEnumerable<Miscellaneous> Miscellaneous { get; set; }
        public IEnumerable<StoreHistory> StoreHistory { get; set; }
        //public IEnumerable<StoreHistory> StoreHistoryDisposables { get; set; }
        //public IEnumerable<StoreHistory> StoreHistoryKnives { get; set; }
        //public IEnumerable<StoreHistory> StoreHistoryMiscellaneous { get; set; }
        //public IEnumerable<StoreHistory> StoreHistoryTablets { get; set; }
        //public IEnumerable<StoreHistory> StoreHistoryDrops { get; set; }
        public OperarionDetails OperarionDetails { get; set; }
        [Required(ErrorMessage = "Please Enter Batch Number")]
        [DisplayName("Batch Number")]
        public string BatchNumber { get; set; }
        [Required(ErrorMessage = "Please Enter Knive Name")]
        [DisplayName("Knive Details")]
        public int KniveId { get; set; } = 0;
        [Required(ErrorMessage = "Please Enter Drop Name")]
        [DisplayName("Drop Name")]
        public int DropId { get; set; } = 0;
        [Required(ErrorMessage = "Please Enter Injectable Name")]
        [DisplayName("Injectable Name")]
        public int InjectableId { get; set; } = 0;
        [Required(ErrorMessage = "Please Enter Disponsable Name")]
        [DisplayName("Disponsable Name")]
        public int DisponsableId { get; set; } = 0;
        [Required(ErrorMessage = "Please Enter Tablet Name")]
        [DisplayName("Tablet Name")]
        public int TabletId { get; set; } = 0;
        [Required(ErrorMessage = "Please Enter Miscellaneous Name")]
        [DisplayName("Miscellaneous Name")]
        public int MiscellaneousId { get; set; } = 0;
       
    }
}