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
    public class TestMasterController : Controller
    {
        ITestMasterService testMasterService = new TestMasterService();
        // GET: Admin/TestMaster
        public ActionResult Index()
        {
            return View(testMasterService.GetAll());
        }

        // GET: Admin/TestMaster/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/TestMaster/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/TestMaster/Create
        [HttpPost]
        public ActionResult Create(TestMaster testMaster)
        {
            try
            {
                // TODO: Add insert logic here
                testMasterService.Add(testMaster);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/TestMaster/Edit/5
        public ActionResult Edit(int id)
        {
            return View(testMasterService.GetById(id));
        }

        // POST: Admin/TestMaster/Edit/5
        [HttpPost]
        public ActionResult Edit(TestMaster testMaster)
        {
            try
            {
                // TODO: Add update logic here
                testMasterService.Update(testMaster);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/TestMaster/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/TestMaster/Delete/5
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
