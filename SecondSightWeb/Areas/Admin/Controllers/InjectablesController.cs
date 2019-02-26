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
    public class InjectablesController : Controller
    {
        IInjectablesService injectablesService = new InjectablesService();
        // GET: Admin/Injectables
        public ActionResult Index()
        {
            return View(injectablesService.GetAll());
        }

        // GET: Admin/Injectables/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Injectables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Injectables/Create
        [HttpPost]
        public ActionResult Create(Injectables injectables)
        {
            try
            {
                // TODO: Add insert logic here
                injectablesService.Add(injectables);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Injectables/Edit/5
        public ActionResult Edit(int id)
        {
            return View(injectablesService.GetById(id));
        }

        // POST: Admin/Injectables/Edit/5
        [HttpPost]
        public ActionResult Edit(Injectables injectables)
        {
            try
            {
                // TODO: Add update logic here
                injectablesService.Update(injectables);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Injectables/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Injectables/Delete/5
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
