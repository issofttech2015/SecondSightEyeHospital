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
    public class MedicineTypeListController : Controller
    {
        IMedicineTypeListService medicineTypeListService = new MedicineTypeListService();
        // GET: Admin/MedicineTypeList
        public ActionResult Index()
        {
            return View(medicineTypeListService.GetAll());
        }

        // GET: Admin/MedicineTypeList/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/MedicineTypeList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/MedicineTypeList/Create
        [HttpPost]
        public ActionResult Create(MedicineTypeList medicineTypeList)
        {
            try
            {
                // TODO: Add insert logic here
                medicineTypeListService.Add(medicineTypeList);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/MedicineTypeList/Edit/5
        public ActionResult Edit(int id)
        {
            return View(medicineTypeListService.GetById(id));
        }

        // POST: Admin/MedicineTypeList/Edit/5
        [HttpPost]
        public ActionResult Edit(MedicineTypeList medicineTypeList)
        {
            try
            {
                // TODO: Add update logic here
                medicineTypeListService.Update(medicineTypeList);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/MedicineTypeList/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/MedicineTypeList/Delete/5
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
