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
    public partial class Generate_Bill : System.Web.UI.Page
    {
        IPatientService patientService = new PatientService();
        IBillService billService = new BillService();
        IPaymentDetalisService paymentDetalisService = new PaymentDetalisService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var Patients = (from pat in patientService.GetAll()
                                join bill in billService.GetAll() on pat.PatientId equals bill.PatientId
                                where bill.IsPaid == false
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

        protected void Page_PreInit(Object sender, EventArgs e)
        {
            Common_Methods.ChangeMasterPage(Page);
        }

        public enum MessageType { Success, Error, Info, Warning };
        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }

        protected void btn_Submit_Bill_Click(object sender, EventArgs e)
        {
            decimal Amount = 0;
            if (ddl_Purpose.SelectedIndex != 0)
            {
                //Bill bill = (Bill)cmbPurpose.SelectedItem;
                Bill updateBill = billService.GetById(int.Parse(ddl_Purpose.SelectedValue.ToString()));
                updateBill.ModeOfPayment = RadioButtonList1.SelectedValue.ToString();
                updateBill.ChequeNo = txt_Cheque_No.Text;
                updateBill.PaymentDateTime = System.DateTime.Now;
                updateBill.Concession = decimal.Parse(txt_Concession_Amount.Text);
                if (chk_Settlement.SelectedValue.ToString() == "1")
                {
                    Amount = decimal.Parse(txt_Settlement.Text);
                    updateBill.IsSettlementDone = true;
                    updateBill.IsPaid = false;
                }
                else
                {
                    Amount = decimal.Parse(txt_Rupes.Text) - decimal.Parse(txt_Concession_Amount.Text);
                    updateBill.IsSettlementDone = false;
                    updateBill.IsPaid = true;
                }
                updateBill.InAccountOf = txt_Account_Of.Text;
                if (Amount + decimal.Parse(txt_Concession_Amount.Text) > decimal.Parse(txt_Rupes.Text))
                {
                    ShowMessage("Excess Amount", MessageType.Warning);
                    return;
                }
                updateBill.BillBy = int.Parse(Session["EmployeeId"].ToString());
                updateBill = billService.Update(updateBill);
                PaymentDetalis paymentDetalis = new PaymentDetalis()
                {
                    BillId = updateBill.BillId,
                    ModeOfPayment = RadioButtonList1.SelectedValue.ToString(),
                    ModeOfPaymentNo = txt_Cheque_No.Text,
                    PaymentAmount = Amount,
                    PaymentDate = System.DateTime.Now,
                    PaymentBy = int.Parse(Session["EmployeeId"].ToString())
                };
                paymentDetalisService.Add(paymentDetalis);
                //if (updateBill.OperationId != 0)
                //{
                //    button4.Visible = false;
                //    button5.Visible = true;
                //}
                //else
                //{
                //    button4.Visible = true;
                //    button5.Visible = false;
                //}
                if (updateBill.IsPaid == true || updateBill.IsSettlementDone == true)//IsSettlementDone==true part part e taka ta dichhe
                {
                    ShowMessage("Record Updated", MessageType.Success);
                    Session["Bill_Id"] = updateBill.BillId;
					Session["Page"] = "Generate_Bill.aspx";
                    Response.AddHeader("REFRESH", "1;URL=Bill_Money_Recipt.aspx");
                }
                else
                {
                    ShowMessage("Something Went wrong!!!", MessageType.Error);
                }
            }
        }

        protected void ddl_Patient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_Patient.SelectedIndex != 0)
            {
                SecondSightSouthendEyeCentre.Models.Patient patient = new SecondSightSouthendEyeCentre.Models.Patient();
                patient = patientService.GetById(int.Parse(ddl_Patient.SelectedValue.ToString()));
                txt_Pat_Name.Text = patient.FirstName + " " + patient.MiddleName + " " + patient.LastName;
                var bills = billService.GetAll().Where(x => x.PatientId == patient.PatientId && x.IsPaid == false && x.IsSettlementDone == false && x.BillCode != null).ToList();
                ddl_Purpose.Items.Clear();
                ddl_Purpose.DataSource = bills;
                ddl_Purpose.DataValueField = "BillId";
                ddl_Purpose.DataTextField = "BillCode";
                ddl_Purpose.DataBind();
                ddl_Purpose.Items.Insert(0, new ListItem("--Select--", "0"));
                ddl_Purpose.SelectedIndex = 0;

            }
        }


        protected void ddl_Purpose_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_Purpose.SelectedIndex != 0)
            {
                Bill bill = billService.GetById(int.Parse(ddl_Purpose.SelectedValue.ToString()));
                txt_Rupes.Text = string.Format("{0:0.00}", bill.BillAmount);
                if (chk_Concession.SelectedValue.ToString() == "1")
                {
                    lbl_Pay_Amount.Text = string.Format("{0:0.00}", txt_Settlement.Text);
                }
                else
                {
                    lbl_Pay_Amount.Text = string.Format("{0:0.00}", txt_Rupes.Text);
                }
                txt_Rupes_Words.Text = Common_Methods.ConvertNumbertoWords((long)bill.BillAmount);
                if (bill.OperationId != 0)
                {
                    btn_Generate_Operation_Bill.Visible = true;
                    btn_Submit_Bill.Text = "Save & Generate Money Receipt";
                }
                else
                {
                    btn_Generate_Operation_Bill.Visible = false;
                    btn_Submit_Bill.Text = "Save";
                }


                //if (bill.OperationId != 0)
                //{
                //    button4.Visible = false;
                //    button5.Visible = true;
                //    OperationId = bill.OperationId;
                //    BillId = bill.BillId;
                //}
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
                txt_Concession_Amount.Text = "0.00";
                txt_Concession_Amount.Visible = false;
            }
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

        protected void btn_Generate_Operation_Bill_Click(object sender, EventArgs e)
        {
            Bill bill = billService.GetById(int.Parse(ddl_Purpose.SelectedValue.ToString()));
            Session["OperationId"] = bill.OperationId;
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('../CommonPages/Operation_Final_Bill.aspx');", true);
        }
    }
}