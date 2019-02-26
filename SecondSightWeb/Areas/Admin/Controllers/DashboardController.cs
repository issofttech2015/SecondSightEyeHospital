using SecondSightSouthendEyeCentre.Service.Implementation;
using SecondSightSouthendEyeCentre.Service.Interfaces;
using SecondSightWeb.Areas.Admin.Models.DTO;
using SecondSightWeb.Common_Controle;
using SecondSightWeb.Data.DbIntractions;
using SecondSightWeb.Service.Implementation;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace SecondSightWeb.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        IAppointmentService appointmentService = new AppointmentService();
        IOperarionDetailsService operarionDetailsService = new OperarionDetailsService();
        IPatientService patientService = new PatientService();
        IBillService billService = new BillService();
        IPaymentDetalisService paymentDetalisService = new PaymentDetalisService();
        IEmployeeService employeeService = new EmployeeService();
        IPurchaseOrderService purchaseOrderService = new PurchaseOrderService();



        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Dashboard()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetHeaderDetails()
        {
            DashboardTopBarDTO dashboardTopBarDTO = new DashboardTopBarDTO()
            {
                TodaysAppointmnet = appointmentService.GetAll().Where(x => x.IsConfirmed == true && x.Time.Date == DateTime.Now.Date).Count(),
                TodaysOperation = operarionDetailsService.GetAll().Where(x => x.IsOperated == false && x.OperationDate.Date == DateTime.Now.Date).Count(),
                PendingPurchaseOrder = purchaseOrderService.GetAll().Where(x => x.IsApproved == false).Count(),
                TotalEmployee = employeeService.GetAll().Count(),
                TotalRegisteredPatinet = patientService.GetAll().Count(),
                TodaysCollection = paymentDetalisService.GetAll().Where(x => x.PaymentDate.Value.Date == DateTime.Now.Date).Sum(x => x.PaymentAmount),
                TotalAppointment = appointmentService.GetAll().Where(x => x.IsConfirmed == true).Count(),
                TotalOperation = operarionDetailsService.GetAll().Count(),
                TotalCollection = paymentDetalisService.GetAll().Sum(x => x.PaymentAmount)

            };
            return Json(dashboardTopBarDTO, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetDashboardChartData()
        {
            ChartDataDTO chartDataDTO = new ChartDataDTO();
            SearchStoreProcedureDB<AppointmentDashBoardDTO> searchStoreProcedureDB = new SearchStoreProcedureDB<AppointmentDashBoardDTO>();
            SearchStoreProcedureDB<BillDashboardDTO> searchStoreProcedure = new SearchStoreProcedureDB<BillDashboardDTO>();
            SearchStoreProcedureDB<OperateSuccessRateDTO> searchStoreProcedureDBOperation = new SearchStoreProcedureDB<OperateSuccessRateDTO>();
            chartDataDTO.lstAppointments = searchStoreProcedureDB.GetAppointments30Days().ToList();
            chartDataDTO.lstBills = searchStoreProcedure.GetBills30Days().ToList();
            chartDataDTO.lstOperationSuccessRate = searchStoreProcedureDBOperation.GetOperationSuccessRate().ToList();
            return Json(chartDataDTO, JsonRequestBehavior.AllowGet);
        }
        public ActionResult RedirectMIS(int id)
        {
            EmployeeDetails employeeDetails = new EmployeeDetails()
            {
                EmployeeId = Common_Methods.Encrypt(Session["EmployeeId"].ToString()),
                RoleId = Common_Methods.Encrypt(Session["Employee_RoleId"].ToString())
            };
            var json = new JavaScriptSerializer().Serialize(employeeDetails);
            string url = "", key = "";
            switch (id)
            {
                case 1:
                    key = "get-appointment-details";
                    break;
                case 2:
                    key = "get-examination-details";
                    break;
                case 3:
                    key = "get-operation-successRate";
                    break;
                case 4:
                    key = "get-treatement-details";
                    break;
                case 5:
                    key = "get-operation-details";
                    break;
                case 6:
                    key = "get-collecti-on-details";
                    break;
            }
            url = "http://"+GetIPAddress()+"/SecondSightReport?key=" + HttpUtility.UrlEncode(key) + "&EmployeeObj=" + HttpUtility.UrlEncode(json);
            //url = ConfigurationManager.AppSettings["host"].ToString() + "?key=" + HttpUtility.UrlEncode(key) + "&EmployeeObj=" + HttpUtility.UrlEncode(json);
            //url = "http://localhost:4200?key=" + HttpUtility.UrlEncode(key) + "&EmployeeObj=" + HttpUtility.UrlEncode(json);
            return Redirect(@url);

        }
        public string GetIPAddress()
        {
            IPHostEntry Host = default(IPHostEntry);
            string Hostname = null;
            string IPAddress ="";
            Hostname = System.Environment.MachineName;
            Host = Dns.GetHostEntry(Hostname);
            foreach (IPAddress IP in Host.AddressList)
            {
                if (IP.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    IPAddress = Convert.ToString(IP);
                }
            }
            return IPAddress;
        }
    }
}