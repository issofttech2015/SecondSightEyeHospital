using SecondSightSouthendEyeCentre;
using SecondSightSouthendEyeCentre.Models;
using SecondSightSouthendEyeCentre.Service.Implementation;
using SecondSightSouthendEyeCentre.Service.Interfaces;
using SecondSightWeb.Areas.Admin.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecondSightWeb.Areas.Admin.Controllers
{
    public class FirstTimeLoginController : Controller
    {
        IEmployeeService employeeService = new EmployeeService();

        public ActionResult ChangePassword()
        {
            SecondSightSouthendEyeCentre.Models.Employee employee = employeeService.GetById(Convert.ToInt32(Session["EmployeeId"].ToString()));
            FirstTimeLoginViewModel firstTimeLoginViewModel = new FirstTimeLoginViewModel
            {
                EmployeeId = employee.EmployeeId,
                Name = employee.FirstName + employee.OtherName + employee.LastName,
                Contact = employee.Contact
            };
            ViewBag.isNotBlank = false;
            return View(firstTimeLoginViewModel);
        }


        [HttpPost]
        public ActionResult ChangePassword(FirstTimeLoginViewModel firstTimeLoginViewModelParam)
        {
            IEmployeeLogService employeeLogService = new EmployeeLogService();
            EmployeeLog employeeLog = employeeLogService.GetById(firstTimeLoginViewModelParam.EmployeeId);
            try
            {
                employeeLog.Password = firstTimeLoginViewModelParam.Password;
                employeeLog.IsFirstTimeLogIn = false;
                employeeLogService.Update(employeeLog);
                INSERTDAL.Instance.InitSetEmployeePass(employeeLog);
                ViewBag.message = "Successful Record Added!!!";
                ViewBag.messagetype = "Success";
            }
            catch
            {
                ViewBag.message = "Something Went Wrong!!!";
                ViewBag.messagetype = "Error";
            }
            return RedirectToAction("../../LogIn.aspx");
        }
    }
}