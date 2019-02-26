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
    public class OtCheckListController : Controller
    {
        // GET: Admin/OtCheckList
        IOtCheckListService otCheckListService = new OtCheckListService();
        public ActionResult Index()
        {
            return View(otCheckListService.GetAll().Where(x=>x.IsDeleted==false));
        }

        // GET: Admin/OtCheckList/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/OtCheckList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/OtCheckList/Create
        [HttpPost]
        public ActionResult Create(OtCheckList otCheckList)
        {
            try
            {
                // TODO: Add insert logic here
                otCheckList = otCheckListService.Add(otCheckList);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Admin/OtCheckList/Edit/5
        public ActionResult Edit(int id)
        {
            return View(otCheckListService.GetById(id));
        }

        // POST: Admin/OtCheckList/Edit/5
        [HttpPost]
        public ActionResult Edit(OtCheckList otCheckList)
        {
            try
            {
                // TODO: Add update logic here
                otCheckListService.Update(otCheckList);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/OtCheckList/Delete/5
        public ActionResult Delete(int id)
        {
            OtCheckList otCheckList = otCheckListService.GetById(id);
            otCheckList.IsDeleted = true;
            otCheckListService.Update(otCheckList);
            return RedirectToAction("Index");
        }

        // POST: Admin/OtCheckList/Delete/5
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
