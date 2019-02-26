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
    public class ProcedureRateController : Controller
    {
        IProcedureRateService procedureRateService = new ProcedureRateService();
        // GET: Admin/ProcedureRate
        public ActionResult Index()
        {
            return View(procedureRateService.GetAll());
        }

        // GET: Admin/ProcedureRate/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/ProcedureRate/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ProcedureRate/Create
        [HttpPost]
        public ActionResult Create(ProcedureRate procedureRate)
        {
            try
            {
                // TODO: Add insert logic here
                procedureRateService.Add(procedureRate);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/ProcedureRate/Edit/5
        public ActionResult Edit(int id)
        {
            return View(procedureRateService.GetById(id));
        }

        // POST: Admin/ProcedureRate/Edit/5
        [HttpPost]
        public ActionResult Edit(ProcedureRate procedureRate)
        {
            try
            {
                // TODO: Add update logic here
                procedureRateService.Update(procedureRate);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/ProcedureRate/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/ProcedureRate/Delete/5
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
