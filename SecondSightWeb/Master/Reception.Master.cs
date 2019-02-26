using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Configuration;
using SecondSightWeb.Common_Controle;
using System.Web.Script.Serialization;

namespace SecondSightWeb.Master
{
    public partial class Reception : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btn_Search_Appointment_Click(object sender, EventArgs e)
        {
            //if (txt_Mobile_Serach.Text != "" || txt_PatCode.Text != "")
            //{
            //    //grd_Appontment_Details.DataSource = null;
            //    //grd_Appontment_Details.DataSourceID = "ds_AppointmentList_WF_Doctor";
            //    //grd_Appontment_Details.DataBind();
            //    //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SecondSightDbContext"].ConnectionString);
            //    //SqlCommand cmd = new SqlCommand("SELECT tblEmployee.FirstName + ' ' + tblEmployee.OtherName + '  ' + tblEmployee.LastName AS [Doctors Name], tblPatient.FirstName + '  ' + tblPatient.MiddleName + '  ' + tblPatient.LastName AS [Patient Name], Appointment.Time FROM Appointment INNER JOIN tblEmployee ON Appointment.DoctorsId = tblEmployee.EmployeeId INNER JOIN tblPatient ON tblPatient.PatCode = Appointment.PatCode WHERE (Appointment.IsAttented = 0) AND (Appointment.PatCode = @PatCode) OR (tblPatient.Contact = @Contact)", con);
            //    //cmd.Parameters.AddWithValue("@PatCode", txt_PatCode.Text);
            //    //cmd.Parameters.AddWithValue("@Contact", txt_Mobile_Serach.Text);
            //    //con.Open();
            //    //SqlDataReader dr = cmd.ExecuteReader();
            //    //if (dr.HasRows == true)
            //    //{
            //    //    while (dr.Read())
            //    //    {
            //    //        ShowMessage("The Patient Has Appoint at "+dr[2].ToString()+" and Name of the Doctor is "+ dr[0].ToString(), MessageType.Success);
            //    //    }
            //    //}
            //    //if (dr.HasRows == false)
            //    //{
            //    //    ShowMessage("No Data found!!!", MessageType.Error);
            //    //}
            //}
            //else
            //{

            //}
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "openpopup();", true);
        }
        public enum MessageType { Success, Error, Info, Warning };

        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }

        protected void lnk_Collection_details_Click(object sender, EventArgs e)
        {
            EmployeeDetails employeeDetails = new EmployeeDetails()
            {
                EmployeeId = Common_Methods.Encrypt(Session["EmployeeId"].ToString()),
                RoleId = Common_Methods.Encrypt(Session["Employee_RoleId"].ToString())
            };
            var json = new JavaScriptSerializer().Serialize(employeeDetails);
            //string url = "http://localhost:4200?key=" + HttpUtility.UrlEncode("get-collecti-on-details") + "&EmployeeObj=" + HttpUtility.UrlEncode(json);
            string url = "http://192.168.1.40/SecondSightReport?key=" + HttpUtility.UrlEncode("get-collecti-on-details") + "&EmployeeObj=" + HttpUtility.UrlEncode(json);
            Response.Redirect(url);
        }
    }
}