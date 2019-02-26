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
    public partial class Bill_Money_Recipt : System.Web.UI.Page
    {
        IEmployeeService employeeService = new EmployeeService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Bill_Id"].ToString() != "" && Session["Bill_Id"]!=null)
                {
                    IPatientService patientService = new PatientService();
                    IBillService billService = new BillService();
                    IPaymentDetalisService paymentDetalisService = new PaymentDetalisService();


                    Bill bill = billService.GetById(int.Parse(Session["Bill_Id"].ToString()));
                    SecondSightSouthendEyeCentre.Models.Patient patient = patientService.GetById(bill.PatientId);
                    lbl_Bill_No.Text = bill.BillCode;
                    lbl_Date.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                    lbl_Name.Text = patient.FirstName + " " + patient.MiddleName + " " + patient.LastName;
                    lbl_PatCode.Text = patient.PatCode;
                    //lbl_For.Text = bill.Purpose;
                    lbl_sum_of_rs.Text = Common_Methods.ConvertNumbertoWords((long)bill.BillAmount);
                    lbl_type.Text = bill.ModeOfPayment + " " + bill.ChequeNo;
                    //lbl_Account_of.Text = bill.InAccountOf;
                    lbl_Bill_Amount.Text = string.Format("{0:0.00}", bill.BillAmount);
                    if (bill.Concession != 0)
                    {
                        lbl_Concession_Amount_Title.Visible = true;
                        lbl_Concession_Amount.Visible = true;
                        lbl_Concession_Amount.Text = string.Format("{0:0.00}", bill.Concession);
                        lbl_Bill_Amount.Text = string.Format("{0:0.00}", (bill.BillAmount - bill.Concession));
                        lbl_sum_of_rs.Text = Common_Methods.ConvertNumbertoWords((long)(bill.BillAmount - bill.Concession));
                    }
                    PaymentDetalis paymentDetalis = new PaymentDetalis();
                    paymentDetalis = paymentDetalisService.GetAll().Where(x => x.BillId == bill.BillId).Last();
                    lbl_PaidAmount.Text = string.Format("{0:0.00}", paymentDetalis.PaymentAmount);
                    if (bill.IsSettlementDone)
                    {
                        lbl_DueAmount_Title.Visible = true;
                        lbl_DueAmount.Visible = true;
                        //lbl_DueAmount.Text = string.Format("{0:0.00}", (bill.BillAmount - (bill.Concession + paymentDetalis.PaymentAmount)));
                        lbl_DueAmount.Text = string.Format("{0:0.00}", (bill.BillAmount - (bill.Concession + paymentDetalisService.GetAll().Where(x => x.BillId == bill.BillId).Sum(pd=>pd.PaymentAmount))));
                    }
                    if (bill.IsRefunded)
                    {
                        IRefundBillService refundBillService = new RefundBillService();
                        RefundBill refundBill = (from rB in refundBillService.GetAll() where rB.BillId == bill.BillId
                                                 select new RefundBill
                                                 {
                                                     RefundAmount=rB.RefundAmount
                                                 }).FirstOrDefault();
                        lbl_RefundAmount_Title.Visible = true;
                        lbl_Refund_Amount.Visible = true;
                        lbl_Refund_Amount.Text = string.Format("{0:0.00}", refundBill.RefundAmount);
                    }
                    lbl_Total_Amount.Text = string.Format("{0:0.00}", bill.BillAmount);
                }
                LoadSign();
            }
            if (Session["Page"].ToString() == "popup_window")
                Page.ClientScript.RegisterOnSubmitStatement(typeof(Page), "closePage", "window.onunload = CloseWindow();");

        }
        Decimal total = 0;
        protected void gv_Procedure_Rate_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                // if row type is DataRow, add ProductSales value to TotalSales
                total += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Column1"));
            else if (e.Row.RowType == DataControlRowType.Footer)
                // If row type is footer, show calculated total value
                // Since this example uses sales in dollars, I formatted output as currency
                e.Row.Cells[2].Text = string.Format("{0:0.00}", total);
        }
        private void LoadSign()
        {
            if (Session["EmployeeId"] != null)
            {
                Employee employee = employeeService.GetById(int.Parse(Session["EmployeeId"].ToString()));
                lbl_Gnrtd_By.Text = employee.FirstName + " " + employee.OtherName + " " + employee.LastName;
            }
            else
                lbl_Gnrtd_By.Text = "Login Expired!!!";
            lbl_Time_Stamp.Text = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        }
        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (Session["Page"].ToString() != "popup_window")
                Response.Redirect(Session["Page"].ToString());
        }

    }
}
