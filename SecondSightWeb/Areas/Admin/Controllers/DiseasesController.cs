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
    public class DiseasesController : Controller
    {
        // GET: Admin/Diseases
        IDiseasesService diseasesService = new DiseasesService();
        public ActionResult Index()
        {
            return View(diseasesService.GetAll());
        }

        // GET: Admin/Diseases/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(diseasesService.GetById(id));
        }

        // GET: Admin/Diseases/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Diseases/Create
        [HttpPost]
        public ActionResult Create(Diseases diseases)
        {
            try
            {
                // TODO: Add insert logic here
                diseasesService.Add(diseases);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Diseases/Edit/5
        public ActionResult Edit(int id)
        {
            return View(diseasesService.GetById(id));
        }

        // POST: Admin/Diseases/Edit/5
        [HttpPost]
        public ActionResult Edit(Diseases diseases)
        {
            try
            {
                // TODO: Add update logic here
                diseasesService.Update(diseases);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Diseases/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Diseases/Delete/5
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
