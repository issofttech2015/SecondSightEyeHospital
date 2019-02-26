using SecondSightSouthendEyeCentre.Models;
using SecondSightSouthendEyeCentre.Service.Implementation;
using SecondSightSouthendEyeCentre.Service.Interfaces;
using SecondSightWeb.Areas.OtManager.Controllers;
using SecondSightWeb.Data.DbIntractions;
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
    public partial class Pre_Operative_Advice : System.Web.UI.Page
    {
        IOperationSuggestionService operationSuggestionService = new OperationSuggestionService();
        IOTChargeCategoryService oTChargeCategoryService = new OTChargeCategoryService();
        IOTChargesService oTChargesService = new OTChargesService();
        IOperarionDetailsService operarionDetailsService = new OperarionDetailsService();

        IExaminationDropsService examinationDropsService = new ExaminationDropsService();
        IOperationCheckListDetailsService operationCheckListDetailsService = new OperationCheckListDetailsService();
        IPatientService patientService = new PatientService();
        IEmployeeService employeeService = new EmployeeService();

        ISequenceService sequenceService = new SequenceService();

        Patient patient = new Patient();
        Employee employee = new Employee();
        Sequence sequence = new Sequence();
        OperationSuggestion operationSuggestion = new OperationSuggestion();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                lbl_OP_Id.Text = sequenceService.GetById(7).Prefix + "/" + Session["OperationSuggesstionId"].ToString() + "/" + Common_Controle.Common_Methods.GetCurrentFinancialYear().ToString();

                operationSuggestion = operationSuggestionService.GetById(int.Parse(Session["OperationSuggesstionId"].ToString()));
                patient = patientService.GetById(operationSuggestion.PatientId);
                employee = employeeService.GetById(operationSuggestion.RefferedBy);

                lbl_SurgeryScheduled_Procedure.Text = oTChargesService.GetById(operationSuggestion.OperationCategory).Name;

                //Operation Details Set
                OperarionDetails operationDetails = operarionDetailsService.GetById(int.Parse(Session["OperationId"].ToString()));

                lbl_SurgeryScheduled.Text = operationDetails.OperationDate.ToString("dd/MM/yyyy");
                lbl_SurgeryScheduled_Time.Text = operationDetails.Time.ToString();
                lbl_Duration.Text = operationDetails.Duration.ToString();
                lbl_Eye.Text = operationDetails.OperationEye;
                lbl_from_date.Text = (operationDetails.FromDate).ToString("dd/MM/yyyy");
                lbl_to_date.Text = (operationDetails.ToDate).ToString("dd/MM/yyyy");
                lbl_Drop.Text = examinationDropsService.GetById(operationDetails.DropId).DropsName;

                SearchStoreProcedureDB<SumOfOtCharge> searchStoreProcedureDB = new SearchStoreProcedureDB<SumOfOtCharge>();
                SumOfOtCharge Cost_Associated = searchStoreProcedureDB.GetSumOfOtChargeByOtChargeId(operationDetails.SurgicalProcedure).FirstOrDefault();
                lbl_Expense.Text = Cost_Associated.Cost_Associated.ToString();
                LoadHeaderInformation(patient, employee, System.DateTime.Now);
                LoadSign();

            }
        }
        private void LoadHeaderInformation(Patient patient, Employee employee, DateTime date)
        {
            lbl_PatCode.Text = patient.PatCode;
            lbl_Name.Text = patient.FirstName + " " + patient.MiddleName + " " + patient.LastName;
            lbl_Gender.Text = patient.Gender;
            lbl_Age.Text = patient.Age.ToString();
            lbl_Consultant.Text = employee.FirstName + " " + employee.OtherName + " " + employee.LastName;
            lbl_Current_Date.Text = date.ToString("dd/MM/yyyy");
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