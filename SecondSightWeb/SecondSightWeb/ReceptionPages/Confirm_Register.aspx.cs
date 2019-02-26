using SecondSightSouthendEyeCentre.Models;
using SecondSightSouthendEyeCentre.Service.Implementation;
using SecondSightSouthendEyeCentre.Service.Interfaces;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace SecondSightWeb.ReceptionPages
{
    public partial class Confirm_Register : System.Web.UI.Page
    {
        private static string commandName = "";
        private static int appointmentId = 0;
        IAppointmentService appointmentService = new AppointmentService();
        IBillService billService = new BillService();
        IPatientService patientService = new PatientService();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gv_Appoinment_List_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Select":
                    ClientScript.RegisterStartupScript(this.GetType(), System.Guid.NewGuid().ToString(), "getConfirmation(this, 'Please confirm','Are you sure you want to proceed?');", true);
                    appointmentId = int.Parse(e.CommandArgument.ToString());
                    commandName = "Select";
                    break;
                case "Cancel":
                    ClientScript.RegisterStartupScript(this.GetType(), System.Guid.NewGuid().ToString(), "getConfirmation(this, 'Please confirm','Are you sure you want to cancel?');", true);
                    appointmentId = int.Parse(e.CommandArgument.ToString());
                    commandName = "Cancel";
                    break;

            }
        }
        public enum MessageType { Success, Error, Info, Warning };

        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }
        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('"+ appointmentId+commandName +"')", true);
            int PatId = 0;
            if (commandName == "Select" && appointmentId != 0)
            {
                Appointment appointment = appointmentService.GetById(appointmentId);
                if (appointment.IsNew)
                {
                    Response.AddHeader("REFRESH", "2;URL=Register_Patient.aspx?AppointmnetId=" + Encrypt(appointmentId.ToString()) + "&Name=" + HttpUtility.UrlEncode(appointment.Name) + "&MobileNo=" + appointment.Mobile + "&Address=" + HttpUtility.UrlEncode(appointment.Address));
                }
                else
                {
                    try
                    {
                        PatId = patientService.GetAll().Where(x => x.PatCode == appointment.PatCode).Select(x => x.PatientId).Last();
                        appointment.IsConfirmed = true;
                        appointmentService.Update(appointment);
                        Bill bill = new Bill()
                        {
                            PatientId = PatId,
                            BillAmount = 100,
                            IsPaid = false,
                            Date = System.DateTime.Now,
                            Purpose = "New Registration/Paid Review"
                        };
                        billService.Add(bill);
                        ShowMessage("Record Added", MessageType.Success);
                        Response.AddHeader("REFRESH", "2;URL=Confirm_Register.aspx");
                    }
                    catch
                    {
                        ShowMessage("There was an technical error", MessageType.Error);
                    }
                }
            }
            else if (commandName == "Cancel" && appointmentId != 0)
            {
                Appointment appointment = appointmentService.GetById(appointmentId);
                try
                {
                    appointment.IsCanceled = true;
                    appointmentService.Update(appointment);
                    ShowMessage("Record Added", MessageType.Success);
                    Response.AddHeader("REFRESH", "2;URL=Confirm_Register.aspx");
                }
                catch
                {
                    ShowMessage("There was an technical error", MessageType.Error);
                }
            }
        }
        public string Encrypt(string inputText)
        {
            string encryptionkey = "SAUW193BX628TD57";
            byte[] keybytes = Encoding.ASCII.GetBytes(encryptionkey.Length.ToString());
            RijndaelManaged rijndaelCipher = new RijndaelManaged();
            byte[] plainText = Encoding.Unicode.GetBytes(inputText);
            PasswordDeriveBytes pwdbytes = new PasswordDeriveBytes(encryptionkey, keybytes);
            using (ICryptoTransform encryptrans = rijndaelCipher.CreateEncryptor(pwdbytes.GetBytes(32), pwdbytes.GetBytes(16)))
            {
                using (MemoryStream mstrm = new MemoryStream())
                {
                    using (CryptoStream cryptstm = new CryptoStream(mstrm, encryptrans, CryptoStreamMode.Write))
                    {
                        cryptstm.Write(plainText, 0, plainText.Length);
                        cryptstm.Close();
                        return Convert.ToBase64String(mstrm.ToArray());
                    }
                }
            }
        }
    }
}