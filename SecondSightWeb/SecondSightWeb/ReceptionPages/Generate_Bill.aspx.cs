using SecondSightSouthendEyeCentre;
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
    public partial class Generate_Bill : System.Web.UI.Page
    {
        IPatientService patientService = new PatientService();
        IBillService billService = new BillService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                var Patients = (from pat in patientService.GetAll()
                                join bill in billService.GetAll() on pat.PatientId equals bill.PatientId
                                where bill.IsPaid == false
                                select new EmployeeShortInfo
                                {
                                    EmployeeId = pat.PatientId,
                                    EmployeeName = pat.PatCode
                                }).ToList().GroupBy(x => new { x.EmployeeName, x.EmployeeId }).Select(x => new EmployeeShortInfo { EmployeeId = x.Key.EmployeeId, EmployeeName = x.Key.EmployeeName });
                ddl_Patient.Items.Clear();
                ddl_Patient.DataSource = Patients;
                ddl_Patient.DataTextField = "EmployeeName";
                ddl_Patient.DataValueField = "EmployeeId";
                ddl_Patient.DataBind();
                ddl_Patient.Items.Insert(0, new ListItem("--Select--", "0"));

            }
        }
        public enum MessageType { Success, Error, Info, Warning };
        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }

        protected void btn_Submit_Bill_Click(object sender, EventArgs e)
        {
            if (ddl_Purpose.SelectedIndex != 0)
            {

                //Bill bill = (Bill)cmbPurpose.SelectedItem;
                Bill updateBill = billService.GetById(int.Parse(ddl_Purpose.SelectedValue.ToString()));
                updateBill.ModeOfPayment = RadioButtonList1.SelectedValue.ToString();
                updateBill.ChequeNo = txt_Cheque_No.Text;
                updateBill.PaymentDateTime = DateTime.Parse(txt_Dated.Text);
                updateBill.InAccountOf = txt_Account_Of.Text;
                updateBill.IsPaid = true;

                updateBill = billService.Update(updateBill);

                //if (updateBill.OperationId != 0)
                //{
                //    button4.Visible = false;
                //    button5.Visible = true;
                //}
                //else
                //{
                //    button4.Visible = true;
                //    button5.Visible = false;
                //}
                if (updateBill.IsPaid == true)
                {
                    ShowMessage("Record Updated", MessageType.Success);
                    Session["Bill_Id"] = updateBill.BillId;
                    Response.AddHeader("REFRESH", "1;URL=Bill_Money_Recipt.aspx");
                }
                else
                {
                    ShowMessage("Something Went wrong!!!", MessageType.Error);
                }
            }
        }

        protected void ddl_Patient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_Patient.SelectedIndex != 0)
            {
                SecondSightSouthendEyeCentre.Models.Patient patient = new SecondSightSouthendEyeCentre.Models.Patient();
                patient = patientService.GetById(int.Parse(ddl_Patient.SelectedValue.ToString()));
                txt_Pat_Name.Text = patient.FirstName + " " + patient.MiddleName + " " + patient.LastName;
                var bills = billService.GetAll().Where(x => x.PatientId == patient.PatientId && x.IsPaid == false).ToList();
                ddl_Purpose.Items.Clear();
                ddl_Purpose.DataSource = bills;
                ddl_Purpose.DataValueField = "BillId";
                ddl_Purpose.DataTextField = "Purpose";
                ddl_Purpose.DataBind();
                ddl_Purpose.Items.Insert(0, new ListItem("--Select--", "0"));
                ddl_Purpose.SelectedIndex = 0;

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

        protected void ddl_Purpose_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_Purpose.SelectedIndex != 0)
            {
                Bill bill = billService.GetById(int.Parse(ddl_Purpose.SelectedValue.ToString()));

                txt_Rupes.Text = bill.BillAmount.ToString();
                txt_Rupes_Words.Text = ConvertNumbertoWords((long)bill.BillAmount);
                //if (bill.OperationId != 0)
                //{
                //    button4.Visible = false;
                //    button5.Visible = true;
                //    OperationId = bill.OperationId;
                //    BillId = bill.BillId;
                //}
            }
        }
    }
}