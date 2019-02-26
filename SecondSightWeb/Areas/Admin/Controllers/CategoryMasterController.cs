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
    public class CategoryMasterController : Controller
    {
        ICategoryMasterService categoryMasterService = new CategoryMasterService();
        // GET: Admin/CategoryMaster
        public ActionResult Index()
        {
            return View(categoryMasterService.GetAll());
        }

        // GET: Admin/CategoryMaster/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/CategoryMaster/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/CategoryMaster/Create
        [HttpPost]
        public ActionResult Create(CategoryMaster categoryMaster)
        {
            try
            {
                // TODO: Add insert logic here
                categoryMasterService.Add(categoryMaster);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/CategoryMaster/Edit/5
        public ActionResult Edit(int DiseaseId)
        {
            return View(categoryMasterService.GetById(DiseaseId));
        }

        // POST: Admin/CategoryMaster/Edit/5
        [HttpPost]
        public ActionResult Edit(CategoryMaster categoryMaster)
        {
            try
            {
                // TODO: Add update logic here
                categoryMasterService.Update(categoryMaster);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/CategoryMaster/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/CategoryMaster/Delete/5
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
