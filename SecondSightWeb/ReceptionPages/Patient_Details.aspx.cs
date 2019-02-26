using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecondSightWeb.ReceptionPages
{
    public partial class Patient_Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn_Print_Excell_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "Patient_Detalis" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            gv_Patient_List.GridLines = GridLines.Both;
            gv_Patient_List.HeaderStyle.Font.Bold = true;
            gv_Patient_List.RenderControl(htmltextwrtter);
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