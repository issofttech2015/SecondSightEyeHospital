using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre.Models
{
    public class OTCharges
    {
        
        [Key]
        public int OtChargeId { get; set; }
        [DisplayName("OtCharge Category Name")]
        public int OtCategoryId { get; set; }
        [DisplayName("Package Name")]
        public string Name { get; set; }
        [DisplayName("Day Care Charge")]
        [Required(ErrorMessage = "Enter Day Care Charge")]
        public decimal? DayCareCharge { get; set; }
        [DisplayName("Room Charge")]
        [Required(ErrorMessage = "Enter Room Charge")]
        public decimal? RoomCharge { get; set; }
        [DisplayName("Ot Charges")]
        [Required(ErrorMessage = "Enter Ot Charges")]
        public decimal? OtCharges { get; set; }
        [DisplayName("Ot Equipment Charges")]
        [Required(ErrorMessage = "Enter Ot Equipment Charges")]
        public decimal? OtEquipmentCharges { get; set; }
        [DisplayName("Materialsusedin Operation")]
        [Required(ErrorMessage = "Enter Materialsusedin Operation")]
        public decimal? MaterialsusedinOperation { get; set; }
        [DisplayName("Charges for Anaesthesia")]
        [Required(ErrorMessage = "Enter Charges for Anaesthesia")]
        public decimal? ChargesforAnaesthesia { get; set; }
        [DisplayName("Charges for using AnaestheticMachine")]
        [Required(ErrorMessage = "Enter Charges for using AnaestheticMachine")]
        public decimal? ChargesforusingAnaestheticMachine { get; set; }
        [DisplayName("Charges of using Diathermy")]
        [Required(ErrorMessage = "Enter Charges of using Diathermy")]
        public decimal? ChargesofusingDiathermy { get; set; }
        [DisplayName("Endolaser")]
        [Required(ErrorMessage = "Enter Endolaser")]
        public decimal? Endolaser { get; set; }
        [DisplayName("Charges for Cardiac Monitor")]
        [Required(ErrorMessage = "Enter Charges for Cardiac Monitor")]
        public decimal? ChargesforCardiacMonitor { get; set; }
        [DisplayName("Medicines Purchased viscoat")]
        [Required(ErrorMessage = "Enter Medicines Purchased viscoat")]
        public decimal? MedicinesPurchasedviscoat { get; set; }
        [DisplayName("Doctor Fees")]
        [Required(ErrorMessage = "Enter Doctor Fees")]
        public decimal? DoctorFees { get; set; }
        [DisplayName("Diet Charges")]
        [Required(ErrorMessage = "Enter Diet Charges")]
        public decimal? DietCharges { get; set; }
        [DisplayName("Aya Charges")]
        [Required(ErrorMessage = "Enter Aya Charges")]
        public decimal? AyaCharges { get; set; }
        [DisplayName("IOL")]
        [Required(ErrorMessage = "Enter IOL")]
        public decimal? IOL { get; set; }

    }

}
