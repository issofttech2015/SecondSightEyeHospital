using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Areas.Admin.Models.ViewModels
{
    public class OTChargesViewModel
    {
        [Key]
        public int OtChargeId { get; set; }
        [DisplayName("OtCharge Category Name")]
        public string OtChargeCategory { get; set; }
        [DisplayName("Package Name")]
        public string Name { get; set; }
        [DisplayName("Day Care Charge")]
        public decimal? DayCareCharge { get; set; }
        [DisplayName("Room Charge")]
        public decimal? RoomCharge { get; set; }
        [DisplayName("Ot Charges")]
        public decimal? OtCharges { get; set; }
        [DisplayName("Ot Equipment Charges")]
        public decimal? OtEquipmentCharges { get; set; }
        [DisplayName("Materialsusedin Operation")]
        public decimal? MaterialsusedinOperation { get; set; }
        [DisplayName("Charges for Anaesthesia")]
        public decimal? ChargesforAnaesthesia { get; set; }
        [DisplayName("Charges for using AnaestheticMachine")]
        public decimal? ChargesforusingAnaestheticMachine { get; set; }
        [DisplayName("Charges of using Diathermy")]
        public decimal? ChargesofusingDiathermy { get; set; }
        [DisplayName("Endolaser")]
        public decimal? Endolaser { get; set; }
        [DisplayName("Charges for Cardiac Monitor")]
        public decimal? ChargesforCardiacMonitor { get; set; }
        [DisplayName("Medicines Purchased viscoat")]
        public decimal? MedicinesPurchasedviscoat { get; set; }
        [DisplayName("Doctor Fees")]
        public decimal? DoctorFees { get; set; }
        [DisplayName("Diet Charges")]
        public decimal? DietCharges { get; set; }
        [DisplayName("Aya Charges")]
        public decimal? AyaCharges { get; set; }
        [DisplayName("IOL")]
        public decimal? IOL { get; set; }
    }
}