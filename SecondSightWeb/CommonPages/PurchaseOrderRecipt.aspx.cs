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

namespace SecondSightWeb.CommonPages
{
    public partial class PurchaseOrderRecipt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["PO_Id"].ToString() != "")
                {
                    IPurchaseOrderService purchaseOrderService = new PurchaseOrderService();
                    ISupplierService supplierService = new SupplierService();
                    PurchaseOrder purchaseOrder = purchaseOrderService.GetById(int.Parse(Session["PO_Id"].ToString()));
                    lbl_Purchase_Order_No.Text = purchaseOrder.POID.ToString();
                    lbl_Date.Text = purchaseOrder.PODate.ToString("dd/MM/yyyy");
                    Supplier supplier = supplierService.GetById(int.Parse(purchaseOrder.SupplierId.ToString()));
                    lbl_VendorName.Text = supplier.SupplierName.ToString();
                    LoadSign();

                }
            }
        }
        Decimal total = 0;
        protected void gv_Purchase_Order_Details_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                // if row type is DataRow, add ProductSales value to TotalSales
                total += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Price"));
            else if (e.Row.RowType == DataControlRowType.Footer)
                // If row type is footer, show calculated total value
                // Since this example uses sales in dollars, I formatted output as currency
                e.Row.Cells[6].Text = string.Format("{0:0.00}", total);
        }
        private void LoadSign()
        {
            IEmployeeService employeeService = new EmployeeService();
            Employee employee = employeeService.GetById(int.Parse(Session["EmployeeId"].ToString()));
            lbl_Gnrtd_By.Text = employee.FirstName + " " + employee.OtherName + " " + employee.LastName;
            lbl_Time_Stamp.Text = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        }
        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Session["Page"].ToString());
        }
    }
}