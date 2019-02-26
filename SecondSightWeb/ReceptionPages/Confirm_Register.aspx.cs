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
using SecondSightWeb.Common_Controle;
using SecondSightWeb.Service.Interfaces;
using SecondSightWeb.Service.Implementation;
using SecondSightWeb.Models;
using SecondSightSouthendEyeCentre;

namespace SecondSightWeb.ReceptionPages
{
    public partial class Confirm_Register : System.Web.UI.Page
    {
        private static string commandName = "";
        private static int appointmentId = 0;
        IAppointmentService appointmentService = new AppointmentService();
        IBillService billService = new BillService();
        IPatientService patientService = new PatientService();
        IBillDetailsService BillDetailsService = new BillDetailsService();
        IProcedureRateService procedureRateService = new ProcedureRateService();
        IPaymentDetalisService paymentDetalisService = new PaymentDetalisService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void gv_Appoinment_List_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Select":
                    ClientScript.RegisterStartupScript(this.GetType(), System.Guid.NewGuid().ToString(), "getConfirmation(this, 'Please confirm','Are you sure you want to proceed?');", true);
                    appointmentId = int.Parse(e.CommandArgument.ToString());
                    commandName = "Select";
                    ddl_Doctor.SelectedValue = appointmentService.GetById(appointmentId).DoctorsId.ToString();
                    ddl_Doctor.Visible = true;
                    lbl_Ammount_due.Text = SELECTDAL.Instance.GetDueAmount(appointmentId);
                    break;
                case "Cancel":
                    ClientScript.RegisterStartupScript(this.GetType(), System.Guid.NewGuid().ToString(), "getConfirmation(this, 'Please confirm','Are you sure you want to cancel?');", true);
                    appointmentId = int.Parse(e.CommandArgument.ToString());
                    commandName = "Cancel";
                    ddl_Doctor.Visible = false;
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
                if (appointment.IsNew == true)
                {
                    Response.AddHeader("REFRESH", "2;URL=Register_Patient.aspx?AppointmnetId=" + Common_Methods.Encrypt(appointmentId.ToString()) + "&ConfirmDuplicateEntry=True&Name=" + HttpUtility.UrlEncode(appointment.Name) + "&MobileNo=" + appointment.Mobile + "&Address=" + HttpUtility.UrlEncode(appointment.Address));
                }
                else
                {
                    try
                    {
                        PatId = patientService.GetAll().Where(x => x.PatCode == appointment.PatCode).Select(x => x.PatientId).Last();
                        appointment.IsConfirmed = true;
                        appointment.DoctorsId = int.Parse(ddl_Doctor.SelectedValue.ToString());
                        appointmentService.Update(appointment);
                        ISequenceService sequenceService = new SequenceService();
                        Sequence sequence = sequenceService.GetById(4);
                        SecondSightSouthendEyeCentre.Models.ProcedureRate procedureRate = procedureRateService.GetById(appointment.ProcedureRateId);
                        if (procedureRate != null)
                        {

                            Bill bill = new Bill()
                            {
                                PatientId = PatId,
                                BillAmount = procedureRate.Rate,
                                IsPaid = false,
                                Date = System.DateTime.Now,
                                Purpose = procedureRate.ProcedureName,
                                BillCode = sequence.Prefix + "/" + (sequence.SequenceCode + 1) + "/" + Common_Methods.GetCurrentFinancialYear()
                            };

                            bill = billService.Add(bill);
                            sequence.SequenceCode = sequence.SequenceCode + 1;
                            sequenceService.Update(sequence);
                            BillDetails billDetails = new BillDetails()
                            {
                                BillId = bill.BillId,
                                ProcedureRateId = appointment.ProcedureRateId, //Paid Review or Special Clinic
                                Rate = procedureRate.Rate
                            };
                            BillDetailsService.Add(billDetails);
                        }
                        ShowMessage("Record Added", MessageType.Success);
                        Response.AddHeader("REFRESH", "2;URL=Confirm_Register.aspx");
                    }
                    catch (Exception ex)
                    {
                        ShowMessage(ex.Message + "There was an technical error", MessageType.Error);
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
                    ShowMessage("Appointment Canceled!!!", MessageType.Info);
                    Response.AddHeader("REFRESH", "2;URL=Confirm_Register.aspx");
                }
                catch
                {
                    ShowMessage("There was an technical error", MessageType.Error);
                }
            }
        }
        protected void btn_Print_Excell_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "Appointment_List" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            gv_Appoinment_List.GridLines = GridLines.Both;
            gv_Appoinment_List.HeaderStyle.Font.Bold = true;
            gv_Appoinment_List.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the runtime error "  

        }
        protected void Page_PreInit(Object sender, EventArgs e)
        {
            SecondSightWeb.Common_Controle.Common_Methods.ChangeMasterPage(Page);
        }
    }
}