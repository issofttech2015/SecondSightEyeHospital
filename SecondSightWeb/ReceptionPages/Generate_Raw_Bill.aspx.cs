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
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecondSightWeb.ReceptionPages
{
    public partial class Generate_Raw_Bill : System.Web.UI.Page
    {
        IPatientService patientService = new PatientService();
        IBillService billService = new BillService();
        IProcedureRateService procedureRateService = new ProcedureRateService();
        IBillDetailsService BillDetailsService = new BillDetailsService();
        IPaymentDetalisService paymentDetalisService = new PaymentDetalisService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var Patients = (from pat in patientService.GetAll()
                                join bill in billService.GetAll() on pat.PatientId equals bill.PatientId
                                //where bill.IsPaid == false
                                select new EmployeeShortInfo
                                {
                                    EmployeeId = pat.PatientId,
                                    EmployeeName = pat.PatCode
                                }).ToList().GroupBy(x => new { x.EmployeeName, x.EmployeeId }).Select(x => new EmployeeShortInfo { EmployeeId = x.Key.EmployeeId, EmployeeName = x.Key.EmployeeName }).OrderByDescending(y => y.EmployeeId);
                ddl_Patient.Items.Clear();
                ddl_Patient.DataSource = Patients;
                ddl_Patient.DataTextField = "EmployeeName";
                ddl_Patient.DataValueField = "EmployeeId";
                ddl_Patient.DataBind();
                ddl_Patient.Items.Insert(0, new ListItem("--Select--", "0"));
            }
        }

        protected void ddl_Patient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_Patient.SelectedIndex != 0)
            {
                SecondSightSouthendEyeCentre.Models.Patient patient = new SecondSightSouthendEyeCentre.Models.Patient();
                patient = patientService.GetById(int.Parse(ddl_Patient.SelectedValue.ToString()));
                txt_Pat_Name.Text = patient.FirstName + " " + patient.MiddleName + " " + patient.LastName;
            }
        }
        private decimal Money = 0;
        protected void chk_ProcedureRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (ListItem itemsProcedureReate in chk_ProcedureRate.Items)
                {
                    if (itemsProcedureReate.Selected)
                    {
                        Money += procedureRateService.GetById(int.Parse(itemsProcedureReate.Value)).Rate;
                        txt_Rupes.Text = string.Format("{0:0.00}", Money);
                        lbl_Pay_Amount.Text = string.Format("{0:0.00}", (Money - decimal.Parse(txt_Concession_Amount.Text)));
                        txt_Rupes_Words.Text = Common_Methods.ConvertNumbertoWords((long)Money);
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.ToString(), MessageType.Error);
                //txt_Purpose.Text = ex.ToString();
            }
        }
        public enum MessageType { Success, Error, Info, Warning };
        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }
        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddl_Patient.SelectedIndex != 0)
                {
                    decimal Amount = 0;
                    bool tempIsPaid;
                    bool tempIsSettlementDone = false;
                    ISequenceService sequenceService = new SequenceService();
                    IProcedureRateService procedureRateService = new ProcedureRateService();
                    if (chk_Settlement.SelectedValue.ToString() == "1")
                    {
                        Amount = decimal.Parse(txt_Settlement.Text);
                        tempIsSettlementDone = true;
                        tempIsPaid = false;
                    }
                    else
                    {
                        Amount = decimal.Parse(txt_Rupes.Text) - decimal.Parse(txt_Concession_Amount.Text);
                        tempIsSettlementDone = false;
                        tempIsPaid = true;
                    }
                   
                    Bill bill = new Bill()
                    {
                        PatientId = int.Parse(ddl_Patient.SelectedValue.ToString()),
                        BillAmount = decimal.Parse(txt_Rupes.Text),
                        OperationId = 0,
                        Date = System.DateTime.Now,
                        Purpose = "",
                        ModeOfPayment = RadioButtonList1.SelectedValue.ToString(),
                        ChequeNo = txt_Cheque_No.Text,
                        PaymentDateTime = System.DateTime.Now,
                        IsPaid = tempIsPaid,
                        //BillCode = sequence.Prefix + "/" + (sequence.SequenceCode + 1) + "/" + Common_Methods.GetCurrentFinancialYear(),
                        Concession = decimal.Parse(txt_Concession_Amount.Text),
                        IsSettlementDone = tempIsSettlementDone,
                        InAccountOf = txt_Account_Of.Text,
                        BillBy = int.Parse(Session["EmployeeId"].ToString())
                    };
                    if (Amount + decimal.Parse(txt_Concession_Amount.Text) > decimal.Parse(txt_Rupes.Text))
                    {
                        ShowMessage("Excess Amount", MessageType.Warning);
                        return;
                    }
                    bill = billService.Add(bill);
                    PaymentDetalis paymentDetalis = new PaymentDetalis()
                    {
                        BillId = bill.BillId,
                        ModeOfPayment = RadioButtonList1.SelectedValue.ToString(),
                        ModeOfPaymentNo = txt_Cheque_No.Text,
                        PaymentAmount = Amount,
                        PaymentDate = System.DateTime.Now,
                        PaymentBy = int.Parse(Session["EmployeeId"].ToString())
                    };
                    paymentDetalisService.Add(paymentDetalis);
                    
                    string purpose = "";
                    foreach (ListItem itemsProcedureReate in chk_ProcedureRate.Items)
                    {
                        if (itemsProcedureReate.Selected)
                        {
                            BillDetails billDetails = new BillDetails()
                            {
                                BillId = bill.BillId,
                                ProcedureRateId = int.Parse(itemsProcedureReate.Value), //New Registration
                                Rate = procedureRateService.GetById(int.Parse(itemsProcedureReate.Value)).Rate
                            };
                            purpose += itemsProcedureReate.Text + ", ";
                            BillDetailsService.Add(billDetails);
                        }
                    }
                    purpose = purpose.Substring(0, purpose.Length - 2);
                    bill.Purpose = purpose;
                    Sequence sequence = sequenceService.GetById(4);
                    bill.BillCode = sequence.Prefix + "/" + (sequence.SequenceCode + 1) + "/" + Common_Methods.GetCurrentFinancialYear();
                    sequence.SequenceCode = sequence.SequenceCode + 1;
                    sequenceService.Update(sequence);
                    bill = billService.Update(bill);
                    ShowMessage("Record Added!!!", MessageType.Success);
                    Session["Bill_Id"] = bill.BillId;
                    Session["Page"] = "Generate_Raw_Bill.aspx";
                    Response.AddHeader("REFRESH", "1;URL=Bill_Money_Recipt.aspx");
                }
            }
            catch (Exception ex)
            {
                ShowMessage("Something! Went Wrong!!!", MessageType.Error);
            }
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedValue.ToString() != "Cash")
                inputGroup.Visible = true;
            else
                inputGroup.Visible = false;
            if (chk_Concession.SelectedValue.ToString() == "1")
            {
                lbl_Pay_Amount.Text = string.Format("{0:0.00}", txt_Settlement.Text);
            }
            else
            {
                lbl_Pay_Amount.Text = string.Format("{0:0.00}", (decimal.Parse(txt_Rupes.Text) - decimal.Parse(txt_Concession_Amount.Text)));
            }

        }

        protected void chk_Concession_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chk_Concession.SelectedValue.ToString() == "1")
            {
                lbl_Concession_Amount.Visible = true;
                txt_Concession_Amount.Visible = true;
            }
            else
            {
                lbl_Concession_Amount.Visible = false;
                txt_Concession_Amount.Visible = false;
                txt_Concession_Amount.Text = "0.00";
            }
        }
        protected void Page_PreInit(Object sender, EventArgs e)
        {
            SecondSightWeb.Common_Controle.Common_Methods.ChangeMasterPage(Page);
        }

        protected void chk_Settlement_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chk_Settlement.SelectedValue.ToString() == "1")
            {
                lbl_Settlement.Visible = true;
                txt_Settlement.Visible = true;
                lbl_Pay_Amount.Text = string.Format("{0:0.00}", (decimal.Parse(txt_Rupes.Text) - decimal.Parse(txt_Concession_Amount.Text)).ToString());
            }
            else
            {
                lbl_Settlement.Visible = false;
                txt_Settlement.Text = "0.00";
                txt_Settlement.Visible = false;
            }
        }
    }
}
