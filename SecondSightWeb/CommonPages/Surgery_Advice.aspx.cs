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
    public partial class Surgery_Advice : System.Web.UI.Page
    {

        IOperationSuggestionService operationSuggestionService = new OperationSuggestionService();
        IOTChargeCategoryService oTChargeCategoryService = new OTChargeCategoryService();
        IOTChargesService oTChargesService = new OTChargesService();

        IOperationCheckListDetailsService operationCheckListDetailsService = new OperationCheckListDetailsService();
        IPatientService patientService = new PatientService();
        IEmployeeService employeeService = new EmployeeService();

        ISequenceService sequenceService = new SequenceService();

        Patient patient = new Patient();
        Employee employee = new Employee();
        Sequence sequence = new Sequence();
        List<OperationCheckListDetails> lstOperationCheckListDetails = new List<OperationCheckListDetails>();
        OperationSuggestion operationSuggestion = new OperationSuggestion();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                lbl_OP_Id.Text = sequenceService.GetById(7).Prefix + "/" + Session["OperationSuggesstionId"].ToString() + "/" + Common_Controle.Common_Methods.GetCurrentFinancialYear().ToString();


                operationSuggestion = operationSuggestionService.GetById(int.Parse(Session["OperationSuggesstionId"].ToString()));
                patient = patientService.GetById(operationSuggestion.PatientId);
                employee = employeeService.GetById(operationSuggestion.RefferedBy);
                cbl_OtCheckList.DataBind();
                var operationDetails = from ocs in oTChargeCategoryService.GetAll()
                                       join och in oTChargesService.GetAll() on ocs.Id equals och.OtCategoryId
                                       where och.OtChargeId == operationSuggestion.OperationCategory
                                       select new
                                       {
                                           och.Name,
                                           ocs.OtChargeCategory
                                       };
                lbl_Ot_Category.Text = operationDetails.Select(x => x.OtChargeCategory).FirstOrDefault();
                lbl_Ot_Procedure.Text = operationDetails.Select(x => x.Name).FirstOrDefault();

                LoadHeaderInformation(patient, employee, System.DateTime.Now);
                LoadSign();

            }
        }

        private void LoadSign()
        {
            IEmployeeService employeeService = new EmployeeService();

            Employee employee = employeeService.GetById(int.Parse(Session["EmployeeId"].ToString()));
            lbl_Gnrtd_By.Text = employee.FirstName + " " + employee.OtherName + " " + employee.LastName;
            lbl_Time_Stamp.Text = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");

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

        protected void cbl_OtCheckList_DataBound(object sender, EventArgs e)
        {
            operationSuggestion = operationSuggestionService.GetById(int.Parse(Session["OperationSuggesstionId"].ToString()));
            lstOperationCheckListDetails = operationCheckListDetailsService.GetAll().Where(x => x.OpeationSuggessitionId == operationSuggestion.Id).ToList();
            foreach (var item in lstOperationCheckListDetails)
            {
                foreach (ListItem lstItem in cbl_OtCheckList.Items)
                {
                    if (int.Parse(lstItem.Value) == item.OtCheckListId)
                    {
                        lstItem.Selected = true;
                    }
                }
            }
        }
    }
}