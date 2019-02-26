using SecondSightSouthendEyeCentre;
using SecondSightSouthendEyeCentre.Models;
using SecondSightSouthendEyeCentre.Service.Implementation;
using SecondSightSouthendEyeCentre.Service.Interfaces;
using SecondSightWeb.Areas.Admin.Models.EditModel;
using SecondSightWeb.Areas.Admin.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecondSightWeb.Areas.Admin.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeService employeeService = new EmployeeService();
        IEmployeeLogService employeeLogService = new EmployeeLogService();
        IRoleService roleService = new RoleService();

        // GET: Admin/Employee
        public ActionResult Index()
        {
            List<EmployeeViewModel> employeeViewModel = (from emp in employeeService.GetAll()
                                                         join emplog in employeeLogService.GetAll() on emp.EmployeeId equals emplog.EmployeeId
                                                         join role in roleService.GetAll() on emplog.RoleId equals role.Id
                                                         where emplog.IsDeleted == false
                                                         select new EmployeeViewModel
                                                         {
                                                             EmployeeId = emp.EmployeeId,
                                                             EmployeeName = emp.FirstName + " " + emp.OtherName + " " + emp.LastName,
                                                             EducationalQualification = emp.Qualification,
                                                             MobileNumber = emp.Contact.ToString(),
                                                             Role = role.RoleName,
                                                         }).ToList();
            return View(employeeViewModel);
        }

        // GET: Admin/Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Employee/Create
        public ActionResult Create()
        {
            EmployeeEditModel employeeEditModel = new EmployeeEditModel();
            BindEmployeeViewModel(employeeEditModel);
            return View(employeeEditModel);
        }
        private void BindEmployeeViewModel(EmployeeEditModel employeeEditModel)
        {
            employeeEditModel.Roles = roleService.GetAll();
        }
        // POST: Admin/Employee/Create
        [HttpPost]
        public ActionResult Create(EmployeeEditModel employeeEditModel, HttpPostedFileBase file)
        {
            var allowedExtensions = new[] {
            ".Jpg", ".png", ".jpg", "jpeg"
        };
            EmployeeEditModel EmployeeEditModel = new EmployeeEditModel();
            SecondSightSouthendEyeCentre.Models.Employee employee = new SecondSightSouthendEyeCentre.Models.Employee();
            BindEmployeeViewModel(EmployeeEditModel);
            if (ModelState.IsValid)
            {
                try
                {
                    if (employeeService.IsRegisteredEmployee(employeeEditModel.Employee.Contact))
                    {
                        var fileName = string.Empty;
                        if (allowedExtensions.Contains(Path.GetExtension(file.FileName)))
                        {
                            fileName = Path.GetFileNameWithoutExtension(file.FileName) + System.DateTime.Now.ToString("_ddMMyyyyhhmmss") + (Path.GetExtension(file.FileName));
                            var path = Path.Combine(Server.MapPath("~/Images/Employee_Images"), fileName);
                            file.SaveAs(path);
                        }
                        employee = employeeEditModel.Employee;
                        employee.ImageName = fileName;
                        employee.DepartmentId = 0;
                        employee = employeeService.Add(employee);
                        EmployeeLog employeeLog = new EmployeeLog
                        {
                            IsDeleted = false,
                            IsLogIn = false,
                            LastLogIn = DateTime.Now,
                            Password = employeeEditModel.Employee.Contact.ToString(),
                            UserId = employeeEditModel.Employee.Email,
                            RoleId = employeeEditModel.EemployeeLog.RoleId,
                            UpdatedBy = int.Parse(Session["EmployeeId"].ToString()),
                            UpdatedOn = DateTime.Now,
                            EmployeeId = employee.EmployeeId                            
                        };
                        employeeLog = employeeLogService.Add(employeeLog);
                        INSERTDAL.Instance.InitSetEmployeePass(employeeLog);
                        ViewBag.message = "Successful Record Added!!!";
                        ViewBag.messagetype = "Success";
                    }
                    else
                    {
                        ViewBag.message = "Enter New Mobile No!!!";
                        ViewBag.messagetype = "Error";
                        BindEmployeeViewModel(employeeEditModel);
                        return View(employeeEditModel);
                    }
                    // TODO: Add insert logic here
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewBag.message = ex.Message;
                    ViewBag.messagetype = "Error";
                    return View(EmployeeEditModel);
                }
            }
            else
            {
                return View(EmployeeEditModel);
            }
        }

        // GET: Admin/Employee/Edit/5
        public ActionResult Edit(int id)
        {
            EmployeeEditModel employeeEditModel = new EmployeeEditModel();
            BindEmployeeViewModel(employeeEditModel);
            employeeEditModel.Employee = employeeService.GetById(id);
            employeeEditModel.EemployeeLog = employeeLogService.GetById(id);
            return View(employeeEditModel);
        }

        // POST: Admin/Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeEditModel employeeEditModel)
        {
            EmployeeEditModel employeeEditModelView = new EmployeeEditModel();
            BindEmployeeViewModel(employeeEditModelView);
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add update logic here
                    EmployeeLog employeeLog = employeeLogService.GetById(employeeEditModel.EemployeeLog.EmployeeId);
                    employeeLog.RoleId = employeeEditModel.EemployeeLog.RoleId;
                    employeeLog.UserId = employeeEditModel.Employee.Email;
                    employeeService.Update(employeeEditModel.Employee);
                    employeeLogService.Update(employeeLog);
                    return RedirectToAction("Index");
                }
                else

                    return View(employeeEditModelView);
            }
            catch
            {
                return View(employeeEditModelView);
            }
        }

        // GET: Admin/Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Employee/Delete/5
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
