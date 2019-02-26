using SecondSightWeb.Areas.Inventory.Controllers;
using SecondSightWeb.Common_Controle;
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
    public class DossListController : Controller
    {
        IDossListService dossListService = new DossListService();
        IDossListSummaryService dossListSummaryService = new DossListSummaryService();
        // GET: Admin/DossList
        public ActionResult Index()
        {

            return View(dossListService.GetAll());
        }

        // GET: Admin/DossList/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/DossList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DossList/Create
        [HttpPost]
        public ActionResult Create(DossList dossList)
        {
            try
            {
                // TODO: Add insert logic here
                dossListService.Add(dossList);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/DossList/Edit/5
        public ActionResult Edit(int id)
        {
            return View(dossListService.GetById(id));
        }

        // POST: Admin/DossList/Edit/5
        [HttpPost]
        public ActionResult Edit(DossList dossList)
        {
            try
            {
                // TODO: Add update logic here

                dossListService.Update(dossList);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/DossList/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        public ActionResult AddDossListSummary(int id)
        {
            return View(dossListService.GetById(id));
        }
        public JsonResult AddDossDetails(string objDetails)
        {
            Result result = new Result();
            try
            {
                List<DossListSummary> lstDossListSummary = new List<DossListSummary>();
                lstDossListSummary = CRMSerializer.Instance.Deserialize<List<DossListSummary>>(lstDossListSummary, objDetails);
                foreach (var item in lstDossListSummary)
                {
                    dossListSummaryService.Add(item);
                }
            }
            catch
            {
                result.Data = false;
            }
           
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // POST: Admin/DossList/Delete/5
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
