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
    public class DisposablesController : Controller
    {
        IDisposablesService disposablesService = new DisposablesService();
        // GET: Admin/Disposables
        public ActionResult Index()
        {
            return View(disposablesService.GetAll());
        }

        // GET: Admin/Disposables/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Disposables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Disposables/Create
        [HttpPost]
        public ActionResult Create(Disposables disposables)
        {
            try
            {
                // TODO: Add insert logic here
                disposablesService.Add(disposables);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Disposables/Edit/5
        public ActionResult Edit(int id)
        {
            return View(disposablesService.GetById(id));
        }

        // POST: Admin/Disposables/Edit/5
        [HttpPost]
        public ActionResult Edit(Disposables disposables)
        {
            try
            {
                // TODO: Add update logic here
                disposablesService.Update(disposables);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Disposables/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Disposables/Delete/5
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
