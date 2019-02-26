using SecondSightSouthendEyeCentre;
using SecondSightSouthendEyeCentre.Models;
using SecondSightSouthendEyeCentre.Service.Implementation;
using SecondSightSouthendEyeCentre.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecondSightWeb.ReceptionPages
{
    public partial class Register_Patient : System.Web.UI.Page
    {
        ISequenceService _iSequenceService = new SequenceService();
        IAppointmentService appointmentService = new AppointmentService();
        IBillService billService = new BillService();
        IPatientService patientService = new PatientService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Sequence sequence = _iSequenceService.GetById(1);
                int seq = sequence.SequenceCode + 1;
                lbl_Pat_Code.Text = sequence.Prefix + "/" + seq;
                Set_Name_MobileNo_Add();
            }
        }
        public enum MessageType { Success, Error, Info, Warning };

        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }
        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            Patitent patient = new Patitent()
            {
                FirstName = txt_First_Name.Text,
                MiddeleName = txt_Middle_Name.Text,
                LastName = txt_Last_Name.Text,
                Gender = rbt_Gender.SelectedItem.ToString(),
                DateofBirth = DateTime.ParseExact(txt_Date_Of_Birth.Text, "MM/dd/yyyy HH:mm tt", System.Globalization.CultureInfo.InvariantCulture),
                Natationality = txt_Nationality.Text,
                Age = int.Parse(txt_Age.Text),
                Contact = decimal.Parse(txt_Contact.Text),
                ResidanceAddress = txt_Address.Text,
                Email = txt_Email.Text,
                GuardianFirstName = txt_Guardaion_First_Name.Text,
                GuardianLastName = txt_Guardaion_Last_Name.Text,
                GuardianContact = decimal.Parse(txt_Guardaion_Contact.Text),
                GuardianRelateAs = "",
                Ocupation = "",
                PatCode = lbl_Pat_Code.Text,
                Adhar = txt_Adhar.Text
            };
            bool result = INSERTDAL.Instance.AddPatient(patient);

            if (!result)
            {
                ShowMessage("There was an technical error", MessageType.Error);
            }
            else
            {
                int appointmentId = 0;
                if (!string.IsNullOrWhiteSpace(Decrypt(Request.QueryString["AppointmnetId"])) && int.TryParse(Decrypt(Request.QueryString["AppointmnetId"]), out appointmentId))
                {
                    if (Decrypt(Request.QueryString["AppointmnetId"]) != "0")
                    {
                        try
                        {
                            Appointment appointments = appointmentService.GetById(int.Parse(Decrypt(Request.QueryString["AppointmnetId"])));
                            appointments.PatCode = lbl_Pat_Code.Text;
                            appointmentService.Update(appointments);
                            int patientId = patientService.GetAll().Where(x => x.PatCode == lbl_Pat_Code.Text).Select(x => x.PatientId).Last();
                            Bill bill = new Bill()
                            {
                                PatientId = patientId,
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
                else
                {
                    ShowMessage("You have violated the security policy of the application", MessageType.Info);
                }
                ShowMessage("Record Added", MessageType.Success);
                Response.AddHeader("REFRESH", "2;URL=Register_Patient.aspx?AppointmnetId=0");
            }
        }
        public static string Decrypt(string encryptText)
        {
            string encryptionkey = "SAUW193BX628TD57";
            byte[] keybytes = Encoding.ASCII.GetBytes(encryptionkey.Length.ToString());
            RijndaelManaged rijndaelCipher = new RijndaelManaged();
            byte[] encryptedData = Convert.FromBase64String(encryptText.Replace(" ", "+"));
            PasswordDeriveBytes pwdbytes = new PasswordDeriveBytes(encryptionkey, keybytes);
            using (ICryptoTransform decryptrans = rijndaelCipher.CreateDecryptor(pwdbytes.GetBytes(32), pwdbytes.GetBytes(16)))
            {
                using (MemoryStream mstrm = new MemoryStream(encryptedData))
                {
                    using (CryptoStream cryptstm = new CryptoStream(mstrm, decryptrans, CryptoStreamMode.Read))
                    {
                        byte[] plainText = new byte[encryptedData.Length];
                        int decryptedCount = cryptstm.Read(plainText, 0, plainText.Length);
                        return Encoding.Unicode.GetString(plainText, 0, decryptedCount);
                    }
                }
            }


        }

        protected  void Set_Name_MobileNo_Add()
        {
            int appointmentId = 0;
            if (!string.IsNullOrWhiteSpace(Decrypt(Request.QueryString["AppointmnetId"])) && int.TryParse(Decrypt(Request.QueryString["AppointmnetId"]), out appointmentId))
            {
                if (Request.QueryString["Name"] != "")
                {
                    txt_First_Name.Text = HttpUtility.UrlDecode(Request.QueryString["Name"]);
                }
                if (Request.QueryString["MobileNo"] != "")
                {
                    txt_Contact.Text = Request.QueryString["MobileNo"].ToString();
                }
                if (Request.QueryString["Address"] != "")
                {
                    txt_Address.Text = HttpUtility.UrlDecode(Request.QueryString["Address"]);
                }
            }

        }
    }
}