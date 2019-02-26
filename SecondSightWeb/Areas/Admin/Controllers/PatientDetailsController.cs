using SecondSightSouthendEyeCentre.Models;
using SecondSightSouthendEyeCentre.Service.Implementation;
using SecondSightSouthendEyeCentre.Service.Interfaces;
using SecondSightWeb.Areas.Admin.Models.EditModel;
using SecondSightWeb.Areas.Admin.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecondSightWeb.Areas.Admin.Controllers
{
    public class PatientDetailsController : Controller
    {
        IPatientService patientService = new PatientService();
        // GET: Admin/PatientDetails
        public ActionResult Index()
        {
            List<PatientDetailsViewModel> patientDetailsViewModelList = (from p in patientService.GetAll()
                                                                         select new PatientDetailsViewModel
                                                                         {
                                                                             PatientId = p.PatientId,
                                                                             PatCode = p.PatCode,
                                                                             //Adhar = p.Adhar,
                                                                             Contact = p.Contact,
                                                                             Age = p.Age,
                                                                             DateofBirth = p.DateofBirth,
                                                                             Email = p.Email,
                                                                             //Gender = p.Gender,
                                                                             GuardianContact = p.GuardianContact,
                                                                             GuardianName = p.GuardianFirstName + " " + p.GuardianLastName,
                                                                             GuardianRelateAs = p.GuardianRelateAs,
                                                                             //Nationality = p.Nationality,
                                                                             //Ocupation = p.Ocupation,
                                                                             PatientName = p.FirstName + p.MiddleName + p.LastName,
                                                                             ResidanceAddress = p.ResidanceAddress
                                                                         }).ToList();
            return View(patientDetailsViewModelList);
        }

        // GET: Admin/PatientDetails/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/PatientDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/PatientDetails/Create
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

        // GET: Admin/PatientDetails/Edit/5
        public ActionResult Edit(int id)
        {
            Patient patient = patientService.GetById(id);
            PatientDetailsEditModel patientDetailsEditModel = new PatientDetailsEditModel()
            {
                Adhar = patient.Adhar,
                Age = patient.Age,
                DateofBirth = patient.DateofBirth,
                Email = patient.Email,
                Gender = patient.Gender,
                GuardianContact = patient.GuardianContact,
                FirstName = patient.FirstName,
                GuardianFirstName = patient.GuardianFirstName,
                GuardianLastName = patient.GuardianLastName,
                GuardianRelateAs = patient.GuardianRelateAs,
                LastName = patient.LastName,
                MiddleName = patient.MiddleName,
                Nationality = patient.Nationality,
                Ocupation = patient.Ocupation,
                PatientId = patient.PatientId,
                ResidanceAddress = patient.ResidanceAddress,
                PatCode = patient.PatCode
            };
            return View(patientDetailsEditModel);
        }

        // POST: Admin/PatientDetails/Edit/5
        [HttpPost]
        public ActionResult Edit(PatientDetailsEditModel patientDetailsEditModelParam)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add update logic here
                    //Patient patient = new Patient()
                    //{
                    //    PatientId = patientDetailsEditModelParam.PatientId,
                    //    FirstName = patientDetailsEditModelParam.FirstName,
                    //    MiddleName = patientDetailsEditModelParam.MiddleName,
                    //    LastName = patientDetailsEditModelParam.LastName,
                    //    Gender = patientDetailsEditModelParam.Gender,
                    //    DateofBirth = patientDetailsEditModelParam.DateofBirth,
                    //    Age = patientDetailsEditModelParam.Age,
                    //    ResidanceAddress = patientDetailsEditModelParam.ResidanceAddress,
                    //    Email = patientDetailsEditModelParam.Email,
                    //    GuardianFirstName = patientDetailsEditModelParam.GuardianFirstName,
                    //    GuardianLastName = patientDetailsEditModelParam.GuardianLastName,
                    //    GuardianContact = patientDetailsEditModelParam.GuardianContact,
                    //    GuardianRelateAs = patientDetailsEditModelParam.GuardianRelateAs,
                    //    Ocupation = patientDetailsEditModelParam.Ocupation,
                    //    Adhar = decimal.Parse(Convert.ToString(patientDetailsEditModelParam.Adhar))
                    //};


                    //if (patientDetailsEditModelParam.DateofBirth.ToString() != "" && patientDetailsEditModelParam.DateofBirth.ToString() != string.Empty)
                    //{
                    //    patient.DateofBirth = DateTime.ParseExact(patientDetailsEditModelParam.DateofBirth.ToString(), "MM/dd/yyyy hh:tt", System.Globalization.CultureInfo.InvariantCulture);
                    //}


                    Patient patient = patientService.GetById(patientDetailsEditModelParam.PatientId);

                    patient.FirstName = patientDetailsEditModelParam.FirstName;
                    patient.MiddleName = patientDetailsEditModelParam.MiddleName;
                    patient.LastName = patientDetailsEditModelParam.LastName;
                    patient.Gender = patientDetailsEditModelParam.Gender;
                    patient.DateofBirth = patientDetailsEditModelParam.DateofBirth;
                    patient.Age = patientDetailsEditModelParam.Age;
                    patient.ResidanceAddress = patientDetailsEditModelParam.ResidanceAddress;
                    patient.Email = patientDetailsEditModelParam.Email;
                    patient.GuardianFirstName = patientDetailsEditModelParam.GuardianFirstName;
                    patient.GuardianLastName = patientDetailsEditModelParam.GuardianLastName;
                    patient.GuardianContact = patientDetailsEditModelParam.GuardianContact;
                    patient.GuardianRelateAs = patientDetailsEditModelParam.GuardianRelateAs;
                    patient.Ocupation = patientDetailsEditModelParam.Ocupation;
                    patient.Adhar = decimal.Parse(Convert.ToString(patientDetailsEditModelParam.Adhar));


                    patientService.Update(patient);
                    ViewBag.message = "Successful Record Added!!!";
                    ViewBag.messagetype = "Success";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.message = "Is Invalid!!";
                    ViewBag.messagetype = "Warning";
                    return View(patientDetailsEditModelParam);
                }
            }
            catch (Exception ex)
            {
                ViewBag.message = ex.Message;
                ViewBag.messagetype = "Error";
                return View(patientDetailsEditModelParam);
            }
        }

        // GET: Admin/PatientDetails/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/PatientDetails/Delete/5
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
