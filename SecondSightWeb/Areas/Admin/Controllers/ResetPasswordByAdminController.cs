using SecondSightSouthendEyeCentre;
using SecondSightSouthendEyeCentre.Models;
using SecondSightSouthendEyeCentre.Service.Implementation;
using SecondSightSouthendEyeCentre.Service.Interfaces;
using SecondSightWeb.Areas.Admin.Models.ViewModels;
using SecondSightWeb.Common_Controle;
using SecondSightWeb.Models;
using SecondSightWeb.Service.Implementation;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecondSightWeb.Areas.Admin.Controllers
{
    public class ResetPasswordByAdminController : Controller
    {
        IEmployeeLogService employeeLogService = new EmployeeLogService();
        IEmployeeService employeeService = new EmployeeService();
        IForgotPasswordDetailsService forgotPasswordDetailsService = new ForgotPasswordDetailsService();
        // GET: Admin/ResetPassword
        public ActionResult Index()
        {
            List<ResetPasswordViewModel> resetPasswordViewModel = (from eLService in employeeLogService.GetAll()
                                                                   join eService in employeeService.GetAll() on eLService.EmployeeId equals eService.EmployeeId
                                                                   join fPDService in forgotPasswordDetailsService.GetAll() on eService.EmployeeId
                                                                   equals fPDService.EmployeeId
                                                                   where eLService.IsForgotPassword == true && fPDService.IsResolved == false
                                                                   select new ResetPasswordViewModel
                                                                   {
                                                                       EmployeeId = eLService.EmployeeId,
                                                                       UserId = eLService.UserId,
                                                                       Contact = eService.Contact,
                                                                       Email = eService.Email,
                                                                       Name = eService.FirstName + eService.OtherName + eService.LastName,
                                                                       Password = "",
                                                                       RequestIP = fPDService.RequestIP,
                                                                       RequestTime = DateTime.Parse(fPDService.RequestTime.ToString()),
                                                                       ForgotPasswordId = fPDService.ForgotPasswordId,
                                                                   }).ToList();
            return View(resetPasswordViewModel);
        }

        // GET: Admin/ResetPassword/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/ResetPassword/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ResetPassword/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/ResetPassword/Edit/5
        public ActionResult Edit(int id)
        {
            ResetPasswordViewModel resetPasswordViewModel = (from eLService in employeeLogService.GetAll()
                                                             join eService in employeeService.GetAll() on eLService.EmployeeId equals eService.EmployeeId
                                                             join fPDService in forgotPasswordDetailsService.GetAll() on eService.EmployeeId
                                                             equals fPDService.EmployeeId
                                                             where eLService.IsForgotPassword == true && fPDService.IsResolved == false && eService.EmployeeId == id
                                                             select new ResetPasswordViewModel
                                                             {
                                                                 EmployeeId = eLService.EmployeeId,
                                                                 UserId = eLService.UserId,
                                                                 Contact = eService.Contact,
                                                                 Email = eService.Email,
                                                                 Name = eService.FirstName + eService.OtherName + eService.LastName,
                                                                 Password = "",
                                                                 RequestIP = fPDService.RequestIP,
                                                                 RequestTime = DateTime.Parse(fPDService.RequestTime.ToString()),
                                                                 ForgotPasswordId = fPDService.ForgotPasswordId,
                                                             }).FirstOrDefault();
            return View(resetPasswordViewModel);
        }

        // POST: Admin/ResetPassword/Edit/5
        [HttpPost]
        public ActionResult Edit(ResetPasswordViewModel resetPasswordViewModelParm)
        {
            try
            {
                // TODO: Add update logic here

                EmployeeLog employeeLog = employeeLogService.GetById(resetPasswordViewModelParm.EmployeeId);
                employeeLog.IsForgotPassword = false;
                employeeLog.IsFirstTimeLogIn = true;
                employeeLog.Password = resetPasswordViewModelParm.Password;
                employeeLogService.Update(employeeLog);
                INSERTDAL.Instance.InitSetEmployeePass(employeeLog);
                ForgotPasswordDetails forgotPasswordDetails = forgotPasswordDetailsService.GetById(resetPasswordViewModelParm.ForgotPasswordId);
                forgotPasswordDetails.IsResolved = true;
                forgotPasswordDetails.ResolvedTime = System.DateTime.Now;
                GetIPModel getIPModel = new GetIPModel();
                if (Common_Methods.CheckForInternetConnection())
                {
                    getIPModel = CRMSerializer.Instance.Deserialize<GetIPModel>(getIPModel, Common_Methods.GetJSONFromCS("http://gd.geobytes.com/GetCityDetails"));
                }
                else
                {
                    ViewBag.message = "No Internet Connection!!!";
                    ViewBag.messagetype = "Warning";
                    getIPModel.geobytesremoteip = "192.168.1.40";
                }
                forgotPasswordDetails.ResolveIP = getIPModel.geobytesremoteip;
                forgotPasswordDetails.ResolvedBy = int.Parse(Session["EmployeeId"].ToString());
                forgotPasswordDetailsService.Update(forgotPasswordDetails);
                ViewBag.message = "Successful Record Added!!!";
                ViewBag.messagetype = "Success";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/ResetPassword/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/ResetPassword/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}