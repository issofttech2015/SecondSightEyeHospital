using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using context = System.Web.HttpContext;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;

namespace SecondSightWeb.Common_Controle
{
    public class Common_Methods
    {
        public static string Encrypt(string inputText)
        {
            string encryptionkey = "SAUW193BX628TD57";
            byte[] keybytes = Encoding.ASCII.GetBytes(encryptionkey.Length.ToString());
            RijndaelManaged rijndaelCipher = new RijndaelManaged();
            byte[] plainText = Encoding.Unicode.GetBytes(inputText);
            PasswordDeriveBytes pwdbytes = new PasswordDeriveBytes(encryptionkey, keybytes);
            using (ICryptoTransform encryptrans = rijndaelCipher.CreateEncryptor(pwdbytes.GetBytes(32), pwdbytes.GetBytes(16)))
            {
                using (MemoryStream mstrm = new MemoryStream())
                {
                    using (CryptoStream cryptstm = new CryptoStream(mstrm, encryptrans, CryptoStreamMode.Write))
                    {
                        cryptstm.Write(plainText, 0, plainText.Length);
                        cryptstm.Close();
                        return Convert.ToBase64String(mstrm.ToArray());
                    }
                }
            }
        }
        public static string Decrypt(string encryptText)
        {
            string encryptionkey = "SAUW193BX628TD57";
            byte[] keybytes = Encoding.ASCII.GetBytes(encryptionkey.Length.ToString());
            RijndaelManaged rijndaelCipher = new RijndaelManaged();
            byte[] encryptedData = Convert.FromBase64String(encryptText.Replace(" ", "+"));
            PasswordDeriveBytes pwdbytes = new PasswordDeriveBytes(encryptionkey, keybytes);
            using (ICryptoTransform decryptrans = rijndaelCipher.CreateDecryptor(pwdbytes.GetBytes(32), pwdbytes.GetBytes(16)))
            {
                using (MemoryStream mstrm = new MemoryStream(encryptedData))
                {
                    using (CryptoStream cryptstm = new CryptoStream(mstrm, decryptrans, CryptoStreamMode.Read))
                    {
                        byte[] plainText = new byte[encryptedData.Length];
                        int decryptedCount = cryptstm.Read(plainText, 0, plainText.Length);
                        return Encoding.Unicode.GetString(plainText, 0, decryptedCount);
                    }
                }
            }


        }
        public static string ConvertNumbertoWords(long number)
        {
            if (number == 0) return "ZERO";
            if (number < 0) return "minus " + ConvertNumbertoWords(Math.Abs(number));
            string words = "";
            if ((number / 1000000) > 0)
            {
                words += ConvertNumbertoWords(number / 100000) + " LAKHS ";
                number %= 1000000;
            }
            if ((number / 1000) > 0)
            {
                words += ConvertNumbertoWords(number / 1000) + " THOUSAND ";
                number %= 1000;
            }
            if ((number / 100) > 0)
            {
                words += ConvertNumbertoWords(number / 100) + " HUNDRED ";
                number %= 100;
            }
            //if ((number / 10) > 0)  
            //{  
            // words += ConvertNumbertoWords(number / 10) + " RUPEES ";  
            // number %= 10;  
            //}  
            if (number > 0)
            {
                if (words != "") words += "AND ";
                var unitsMap = new[]
                {
            "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN"
        };
                var tensMap = new[]
                {
            "ZERO", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY"
        };
                if (number < 20) words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0) words += " " + unitsMap[number % 10];
                }
            }
            return words;
        }
        public static string GetCurrentFinancialYear()
        {
            int CurrentYear = DateTime.Today.Year;
            int PreviousYear = DateTime.Today.Year - 1;
            int NextYear = DateTime.Today.Year + 1;
            string PreYear = PreviousYear.ToString();
            string NexYear = NextYear.ToString();
            string CurYear = CurrentYear.ToString();
            string FinYear = null;

            if (DateTime.Today.Month > 3)
                FinYear = CurYear.Substring(2, 2) + "-" + NexYear.Substring(2, 2);
            else
                FinYear = PreYear.Substring(2, 2) + "-" + CurYear.Substring(2, 2);
            return FinYear.Trim();
        }
        private static String ErrorlineNo, Errormsg, extype, exurl, hostIp, ErrorLocation;
        public static void SendErrorToText(Exception ex)
        {

            var line = Environment.NewLine + Environment.NewLine;
            if (ex.InnerException != null)
            {
                ErrorlineNo = Convert.ToString(ex.InnerException);
                Errormsg = Convert.ToString(ex.InnerException.Message);
            }
            else
            {
                ErrorlineNo = "NIL";
                Errormsg = "NIL";

            }
            if (ex.GetType() != null)
            {
                extype = Convert.ToString(ex.GetType());
                ErrorLocation = Convert.ToString(ex.Message);
            }
            else
            {
                ErrorLocation = "NIL";
                extype = "NIL";
            }
            exurl = Convert.ToString(context.Current.Request.Url);


            SecondSightSouthendEyeCentre.INSERTDAL.Instance.SendExcepToDB(Errormsg, extype, exurl, ErrorlineNo);
            try
            {
                string filepath = context.Current.Server.MapPath("~/ExceptionDetailsFile/");  //Text File Path

                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);

                }
                filepath = filepath + DateTime.Today.ToString("dd-MM-yy") + ".txt";   //Text File Name
                if (!File.Exists(filepath))
                {


                    File.Create(filepath).Dispose();

                }
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    string error = "Log Written Date:" + " " + DateTime.Now.ToString() + line + "Error Line No :" + " " + ErrorlineNo + line + "Error Message:" + " " + Errormsg + line + "Exception Type:" + " " + extype + line + "Error Location :" + " " + ErrorLocation + line + " Error Page Url:" + " " + exurl + line + "User Host IP:" + " " + hostIp + line;
                    sw.WriteLine("=======================Exception Details on " + " " + DateTime.Now.ToString() + "=======================");
                    sw.WriteLine("==========================================================================================");
                    sw.WriteLine(line);
                    sw.WriteLine(error);
                    sw.WriteLine("====================================*End*==========================================");
                    sw.WriteLine(line);
                    sw.Flush();
                    sw.Close();

                }

            }
            catch (Exception e)
            {
                e.ToString();

            }
        }
        public static void ClearTextBoxes(Control p1)
        {
            foreach (Control ctrl in p1.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox t = ctrl as TextBox;

                    if (t != null)
                    {
                        t.Text = String.Empty;
                    }
                }
                else
                {
                    if (ctrl.Controls.Count > 0)
                    {
                        ClearTextBoxes(ctrl);
                    }
                }
            }
        }
        public static void ClearListBox(Control control)
        {
            foreach (Control ctrl in control.Controls)
            {
                if (ctrl is ListBox)
                {
                    ListBox listBox = ctrl as ListBox;
                    foreach (ListItem items in listBox.Items)
                    {
                        if (items.Selected)
                        {
                            items.Selected = false;
                        }
                    }

                }
                else
                {
                    if (ctrl.Controls.Count > 0)
                    {
                        ClearListBox(ctrl);
                    }
                }
            }
        }

        public string GetRequest(string url)
        {
            try
            {
                ASCIIEncoding encoder = new ASCIIEncoding();
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "GET";
                request.Accept = "application/json";
                request.ContentType = "application/json";
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    return result.ToString();
                }
            }
            catch (Exception ex)
            {
                var result = ex.Message;
                return result;
            }
        }

        public static void ChangeMasterPage(Page page)
        {
            if (HttpContext.Current.Session["Employee_Role"] != null)
            {
                //if (HttpContext.Current.Session["Employee_RoleId"].ToString() == "1")
                switch (HttpContext.Current.Session["Employee_RoleId"].ToString())
                {
                    case "1":
                        page.MasterPageFile = "~/Master/Admin.master";
                        break;
                    case "8":
                        page.MasterPageFile = "~/Master/OpdManager.master";
                        break;
                }
            }
            else
                HttpContext.Current.Response.Redirect("~/LogIn.aspx");

        }

        public static string GetJSONFromCS(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.UTF8);
                    return reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.GetEncoding("utf-8"));
                    String errorText = reader.ReadToEnd();
                    // log errorText
                }
                throw;
            }
        }

        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("https://www.google.co.in"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

    }
}