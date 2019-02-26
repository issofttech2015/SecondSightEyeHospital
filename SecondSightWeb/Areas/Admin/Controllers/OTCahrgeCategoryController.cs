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
    public class OTCahrgeCategoryController : Controller
    {
        IOTChargeCategoryService oTCahrgeCategoryService = new OTChargeCategoryService();
        // GET: Admin/OTCahrgeCategory
        public ActionResult Index()
        {
            return View(oTCahrgeCategoryService.GetAll());
        }

        // GET: Admin/OTCahrgeCategory/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/OTCahrgeCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/OTCahrgeCategory/Create
        [HttpPost]
        public ActionResult Create(OTChargeCategory oTCahrgeCategory)
        {
            try
            {
                // TODO: Add insert logic here
                oTCahrgeCategoryService.Add(oTCahrgeCategory);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/OTCahrgeCategory/Edit/5
        public ActionResult Edit(int id)
        {
            return View(oTCahrgeCategoryService.GetById(id));
        }

        // POST: Admin/OTCahrgeCategory/Edit/5
        [HttpPost]
        public ActionResult Edit(OTChargeCategory oTCahrgeCategory)
        {
            try
            {
                // TODO: Add update logic here
                oTCahrgeCategoryService.Update(oTCahrgeCategory);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/OTCahrgeCategory/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/OTCahrgeCategory/Delete/5
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
