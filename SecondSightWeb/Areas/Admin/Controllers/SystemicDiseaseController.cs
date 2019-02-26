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
    public class SystemicDiseaseController : Controller
    {
        ISystemicDiseaseService systemicDiseaseService = new SystemicDiseaseService();
        // GET: Admin/SystemicDisease
        public ActionResult Index()
        {
            return View(systemicDiseaseService.GetAll());
        }

        // GET: Admin/SystemicDisease/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/SystemicDisease/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/SystemicDisease/Create
        [HttpPost]
        public ActionResult Create(SystemicDisease systemicDisease)
        {
            try
            {
                // TODO: Add insert logic here
                systemicDiseaseService.Add(systemicDisease);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/SystemicDisease/Edit/5
        public ActionResult Edit(int DiseaseId)
        {
            return View(systemicDiseaseService.GetById(DiseaseId));
        }

        // POST: Admin/SystemicDisease/Edit/5
        [HttpPost]
        public ActionResult Edit(SystemicDisease systemicDisease)
        {
            try
            {
                // TODO: Add update logic here
                systemicDiseaseService.Update(systemicDisease);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/SystemicDisease/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/SystemicDisease/Delete/5
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
