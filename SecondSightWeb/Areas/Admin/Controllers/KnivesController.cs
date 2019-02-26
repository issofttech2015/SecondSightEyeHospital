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
    public class KnivesController : Controller
    {
        IKnivesService knivesService = new KnivesService();
        // GET: Admin/Knives
        public ActionResult Index()
        {
            return View(knivesService.GetAll());
        }

        // GET: Admin/Knives/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Knives/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Knives/Create
        [HttpPost]
        public ActionResult Create(Knives knives)
        {
            try
            {
                // TODO: Add insert logic here
                knivesService.Add(knives);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Knives/Edit/5
        public ActionResult Edit(int id)
        {
            return View(knivesService.GetById(id));
        }

        // POST: Admin/Knives/Edit/5
        [HttpPost]
        public ActionResult Edit(Knives knives)
        {
            try
            {
                // TODO: Add update logic here
                knivesService.Update(knives);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Knives/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Knives/Delete/5
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
