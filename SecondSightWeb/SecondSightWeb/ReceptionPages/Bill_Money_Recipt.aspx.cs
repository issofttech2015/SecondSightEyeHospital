using SecondSightSouthendEyeCentre.Models;
using SecondSightSouthendEyeCentre.Service.Implementation;
using SecondSightSouthendEyeCentre.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecondSightWeb.ReceptionPages
{
    public partial class Bill_Money_Recipt : System.Web.UI.Page
    {
        IPatientService patientService = new PatientService();
        IBillService billService = new BillService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bill bill = billService.GetById(int.Parse(Session["Bill_Id"].ToString()));
                SecondSightSouthendEyeCentre.Models.Patient patient = patientService.GetById(bill.PatientId);
                lbl_Bill_No.Text = bill.BillId.ToString();
                lbl_Date.Text = System.DateTime.Now.ToString("dd/mm/yyyy");
                lbl_Name.Text = patient.FirstName + " " + patient.MiddleName + " " + patient.LastName;
                lbl_For.Text = bill.Purpose;
                lbl_sum_of_rs.Text = ConvertNumbertoWords((long)bill.BillAmount);
                lbl_type.Text = bill.ModeOfPayment + " " + bill.ChequeNo;
                lbl_Account_of.Text = bill.InAccountOf;
                lbl_Bill_Amount.Text = bill.BillAmount.ToString();
            }
        }
        private string ConvertNumbertoWords(long number)
        {
            if (number == 0) return "ZERO";
            if (number < 0) return "minus " + ConvertNumbertoWords(Math.Abs(number));
            string words = "";
            if ((number / 1000000) > 0)
            {
                words += ConvertNumbertoWords(number / 100000) + " LAKHS ";
                number %= 1000000;
            }
            if ((number / 1000) > 0)
            {
                words += ConvertNumbertoWords(number / 1000) + " THOUSAND ";
                number %= 1000;
            }
            if ((number / 100) > 0)
            {
                words += ConvertNumbertoWords(number / 100) + " HUNDRED ";
                number %= 100;
            }
            //if ((number / 10) > 0)  
            //{  
            // words += ConvertNumbertoWords(number / 10) + " RUPEES ";  
            // number %= 10;  
            //}  
            if (number > 0)
            {
                if (words != "") words += "AND ";
                var unitsMap = new[]
                {
            "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN"
        };
                var tensMap = new[]
                {
            "ZERO", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY"
        };
                if (number < 20) words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0) words += " " + unitsMap[number % 10];
                }
            }
            return words;
        }
    }
}