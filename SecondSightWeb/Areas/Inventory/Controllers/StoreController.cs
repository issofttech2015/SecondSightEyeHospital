using SecondSightSouthendEyeCentre.Service.Implementation;
using SecondSightSouthendEyeCentre.Service.Interfaces;
using SecondSightWeb.Areas.Inventory.Models.ViewModel;
using SecondSightWeb.Service.Implementation;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecondSightWeb.Areas.Inventory.Controllers
{
    public class StoreController : Controller
    {
        ICategoryService categoryService = new CategoryService();
        IStoreService storeService = new StoreService();
        ISalePriceService salePriceService = new SalePriceService();
        ICategoryMasterService categoryMasterService = new CategoryMasterService();
        // GET: Inventory/Store
        public ActionResult Index()
        {
            List<StoreViewModel> storeViewModel = (from cService in categoryService.GetAll()
                                                   join sService in storeService.GetAll() on cService.CategoryId equals sService.CategoryId
                                                   join sPService in salePriceService.GetAll() on sService.CategoryId equals sPService.CategroyId
                                                   join cMService in categoryMasterService.GetAll() on cService.CategoryMasterId equals cMService.CategoryMasterId
                                                   where sPService.IsActive == true
                                                   select new StoreViewModel
                                                   {
                                                       CategoryId = cService.CategoryId,
                                                       CategoryName = cMService.CategoryName,
                                                       ItemDescription = cService.ItemDescription,
                                                       ItemName = cService.ItemName,
                                                       Qty = sService.Qty,
                                                       QtyBuffer = sService.QtyBuffer,
                                                       QtyTotal = sService.QtyTotal,
                                                       SIdate = sService.SIdate
                                                   }).ToList();
            return View(storeViewModel);
        }

        // GET: Inventory/Store/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Inventory/Store/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inventory/Store/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Inventory/Store/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Inventory/Store/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Inventory/Store/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Inventory/Store/Delete/5
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
