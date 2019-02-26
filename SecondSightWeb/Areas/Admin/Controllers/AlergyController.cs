using SecondSightSouthendEyeCentre.Models;
using SecondSightSouthendEyeCentre.Service.Implementation;
using SecondSightSouthendEyeCentre.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecondSightWeb.Areas.Admin.Controllers
{
    public class AlergyController : Controller
    {
        IAlergyService alergyService = new AlergyService();
        // GET: Admin/Alergy
        public ActionResult Index()
        {
            return View(alergyService.GetAll());
        }

        // GET: Admin/Alergy/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(alergyService.GetById(id));
        }

        // GET: Admin/Alergy/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Alergy/Create
        [HttpPost]
        //[ValidateInput(false)]
        public ActionResult Create(Alergy alergy)
        {
            try
            {
                // TODO: Add insert logic here
                alergyService.Add(alergy);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Admin/Alergy/Edit/5
        public ActionResult Edit(int id)
        {
            return View(alergyService.GetById(id));
        }

        // POST: Admin/Alergy/Edit/5
        [HttpPost]
        public ActionResult Edit(Alergy alergy)
        {
            try
            {
                // TODO: Add update logic here
                alergyService.Update(alergy);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Alergy/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Alergy/Delete/5
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
