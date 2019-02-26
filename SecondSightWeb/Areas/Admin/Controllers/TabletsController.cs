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
    public class TabletsController : Controller
    {
        ITabletsService tabletsService = new TabletsService();
        // GET: Admin/Tablets
        public ActionResult Index()
        {
            return View(tabletsService.GetAll());
        }

        // GET: Admin/Tablets/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Tablets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Tablets/Create
        [HttpPost]
        public ActionResult Create(Tablets tablets)
        {
            try
            {
                // TODO: Add insert logic here
                tabletsService.Add(tablets);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Tablets/Edit/5
        public ActionResult Edit(int id)
        {
            return View(tabletsService.GetById(id));
        }

        // POST: Admin/Tablets/Edit/5
        [HttpPost]
        public ActionResult Edit(Tablets tablets)
        {
            try
            {
                // TODO: Add update logic here
                tabletsService.Update(tablets);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Tablets/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Tablets/Delete/5
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
