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
    public class MiscellaneousController : Controller
    {
        IMiscellaneousService miscellaneousService = new MiscellaneousService();
        // GET: Admin/Miscellaneous
        public ActionResult Index()
        {
            return View(miscellaneousService.GetAll());
        }

        // GET: Admin/Miscellaneous/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Miscellaneous/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Miscellaneous/Create
        [HttpPost]
        public ActionResult Create(Miscellaneous miscellaneous)
        {
            try
            {
                // TODO: Add insert logic here
                miscellaneousService.Add(miscellaneous);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Miscellaneous/Edit/5
        public ActionResult Edit(int id)
        {
            return View(miscellaneousService.GetById(id));
        }

        // POST: Admin/Miscellaneous/Edit/5
        [HttpPost]
        public ActionResult Edit(Miscellaneous miscellaneous)
        {
            try
            {
                // TODO: Add update logic here
                miscellaneousService.Update(miscellaneous);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Miscellaneous/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Miscellaneous/Delete/5
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
