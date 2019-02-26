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

namespace SecondSightWeb.DoctorPages
{
    public partial class Prescription : System.Web.UI.Page
    {
        Patient patient = new Patient();
        Employee employee = new Employee();
        Sequence sequence = new Sequence();
        Treatement treatement = new Treatement();
        List<OperationCheckListDetails> lstOperationCheckListDetails = new List<OperationCheckListDetails>();


        IPatientService patientService = new PatientService();
        IEmployeeService employeeService = new EmployeeService();
        ISequenceService sequenceService = new SequenceService();
        ITreatementService treatementService = new TreatementService();
        IAppointmentService appointmentService = new AppointmentService();
        IOperationCheckListDetailsService operationCheckListDetailsService = new OperationCheckListDetailsService();




        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["TreatmentId"].ToString() != "")
                {
                    treatement = treatementService.GetById(int.Parse(Session["TreatmentId"].ToString()));
                    patient = patientService.GetById(treatement.PatientId);
                    employee = employeeService.GetById(treatement.DoctorId);
                    DateTime date = appointmentService.GetById(treatement.AppointmentId).Time;

                    cbl_OtCheckList.DataBind();
                    lstOperationCheckListDetails = operationCheckListDetailsService.GetAll().Where(x => x.TreatmentId == int.Parse(Session["TreatmentId"].ToString())).ToList();

                    if (lstOperationCheckListDetails.Count == 0)
                        cbl_OtCheckList.Visible = false;


                    lbl_Advice.Text = treatement.Advice;
                    lbl_Disease.Text = treatement.Disease;
                    lbl_CheifComplain.Text = treatement.CheifComplain;
                    lbl_Disease_Eye.Text = treatement.DiseaseEye;
                    lbl_CheifComplain_Eye.Text = treatement.CheifComplainEye;

                    if (treatement.RefferedDoctorName != "" && treatement.RefferedDoctorName != string.Empty)
                    {
                        lbl_RfrDocName.Text = treatement.RefferedDoctorName;
                    }
                    else
                    {
                        lbl_RfrDocName.Visible = false;
                        lbl_rfr_other_doc.Visible = false;
                    }
                    lbl_DOP.Text = treatement.TreatmentDate.ToString("dd/MM/yyyy hh:mm tt");
                    LoadHeaderInformation(patient, employee, date);
                    if (Session["OperationSuggesstionId"] != null)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('../CommonPages/Surgery_Advice.aspx');", true);
                    }
                    LoadSign();
                    if (gv_TestDetails.Rows.Count == 0)
                        lbl_test_details.Visible = false;

                }
            }

        }
        private void LoadHeaderInformation(Patient patient, Employee employee, DateTime date)
        {
            lbl_PatCode.Text = patient.PatCode;
            lbl_Name.Text = patient.FirstName + " " + patient.MiddleName + " " + patient.LastName;
            lbl_Gender.Text = patient.Gender;
            lbl_Age.Text = patient.Age.ToString();
            lbl_Consultant.Text = employee.FirstName + " " + employee.OtherName + " " + employee.LastName;
            lbl_Prescription_No.Text = sequenceService.GetById(6).Prefix + "/" + Session["TreatmentId"].ToString() + "/" + Common_Controle.Common_Methods.GetCurrentFinancialYear();
            lbl_DOA.Text = date.ToString("dd/MM/yyyy hh:mm tt");
        }

        protected void gv_Procedure_Rate_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
        private void LoadSign()
        {
            IEmployeeService employeeService = new EmployeeService();

            Employee employee = employeeService.GetById(int.Parse(Session["EmployeeId"].ToString()));
            lbl_Gnrtd_By.Text = employee.FirstName + " " + employee.OtherName + " " + employee.LastName;
            lbl_Time_Stamp.Text = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        }

        protected void cbl_OtCheckList_DataBound(object sender, EventArgs e)
        {
            lstOperationCheckListDetails = operationCheckListDetailsService.GetAll().Where(x => x.TreatmentId == int.Parse(Session["TreatmentId"].ToString())).ToList();
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