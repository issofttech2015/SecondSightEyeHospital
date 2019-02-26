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
    public partial class Operation_Final_Bill : System.Web.UI.Page
    {
        IOperationSuggestionService operationSuggestionService = new OperationSuggestionService();
        IOTChargesService oTChargesService = new OTChargesService();
        IOperarionDetailsService operarionDetailsService = new OperarionDetailsService();

        //IOperationCheckListDetailsService operationCheckListDetailsService = new OperationCheckListDetailsService();
        IPatientService patientService = new PatientService();
        IEmployeeService employeeService = new EmployeeService();

        Patient patient = new Patient();
        Employee employee = new Employee();
        Sequence sequence = new Sequence();
        OperationSuggestion operationSuggestion = new OperationSuggestion();
        OperarionDetails operarionDetails = new OperarionDetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_OP_Id.Text = Session["OperationId"].ToString();
            operarionDetails = operarionDetailsService.GetById(int.Parse(Session["OperationId"].ToString()));
            operationSuggestion = operationSuggestionService.GetById(operarionDetails.OperationSuggestionId);
            lbl_Operation_Date.Text = operarionDetails.OperationDate.ToString("dd/MM/yyyy");
            lbl_Current_Date.Text = System.DateTime.Now.ToString("dd/MM/yyyy");

            lbl_Surgery_Procedure.Text = oTChargesService.GetById(operarionDetails.SurgicalProcedure).Name;


            patient = patientService.GetById(operationSuggestion.PatientId);
            employee = employeeService.GetById(operationSuggestion.RefferedBy);
            LoadHeaderInformation(patient, employee, System.DateTime.Now);
            LoadSign();

        }
        private void LoadHeaderInformation(Patient patient, Employee employee, DateTime date)
        {
            lbl_PatCode.Text = patient.PatCode;
            lbl_Name.Text = patient.FirstName + " " + patient.MiddleName + " " + patient.LastName;
            lbl_Gender.Text = patient.Gender;
            lbl_Age.Text = patient.Age.ToString();
            lbl_Consultant.Text = employee.FirstName + " " + employee.OtherName + " " + employee.LastName;
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