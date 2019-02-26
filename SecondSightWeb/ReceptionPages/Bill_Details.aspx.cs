using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecondSightWeb.ReceptionPages
{
    public partial class Bill_Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gv_BillDeatils_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Select":
                    string url = "Bill_Money_Recipt.aspx";
                    Session["Bill_Id"] = e.CommandArgument;
                    Session["Page"] = "popup_window";
                    string s = "window.open('" + url + "', 'popup_window', 'width=1050,height=550,left=100,top=80,resizable=yes');";
                    ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
                    break;
                case "Cancel":
                    Session["Bill_Id"] = e.CommandArgument;
                    Response.AddHeader("REFRESH", "1;URL=Bill_Money_Recipt.aspx");
                    break;
            }
        }

        protected void gv_BillDeatils_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "IsPaid")))
                    e.Row.Cells[9].Enabled = true;
                else
                    e.Row.Cells[9].Enabled = false;

            }
        }
        protected void btn_Print_Excell_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "Bill_Detalis" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            gv_BillDeatils.GridLines = GridLines.Both;
            gv_BillDeatils.HeaderStyle.Font.Bold = true;
            gv_BillDeatils.RenderControl(htmltextwrtter);
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