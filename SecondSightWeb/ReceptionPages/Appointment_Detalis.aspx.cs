using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecondSightWeb.ReceptionPages
{
    public partial class Appointment_Detalis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Search_Appointment_Click(object sender, EventArgs e)
        {
            if (txt_Date_Serach.Text != "")
            {
                grd_Appontment_Details.DataSource = null;
                grd_Appontment_Details.DataSourceID = "ds_AppointmentList_WF_Doctor_Time";
                grd_Appontment_Details.DataBind();
            }
            else
            {
                grd_Appontment_Details.DataSource = null;
                grd_Appontment_Details.DataSourceID = "ds_AppointmentList_WF_Doctor";
                grd_Appontment_Details.DataBind();
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "openpopup();", true);

        }

        protected void btn_Print_Excell_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "Appointment_Detalis" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            grd_Appontment_Details.GridLines = GridLines.Both;
            grd_Appontment_Details.HeaderStyle.Font.Bold = true;
            grd_Appontment_Details.RenderControl(htmltextwrtter);
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