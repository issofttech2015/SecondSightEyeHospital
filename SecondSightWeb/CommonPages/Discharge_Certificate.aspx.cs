using SecondSightSouthendEyeCentre.Models;
using SecondSightSouthendEyeCentre.Service.Implementation;
using SecondSightSouthendEyeCentre.Service.Interfaces;
using SecondSightWeb.Models;
using SecondSightWeb.Service.Implementation;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecondSightWeb.CommonPages
{
    public partial class Discharge_Certificate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Operation_Id"].ToString() != "")
                {
                    IOperarionDetailsService operarionDetailsService = new OperarionDetailsService();
                    IOperationSuggestionService operationSuggestionService = new OperationSuggestionService();
                    IPatientService patientService = new PatientService();
                    IEmployeeService employeeService = new EmployeeService();
                    IDischargeDetailsService dischargeDetailsService = new DischargeDetailsService();
                    IOTChargesService oTChargesService = new OTChargesService();
                    ISequenceService sequenceService = new SequenceService();



                    lbl_Current_Date.Text = System.DateTime.Now.ToString();
                    lbl_OP_Id.Text = sequenceService.GetById(7).Prefix + "/" + Session["Operation_Id"].ToString() + "/" + Common_Controle.Common_Methods.GetCurrentFinancialYear().ToString();
                    OperarionDetails operarionDetails = operarionDetailsService.GetById(int.Parse(Session["Operation_Id"].ToString()));
                    OperationSuggestion operationSuggestion = operationSuggestionService.GetById(operarionDetails.OperationSuggestionId);
                    Patient patient = patientService.GetById(operarionDetails.PatientId);
                    Employee employee = employeeService.GetById(operationSuggestion.RefferedBy);
                    lbl_PatCode.Text = patient.PatCode;
                    lbl_Name.Text = patient.FirstName + " " + patient.MiddleName + " " + patient.LastName;
                    lbl_Gender.Text = patient.Gender;
                    lbl_Age.Text = patient.Age.ToString();
                    lbl_Consultant.Text = employee.FirstName + " " + employee.OtherName + " " + employee.LastName;

                    lbl_Date_Admission.Text = operarionDetails.FromDate.ToString("dd/MM/yyyy");
                    lbl_Date_Operation.Text = operarionDetails.OperationDate.ToString("dd/MM/yyyy");
                    DischargeDetails dischargeDetails = dischargeDetailsService.GetAll().Where(x => x.OperationId == operarionDetails.OperationId).FirstOrDefault();
                    lbl_Date_Discharge.Text = dischargeDetails.DischargeDate.ToString("dd/MM/yyyy");
                    lbl_Surgery_Name.Text = oTChargesService.GetById(operarionDetails.SurgicalProcedure).Name;
                    lbl_Eye.Text = operarionDetails.OperationEye;
                    lbl_Diagonosis.Text = dischargeDetails.Diagonosis;
                    lbl_Report_Date.Text = dischargeDetails.NextVisitDate.ToString("dd/MM/yyyy");
                    lbl_Report_Time.Text = dischargeDetails.NextVisitTime.ToString();
                    lbl_Addnl_Comments.Text = dischargeDetails.AdditionalComments;
                    lbl_Emergency_Contact_Number.Text = employee.Contact.ToString();
                    LoadSign();

                }
            }
        }
        private void LoadSign()
        {
            IEmployeeService employeeService = new EmployeeService();

            Employee employee = employeeService.GetById(int.Parse(Session["EmployeeId"].ToString()));
            lbl_Gnrtd_By.Text = employee.FirstName + " " + employee.OtherName + " " + employee.LastName;
            lbl_Time_Stamp.Text = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        }
    }
}