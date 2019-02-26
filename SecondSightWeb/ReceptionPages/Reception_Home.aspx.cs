using SecondSightSouthendEyeCentre;
using SecondSightSouthendEyeCentre.Models;
using SecondSightSouthendEyeCentre.Service.Implementation;
using SecondSightSouthendEyeCentre.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecondSightWeb.ReceptionPages
{
    public partial class Reception_Home : System.Web.UI.Page
    {
        //ISequenceService _iSequenceService = new SequenceService();
        //private static int seq = 0;
        //private static bool IsNew = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Sequence sequence = _iSequenceService.GetById(1);
                //seq = sequence.SequenceCode + 1;
                txt_PatCode_Ins.Text = "New Patient";
            }
        }
        static List<PatientDetails> employeeDetails = new List<PatientDetails>();
        static bool confirmDuplicate = false;
        protected void btn_Serach_Click(object sender, EventArgs e)
        {
            try
            {
                //var patientObj = SecondSightSouthendEyeCentre.SELECTDAL.Instance.GetPatientDetails(txt_PatCode.Text, txt_MobileNumber_Search.Text);
                //txt_PatCode_Ins.Text = patientObj.Item2;
                //txt_PatName.Text = patientObj.Item1;
                //txt_Address.Text = patientObj.Item3;
                //txtMobile.Text = patientObj.Item5;
                ////txt_Adhar.Text = patientObj.Item4;
                //lbl_PatientId.Text = patientObj.Item6;
                employeeDetails.Clear();

                employeeDetails = SELECTDAL.Instance.GetEmployeeDetailsInDetails(txt_PatCode.Text, txt_MobileNumber_Search.Text);

                if (employeeDetails.Count > 1)
                {
                    gv_List_Patient.DataSource = employeeDetails;
                    gv_List_Patient.DataBind();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "openPatientList();", true);
                    confirmDuplicate = true;
                }
                else if (employeeDetails.Count == 1) 
                {
                    txt_PatCode_Ins.Text = employeeDetails[0].patCode;
                    txt_PatName.Text = employeeDetails[0].patName;
                    txt_Address.Text = employeeDetails[0].address;
                    txtMobile.Text = employeeDetails[0].contact;
                    //txt_Adhar.Text = patientObj.Item4;
                    lbl_PatientId.Text = employeeDetails[0].patentId;
                    confirmDuplicate = true;
                }

                try
                {
                    if (chk_IsNew.SelectedItem.Selected == true)
                    {
                        chk_IsNew.SelectedItem.Selected = false;
                    }
                }
                catch
                {
                    ShowMessage("Kindly check before submitting!! New Ptient or Not", MessageType.Warning);
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Warning);
            }
            //Search

        }
        public enum MessageType { Success, Error, Info, Warning };

        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }
        protected void btn_Search_Appointment_Click(object sender, EventArgs e)
        {
            if (txt_Date_Serach.Text != "")
            {
                grd_Appontment_Details.DataSource = null;
                grd_Appontment_Details.DataSourceID = "ds_AppointmentList_WF_Doctor_Time";
                grd_Appontment_Details.DataBind();
            }
            else
            {
                grd_Appontment_Details.DataSource = null;
                grd_Appontment_Details.DataSourceID = "ds_AppointmentList_WF_Doctor";
                grd_Appontment_Details.DataBind();
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "openpopup();", true);

        }
        IPatientService patientService = new PatientService();
        IBillService billService = new BillService();
        IAppointmentService appointmentService = new AppointmentService();
        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            if (patientService.GetAll().Where(x => x.Contact == decimal.Parse(txtMobile.Text)).Select(x => x.PatientId).FirstOrDefault() != 0 && !confirmDuplicate && txt_PatCode_Ins.Text== "New Patient")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "openConfirmation();", true);
                return;
            }
            else if ((txt_PatCode_Ins.Text == "" && chk_IsNew.SelectedValue.ToString() != "1") || txt_PatCode_Ins.Text == "")
            {
                ShowMessage("Kindly check the details before submitting!! New Ptient or Not", MessageType.Warning);
                return;
            }
            else if (appointmentService.GetAll().Where(x => x.Time == DateTime.ParseExact(txt_Appointment_Date.Text, "dd/MM/yyyy HH:mm tt", System.Globalization.CultureInfo.InvariantCulture) && x.DoctorsId==int.Parse(ddl_Doctors.SelectedValue.ToString())).Select(y => y.AppointmentId).FirstOrDefault() != 0)
            {
                ShowMessage("There was already an appointment scheduled on that particular time", MessageType.Warning);
                return;
            }
            else if(rbl_type_Of_Appointment.SelectedIndex<=-1)
            {
                ShowMessage("Select Clinic type!!!", MessageType.Warning);
                return;
            }
            try
            {

                Appointments appointments = new Appointments()
                {
                    AppointmentType = rbtAppointmentType.SelectedValue.ToString(),
                    PatientName = txt_PatName.Text,
                    MobileNo = txtMobile.Text,
                    Address = txt_Address.Text,
                    DoctorsId = int.Parse(ddl_Doctors.SelectedValue.ToString()),
                    PatCode = "",
                    Time = DateTime.ParseExact(txt_Appointment_Date.Text, "dd/MM/yyyy HH:mm tt", System.Globalization.CultureInfo.InvariantCulture),
                    IsAttented = false,
                    ProcedureRateId = int.Parse(rbl_type_Of_Appointment.SelectedValue.ToString()),
                    //Time=dtpStartTime.Value,
                    //Comments = txtNote.Text
                };
                //if (txt_PatCode_Ins.Text != "New Patient")
                //{
                var appointment = appointmentService.GetAll().Where(x => x.PatCode == txt_PatCode_Ins.Text && x.ProcedureRateId != 0).OrderByDescending(x => x.Time).FirstOrDefault();
                if (appointment != null)
                {
                    switch (appointment.ProcedureRateId)
                    {
                        case 2:
                            if ((appointments.Time - appointment.Time).TotalDays <= 7)
                                appointments.ProcedureRateId = 0;
                            break;
                        case 8:
                            if ((appointments.Time - appointment.Time).TotalDays <= 15)
                                appointments.ProcedureRateId = 0;
                            break;
                    }
                }
                //}
                if (chk_IsNew.SelectedValue.ToString() == "1" || txt_PatCode_Ins.Text == "New Patient")
                {
                    appointments.IsNew = true;
                }
                else
                {
                    appointments.PatCode = txt_PatCode_Ins.Text;
                }

                bool result = INSERTDAL.Instance.AddAppointment(appointments);
                SecondSightSouthendEyeCentre.Models.Patient patient = new SecondSightSouthendEyeCentre.Models.Patient();

                //if (chk_IsNew.SelectedValue.ToString() == "1")
                //{
                //    //patient.FirstName = txt_PatName.Text;
                //    //patient.Contact = decimal.Parse(txtMobile.Text);
                //    //patient.Adhar = Decimal.Parse(txt_Adhar.Text);
                //    //patient.ResidanceAddress = txt_Address.Text;
                //    //patient.PatCode = txt_PatCode_Ins.Text;
                //    //patient.Nationality = "Indian";
                //    //patient.DateofBirth = System.DateTime.Now;
                //    //patient.MiddleName = "";
                //    //patient.LastName = "";
                //    //patient.Age = 0;
                //    //patient = patientService.Add(patient);
                //    //Sequence sequence = _iSequenceService.GetById(1);
                //    //sequence.SequenceCode = seq;
                //    //_iSequenceService.Update(sequence);
                //}
                //if (patient.PatientId != 0)
                //{
                //    patientId = patient.PatientId;
                //}
                //else
                //{
                //    patientId = int.Parse(lbl_PatientId.Text);
                //}
                //Bill bill = new Bill()
                //{
                //    PatientId = patientId,
                //    BillAmount = 100,
                //    IsPaid = false,
                //    Date = System.DateTime.Now,
                //    Purpose = "New Registration/Paid Review"
                //};
                //billService.Add(bill);
                if (!result)
                {
                    ShowMessage("There was an technical error", MessageType.Error);
                }
                else
                {
                    ShowMessage("Record Added", MessageType.Success);
                    Response.AddHeader("REFRESH", "1;URL=Reception_Home.aspx");
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message+"There was an technical error", MessageType.Error);
            }
        }

        protected void chk_IsNew_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chk_IsNew.SelectedValue.ToString() == "1")
            {
                //Sequence sequence = _iSequenceService.GetById(1);
                //seq = sequence.SequenceCode + 1;
                //txt_PatCode_Ins.Text = sequence.Prefix + "/" + seq;
                txt_PatCode_Ins.Text = "New Patient";
                confirmDuplicate = false;
            }
            else
            {
                if (employeeDetails.Count > 0)
                {
                    PatientDetails patientDetails = employeeDetails.Where(x => x.patentId == lbl_PatientId.Text).FirstOrDefault();
                    txt_PatCode_Ins.Text = patientDetails.patCode;
                    txt_PatName.Text = patientDetails.patName;
                    txt_Address.Text = patientDetails.address;
                    txtMobile.Text = patientDetails.contact;
                    //txt_Adhar.Text = patientObj.Item4;
                    lbl_PatientId.Text = patientDetails.patentId;
                    confirmDuplicate = false;
                }
            }

        }
        protected void Page_PreInit(Object sender, EventArgs e)
        {
            SecondSightWeb.Common_Controle.Common_Methods.ChangeMasterPage(Page);
        }

        protected void gv_List_Patient_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Select":
                    PatientDetails patientDetails = employeeDetails.Where(x => x.patentId == e.CommandArgument.ToString()).FirstOrDefault();
                    txt_PatCode_Ins.Text = patientDetails.patCode;
                    txt_PatName.Text = patientDetails.patName;
                    txt_Address.Text = patientDetails.address;
                    txtMobile.Text = patientDetails.contact;
                    //txt_Adhar.Text = patientObj.Item4;
                    lbl_PatientId.Text = patientDetails.patentId;
                    break;
            }
        }

        protected void btn_Change_State_Click(object sender, EventArgs e)
        {
            chk_IsNew.SelectedValue = "1";
            confirmDuplicate = true;
        }
    }
}