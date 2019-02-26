using SecondSightSouthendEyeCentre.Models;
using SecondSightSouthendEyeCentre.Service.Implementation;
using SecondSightSouthendEyeCentre.Service.Interfaces;
using SecondSightWeb.Common_Controle;
using SecondSightWeb.Models;
using SecondSightWeb.Service.Implementation;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Net;

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
            if (result.Item2 > 0)
            {
                if (result.Item3.ToString().ToLower() == "true")
                {
                    ShowMessage("FirstTimeLogIn", MessageType.Info);
                    Response.Redirect("~/Admin/FirstTimeLogin/ChangePassword");
                }
                else
                {
                    EnterModuleByRole(result.Item1.ToString());
                }
            }
            else
            {
                ShowMessage("wrong username or password", MessageType.Error);
            }
            //EmployeeId = int.Parse(result.Item2.ToString());
        }

        private void EnterModuleByRole(string roleId)
        {
            switch (roleId)
            {
                case "1":
                    Response.Redirect("Admin/Dashboard/Dashboard");
                    break;
                case "2":
                    Response.Redirect("DoctorPages/Doctor_Home.aspx");
                    break;
                case "4":
                    Response.Redirect("Admin/CategoryMaster/Index");
                    break;
                case "5":
                    Response.Redirect("ReceptionPages/Reception_Home.aspx");
                    break;
                case "6":
                case "9":
                    Response.Redirect("ExaminerPages/Examiner_Home.aspx");
                    break;
                case "7":
                    break;
                case "8":
                    Response.Redirect("OtManager/OtConfirmation/Index");
                    break;
                    //case "wrongusernameorpassword":
                    //    ShowMessage("wrong username or password", MessageType.Error);
                    //    break;
            }
        }

        public Tuple<string, int, string> GetRoleValidateEmployee(string UserId, string Password)
        {
            SqlConnection conString = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SecondSightDbContext"].ConnectionString);
            SqlCommand cmdValidate = new SqlCommand("Select tblEmployeeLog.RoleId,tblEmployeeLog.EmployeeId,tblEmployee.FirstName,tblEmployee.FirstName +' '+isnull(tblEmployee.OtherName,'')+' '+isnull(tblEmployee.LastName,'') as [Full_Name],tblEmployee.Email,RoleName,tblEmployeeLog.IsFirstTimeLogIn from tblEmployeeLog inner join tblEmployee on tblEmployee.EmployeeId=tblEmployeeLog.EmployeeId inner join Role on Role.Id=tblEmployeeLog.RoleId where UserId=@userId and PWDCOMPARE (@pass ,Password) = 1", conString);
            cmdValidate.Parameters.AddWithValue("@userId", UserId);
            cmdValidate.Parameters.AddWithValue("@pass", Password);
            conString.Open();
            SqlDataReader dr = cmdValidate.ExecuteReader();
            while (dr.Read())
            {
                if (dr.HasRows == true)
                {
                    Session["EmployeeId"] = dr[1].ToString();
                    Session["Employee_Role"] = dr[5].ToString();
                    Session["Employee_RoleId"] = dr[0].ToString();
                    //Session["EmployeeFullName"] = dr[3].ToString();
                    //Session["EmployeeEmail"] = dr[4].ToString();
                    HttpCookie employeeName = new HttpCookie("Employee_Information");
                    employeeName.Values.Add("firstName", dr[2].ToString());
                    employeeName.Values.Add("fullName", dr[3].ToString());
                    employeeName.Values.Add("email", dr[4].ToString());
                    employeeName.Expires = DateTime.Now.Add(TimeSpan.FromHours(200));
                    Response.Cookies.Add(employeeName);

                    return new Tuple<string, int, string>(dr[0].ToString(), int.Parse(dr[1].ToString()), dr[6].ToString());
                }
            }
            if (dr.HasRows == false)
            {
                return new Tuple<string, int, string>("wrongusernameorpassword", 0, "");
            }
            return new Tuple<string, int, string>("", 0, "");
        }

        protected void btn_Sub_Click(object sender, EventArgs e)
        {
            IEmployeeLogService employeeLogService = new EmployeeLogService();
            IEmployeeService employeeService = new EmployeeService();
            GetIPModel getIPModel = new GetIPModel();
            if (Common_Methods.CheckForInternetConnection())
            {
                getIPModel = CRMSerializer.Instance.Deserialize<GetIPModel>(getIPModel, Common_Methods.GetJSONFromCS("http://gd.geobytes.com/GetCityDetails"));
            }
            else
            {
                ShowMessage("No Internet Connection!!!", MessageType.Warning);
                getIPModel.geobytesremoteip = "192.168.1.40";
            }
            ForgotPasswordDetails forgotPasswordDetails = (from eLService in employeeLogService.GetAll()
                                                           join eService in employeeService.GetAll() on eLService.EmployeeId equals eService.EmployeeId
                                                           where eLService.IsForgotPassword == false
                                                           && eLService.UserId == txt_UserName.Text
                                                           && eService.Contact == decimal.Parse(txt_Mobile.Text)
                                                           select new ForgotPasswordDetails
                                                           {
                                                               EmployeeId = eLService.EmployeeId,
                                                               RequestIP = getIPModel.geobytesremoteip,
                                                           }).FirstOrDefault();
            if (forgotPasswordDetails != null)
            {
                try
                {
                    IForgotPasswordDetailsService forgotPasswordDetailsService = new ForgotPasswordDetailsService();
                    forgotPasswordDetailsService.Add(forgotPasswordDetails);
                    EmployeeLog employeeLog = employeeLogService.GetById(forgotPasswordDetails.EmployeeId);
                    employeeLog.IsForgotPassword = true;
                    employeeLogService.Update(employeeLog);
                    ShowMessage("Password Requested Successfully", MessageType.Success);
                    Response.AddHeader("REFRESH", "1;URL=LogIn.aspx");
                }
                catch (Exception ex)
                {
                    ShowMessage("Something Went Wrong!!!", MessageType.Error);
                }
            }
            else
                ShowMessage("wrong username or Mobile No", MessageType.Error);
        }

        protected void lb_forgot_password_Click(object sender, EventArgs e)
        {
            txt_Password.Visible = false;
            txt_Mobile.Visible = true;
            btn_LogIn.Visible = false;
            btn_Sub.Visible = true;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            EmployeeDetails employeeDetails = new EmployeeDetails()
            {
                EmployeeId = Common_Methods.Encrypt(txt_UserName.Text),
                RoleId = Common_Methods.Encrypt(txt_Password.Text)
            };
            var json = new JavaScriptSerializer().Serialize(employeeDetails);
            ////string url = "http://localhost:4200?key="+ HttpUtility.UrlEncode("get-examination-details") +"&EmployeeObj=" + Common_Methods.Encrypt(txt_UserName.Text) + "&RoleId=" + Common_Methods.Encrypt(txt_Password.Text);

            //string url = "http://localhost:4200?key=" + HttpUtility.UrlEncode("get-appointment-details") + "&EmployeeObj=" + HttpUtility.UrlEncode(json);
            string url = "http://" + GetIPAddress() + ":4200?key=" + HttpUtility.UrlEncode("get-collecti-on-details") + "&EmployeeObj=" + HttpUtility.UrlEncode(json);
            //string url = "http://localhost:4200?key="+ HttpUtility.UrlEncode("get-examination-details") +"&EmployeeObj=" + HttpUtility.UrlEncode(json);
            //string url = "http://localhost:4200?key="+ HttpUtility.UrlEncode("get-operation-details") +"&EmployeeObj=" + HttpUtility.UrlEncode(json);
            //string url = "http://localhost:4200?key="+ HttpUtility.UrlEncode("get-operation-successRate") +"&EmployeeObj=" + HttpUtility.UrlEncode(json);
            //string url = "http://localhost:4200?key=" + HttpUtility.UrlEncode("get-treatement-details") + "&EmployeeObj=" + HttpUtility.UrlEncode(json);
            string s = "window.open('" + url + "', 'popup_window', 'width=1050,height=550,left=100,top=80,resizable=yes');";
            ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
        }

        public string GetIPAddress()
        {
            IPHostEntry Host = default(IPHostEntry);
            string Hostname = null;
            string ipaddress = "";
            Hostname = System.Environment.MachineName;
            Host = Dns.GetHostEntry(Hostname);
            foreach (IPAddress IP in Host.AddressList)
            {
                if (IP.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    ipaddress = Convert.ToString(IP);
                }
            }
            return ipaddress;
        }
    }
    public class EmployeeDetails
    {
        public string EmployeeId { get; set; }
        public string RoleId { get; set; }
    }
}