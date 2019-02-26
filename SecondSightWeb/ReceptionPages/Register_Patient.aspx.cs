using SecondSightSouthendEyeCentre;
using SecondSightSouthendEyeCentre.Models;
using SecondSightSouthendEyeCentre.Service.Implementation;
using SecondSightSouthendEyeCentre.Service.Interfaces;
using SecondSightWeb.Common_Controle;
using SecondSightWeb.Models;
using SecondSightWeb.Service.Implementation;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Services;
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
        IBillDetailsService BillDetailsService = new BillDetailsService();
        IProcedureRateService procedureRateService = new ProcedureRateService();
        private static string imageName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Request.InputStream.Length > 0)
                {
                    using (StreamReader reader = new StreamReader(Request.InputStream))
                    {
                        string hexString = Server.UrlEncode(reader.ReadToEnd());
                        imageName = DateTime.Now.ToString("dd-MM-yy hh-mm-ss");
                        string imagePath = string.Format("~/Captures/{0}.png", imageName);
                        File.WriteAllBytes(Server.MapPath(imagePath), ConvertHexToBytes(hexString));
                        Session["CapturedImage"] = ResolveUrl(imagePath);
                    }
                }
                else
                {
                    Set_Name_MobileNo_Add();
                }
            }
        }
        public enum MessageType { Success, Error, Info, Warning };
        private static byte[] ConvertHexToBytes(string hex)
        {
            byte[] bytes = new byte[hex.Length / 2];
            for (int i = 0; i < hex.Length; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }
            return bytes;
        }
        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }
        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            if (patientService.GetAll().Where(x => x.Contact == decimal.Parse(txt_Contact.Text)).Select(x => x.PatientId).FirstOrDefault() != 0)
            {
                if (!string.IsNullOrWhiteSpace(Request.QueryString["ConfirmDuplicateEntry"]))
                {
                    if (!bool.Parse(Request.QueryString["ConfirmDuplicateEntry"].ToString()))
                    {
                        ShowMessage("The Patient already exist", MessageType.Warning);
                        return;
                    }
                }

            }




            Patitent patient = new Patitent()
            {
                FirstName = txt_First_Name.Text,
                MiddeleName = "",
                LastName = "",
                Gender = rbt_Gender.SelectedItem.ToString(),
                //DateofBirth = DateTime.ParseExact(txt_Date_Of_Birth.Text, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                Natationality = txt_Nationality.Text,
                Age = int.Parse(txt_Age.Text),
                Contact = decimal.Parse(txt_Contact.Text),
                ResidanceAddress = txt_Address.Text,
                Email = txt_Email.Text,
                GuardianFirstName = txt_Guardaion_First_Name.Text,
                GuardianLastName = txt_Guardaion_Last_Name.Text,
                GuardianContact = txt_Guardaion_Contact.Text,
                GuardianRelateAs = "",
                Ocupation = "",
                PatCode = lbl_Pat_Code.Text,
                Pat_Image = imageName + ".png",
                Month = int.Parse(txt_Month.Text)
            };
            if (txt_Date_Of_Birth.Text != "")
            {
                patient.DateofBirth = DateTime.ParseExact(txt_Date_Of_Birth.Text, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            }
            else
            {
                patient.DateofBirth = System.DateTime.Now;
            }
            if (!string.IsNullOrEmpty(txt_Adhar.Text))
            {
                patient.Adhar = txt_Adhar.Text;
            }
            else
            {
                patient.Adhar = "0";
            }
            // Get Pat_Code 
            Sequence sequencePatcode = _iSequenceService.GetById(1);
            int seq = sequencePatcode.SequenceCode + 1;
            lbl_Pat_Code.Text = sequencePatcode.Prefix + "/" + seq + "/" + Common_Methods.GetCurrentFinancialYear();
            patient.PatCode = lbl_Pat_Code.Text;

            bool result = INSERTDAL.Instance.AddPatient(patient);

            if (!result)
            {
                ShowMessage("There was an technical error", MessageType.Error);
            }
            else
            {
                int appointmentId = 0;
                if (!string.IsNullOrWhiteSpace(Common_Methods.Decrypt(Request.QueryString["AppointmnetId"])) && int.TryParse(Common_Methods.Decrypt(Request.QueryString["AppointmnetId"]), out appointmentId))
                {
                    if (Common_Methods.Decrypt(Request.QueryString["AppointmnetId"]) != "0")
                    {
                        try
                        {
                            Appointment appointments = appointmentService.GetById(int.Parse(Common_Methods.Decrypt(Request.QueryString["AppointmnetId"])));
                            appointments.PatCode = lbl_Pat_Code.Text;
                            appointments.IsConfirmed = true;
                            appointmentService.Update(appointments);
                            int patientId = patientService.GetAll().Where(x => x.PatCode == lbl_Pat_Code.Text).Select(x => x.PatientId).Last();
                            Sequence sequence = _iSequenceService.GetById(4);
                            SecondSightSouthendEyeCentre.Models.ProcedureRate procedureRate = procedureRateService.GetById(appointments.ProcedureRateId);
                            Bill bill = new Bill()
                            {
                                PatientId = patientId,
                                BillAmount = procedureRate.Rate,
                                IsPaid = false,
                                Date = System.DateTime.Now,
                                Purpose = "New Registration/Paid Review",
                                BillCode = sequence.Prefix + "/" + (sequence.SequenceCode + 1) + "/" + Common_Methods.GetCurrentFinancialYear()

                            };
                            bill = billService.Add(bill);
                            sequence.SequenceCode = sequence.SequenceCode + 1;
                            _iSequenceService.Update(sequence);
                            BillDetails billDetails = new BillDetails()
                            {
                                BillId = bill.BillId,
                                ProcedureRateId = 1, //New Registration
                                Rate = procedureRate.Rate
                            };
                            BillDetailsService.Add(billDetails);
                            ShowMessage("Record Added", MessageType.Success);
                            setBtnAndPage(2);
                            //Response.AddHeader("REFRESH", "2;URL=Confirm_Register.aspx");
                        }
                        catch
                        {
                            ShowMessage("There was an technical error", MessageType.Error);
                        }
                    }
                    else
                    {
                        ShowMessage("Record Added", MessageType.Success);
                        setBtnAndPage(1);
                        //Response.AddHeader("REFRESH", "2;URL=Register_Patient.aspx?AppointmnetId=hQdEbL9E+MN+mfUsXMd5EQ==&ConfirmDuplicateEntry=True");
                    }
                }
                else
                {
                    ShowMessage("You have violated the security policy of the application", MessageType.Info);
                }

            }
        }

        private void setBtnAndPage(int page)
        {
            btn_Submit.Enabled = false;
            btn_Submit.Visible = false;
            switch (page)
            {
                case 1:
                    btn_Cancel.Text = "New Patient Register";
                    btn_Cancel.PostBackUrl = "~/ReceptionPages/Register_Patient.aspx?AppointmnetId=hQdEbL9E+MN+mfUsXMd5EQ==&ConfirmDuplicateEntry=True";
                    break;
                case 2:
                    btn_Cancel.Text = "Go Confirm Register";
                    btn_Cancel.PostBackUrl = "~/ReceptionPages/Confirm_Register.aspx";
                    break;
            }

        }

        protected void Set_Name_MobileNo_Add()
        {
            int appointmentId = 0;
            if (!string.IsNullOrWhiteSpace(Common_Methods.Decrypt(Request.QueryString["AppointmnetId"])) && int.TryParse(Common_Methods.Decrypt(Request.QueryString["AppointmnetId"]), out appointmentId))
            {
                if (!string.IsNullOrWhiteSpace(Request.QueryString["Name"]))
                {
                    txt_First_Name.Text = HttpUtility.UrlDecode(Request.QueryString["Name"]);
                }
                if (!string.IsNullOrWhiteSpace(Request.QueryString["MobileNo"]))
                {
                    txt_Contact.Text = Request.QueryString["MobileNo"].ToString();
                }
                if (!string.IsNullOrWhiteSpace(Request.QueryString["Address"]))
                {
                    txt_Address.Text = HttpUtility.UrlDecode(Request.QueryString["Address"]);
                }
            }

        }
        [WebMethod(EnableSession = true)]
        public static string GetCapturedImage()
        {
            string url = HttpContext.Current.Session["CapturedImage"].ToString();
            HttpContext.Current.Session["CapturedImage"] = null;
            return url;
        }
        protected void Page_PreInit(Object sender, EventArgs e)
        {
            SecondSightWeb.Common_Controle.Common_Methods.ChangeMasterPage(Page);
        }
    }
}