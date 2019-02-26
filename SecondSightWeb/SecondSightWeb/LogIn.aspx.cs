using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecondSightWeb
{
    public partial class LogIn : System.Web.UI.Page
    {
        public enum MessageType { Success, Error, Info, Warning };

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }
        protected void btn_LogIn_Click(object sender, EventArgs e)
        {
            var result = GetRoleValidateEmployee(txt_UserName.Text, txt_Password.Text);
            //EmployeeId = int.Parse(result.Item2.ToString());
            switch (result.Item1.ToString())
            {
                case "1":

                    break;
                case "2":

                    break;
                case "4":

                    break;
                case "5":
                    Response.Redirect("ReceptionPages/Reception_Home.aspx");
                    break;
                case "6":

                    break;
                case "7":
                    break;
                case "8":

                    break;
                case "wrong username or password":
                    ShowMessage("wrong username or password", MessageType.Error);
                    break;
            }
        }
        public Tuple<string, int> GetRoleValidateEmployee(string UserId, string Password)
        {
            SqlConnection conString = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SecondSightDbContext"].ConnectionString);
            SqlCommand cmdValidate = new SqlCommand("Select tblEmployeeLog.RoleId,tblEmployeeLog.EmployeeId,tblEmployee.FirstName,tblEmployee.FirstName +' '+tblEmployee.OtherName+' '+tblEmployee.LastName as [Full_Name],tblEmployee.Email from tblEmployeeLog inner join tblEmployee on tblEmployee.EmployeeId=tblEmployeeLog.EmployeeId where UserId=@userId and Password=@pass", conString);
            cmdValidate.Parameters.AddWithValue("@userId", UserId);
            cmdValidate.Parameters.AddWithValue("@pass", Password);
            conString.Open();
            SqlDataReader dr = cmdValidate.ExecuteReader();
            while (dr.Read())
            {
                if (dr.HasRows == true)
                {
                    Session["EmployeeName"] = dr[2].ToString();
                    Session["EmployeeFullName"] = dr[3].ToString();
                    Session["EmployeeEmail"] = dr[4].ToString();
                    HttpCookie employeeName = new HttpCookie("Employee_Information");
                    employeeName.Values.Add("firstName", dr[2].ToString());
                    employeeName.Values.Add("fullName", dr[3].ToString());
                    employeeName.Values.Add("email", dr[4].ToString());
                    employeeName.Expires = DateTime.Now.Add(TimeSpan.FromHours(200));
                    Response.Cookies.Add(employeeName);


                    return new Tuple<string, int>(dr[0].ToString(), int.Parse(dr[1].ToString()));
                }
            }
            if (dr.HasRows == false)
                return new Tuple<string, int>("wrong username or password", 0);
            return new Tuple<string, int>("", 0);
        }
    }
}