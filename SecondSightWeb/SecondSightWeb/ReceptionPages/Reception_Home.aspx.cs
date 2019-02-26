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
    public partial class Reception_Home : System.Web.UI.Page
    {
        ISequenceService _iSequenceService = new SequenceService();
        private static int seq = 0;
        private static bool IsNew = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Sequence sequence = _iSequenceService.GetById(1);
                //seq = sequence.SequenceCode + 1;
                txt_PatCode_Ins.Text = "New Patient";
            }
        }

        protected void btn_Serach_Click(object sender, EventArgs e)
        {
            //Search
            var patientObj = SecondSightSouthendEyeCentre.SELECTDAL.Instance.GetPatientDetails(txt_PatCode.Text, txt_MobileNumber_Search.Text);
            txt_PatCode_Ins.Text = patientObj.Item2;
            txt_PatName.Text = patientObj.Item1;
            txt_Address.Text = patientObj.Item3;
            txtMobile.Text = patientObj.Item5;
            //txt_Adhar.Text = patientObj.Item4;
            lbl_PatientId.Text = patientObj.Item6;
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
        public enum MessageType { Success, Error, Info, Warning };
        protected void ddl_Doctors_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
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
        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            //int patientId = 0;
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
                    IsAttented = false

                    //Time=dtpStartTime.Value,
                    //Comments = txtNote.Text
                };
                if (chk_IsNew.SelectedValue.ToString() == "1")
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
                ShowMessage("There was an technical error", MessageType.Error);
            }
        }

        protected void chk_IsNew_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chk_IsNew.SelectedValue.ToString() == "1")
            {
                Sequence sequence = _iSequenceService.GetById(1);
                seq = sequence.SequenceCode + 1;
                txt_PatCode_Ins.Text = sequence.Prefix + "/" + seq;
            }

        }
    }
}