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
    public class CheifComplainListController : Controller
    {
        ICheifComplainListService cheifComplainListService = new CheifComplainListService();
        // GET: Admin/CheifComplainList
        public ActionResult Index()
        {
            return View(cheifComplainListService.GetAll());
        }

        // GET: Admin/CheifComplainList/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/CheifComplainList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/CheifComplainList/Create
        [HttpPost]
        public ActionResult Create(CheifComplainList cheifComplainList)
        {
            try
            {
                // TODO: Add insert logic here
                cheifComplainListService.Add(cheifComplainList);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/CheifComplainList/Edit/5
        public ActionResult Edit(int id)
        {
            return View(cheifComplainListService.GetById(id));
        }

        // POST: Admin/CheifComplainList/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CheifComplainList cheifComplainList)
        {
            try
            {
                // TODO: Add update logic here
                cheifComplainListService.Update(cheifComplainList);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/CheifComplainList/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/CheifComplainList/Delete/5
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
