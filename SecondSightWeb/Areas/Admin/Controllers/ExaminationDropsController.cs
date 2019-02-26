using SecondSightSouthendEyeCentre.Models;
using SecondSightWeb.Service.Implementation;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecondSightWeb.Areas.Admin.Controllers
{
    public class ExaminationDropsController : Controller
    {
        IExaminationDropsService examinationDropsService = new ExaminationDropsService();
        // GET: Admin/ExaminationDrops
        public ActionResult Index()
        {
            return View(examinationDropsService.GetAll());
        }

        // GET: Admin/ExaminationDrops/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/ExaminationDrops/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ExaminationDrops/Create
        [HttpPost]
        public ActionResult Create(ExaminationDrops examinationDrops)
        {
            try
            {
                // TODO: Add insert logic here
                examinationDropsService.Add(examinationDrops);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/ExaminationDrops/Edit/5
        public ActionResult Edit(int id)
        {
            return View(examinationDropsService.GetById(id));
        }

        // POST: Admin/ExaminationDrops/Edit/5
        [HttpPost]
        public ActionResult Edit(ExaminationDrops examinationDrops)
        {
            try
            {
                // TODO: Add update logic here
                examinationDropsService.Update(examinationDrops);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/ExaminationDrops/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/ExaminationDrops/Delete/5
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
