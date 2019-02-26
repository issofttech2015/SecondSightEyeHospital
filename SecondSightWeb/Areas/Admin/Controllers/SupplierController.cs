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
    public class SupplierController : Controller
    {
        ISupplierService supplierService = new SupplierService();
        // GET: Admin/Supplier
        public ActionResult Index()
        {
            return View(supplierService.GetAll());
        }

        // GET: Admin/Supplier/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Supplier/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Supplier/Create
        [HttpPost]
        public ActionResult Create(Supplier supplier)
        {
            try
            {
                // TODO: Add insert logic here
                supplierService.Add(supplier);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Supplier/Edit/5
        public ActionResult Edit(int id)
        {
            return View(supplierService.GetById(id));
        }

        // POST: Admin/Supplier/Edit/5
        [HttpPost]
        public ActionResult Edit(Supplier supplier)
        {
            try
            {
                // TODO: Add update logic here
                supplierService.Update(supplier);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Supplier/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Supplier/Delete/5
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
