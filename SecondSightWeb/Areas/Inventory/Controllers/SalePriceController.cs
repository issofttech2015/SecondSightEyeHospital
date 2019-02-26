using SecondSightSouthendEyeCentre.Models;
using SecondSightSouthendEyeCentre.Service.Implementation;
using SecondSightSouthendEyeCentre.Service.Interfaces;
using SecondSightWeb.Areas.Inventory.Models.DTO;
using SecondSightWeb.Areas.Inventory.Models.EditModel;
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
    public class SalePriceController : Controller
    {
        ICategoryService categoryService = new CategoryService();
        ISalePriceService salePriceService = new SalePriceService();
        ICategoryMasterService categoryMasterService = new CategoryMasterService();
        // GET: Inventory/SalePrice
        public ActionResult Index()
        {
            List<SalePriceViewModel> salePriceViewModel = (from cService in categoryService.GetAll()
                                                           join sPService in salePriceService.GetAll() on cService.CategoryId equals sPService.CategroyId
                                                           join cMService in categoryMasterService.GetAll() on cService.CategoryMasterId equals cMService.CategoryMasterId
                                                           where sPService.IsActive == true
                                                           select new SalePriceViewModel
                                                           {
                                                               CategoryId = cService.CategoryId,
                                                               CategoryName = cMService.CategoryName,
                                                               ItemName = cService.ItemName,
                                                               ItemDescription = cService.ItemDescription,
                                                               AddedOn = sPService.AddedOn,
                                                               SaleingPrice = sPService.SaleingPrice
                                                           }
                                                         ).ToList();
            return View(salePriceViewModel);
        }

        // GET: Inventory/SalePrice/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        private void BindSalePriceEditModel(SalePriceEditModel salePriceEditModel)
        {
            salePriceEditModel.CategoryMasters = categoryMasterService.GetAll();
            salePriceEditModel.CategoryNames = categoryService.GetAll();
            salePriceEditModel.Categories= categoryService.GetAll();
        }
        // GET: Inventory/SalePrice/Create
        public bool iSInit = true;
        public ActionResult Create()
        {
            SalePriceEditModel salePriceEditModel = new SalePriceEditModel();
            BindSalePriceEditModel(salePriceEditModel);
            return View(salePriceEditModel);
        }
        public JsonResult GetCategorybyMaster(int id)
        {
            var categroyNames = categoryService.GetCategoryByMaster(id).Select(x=>x.ItemName).Distinct();
            return Json(categroyNames, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCategoryByNames(string name)
        {
            var categoryDescription = categoryService.GetCategoryByName(name);
            return Json(categoryDescription, JsonRequestBehavior.AllowGet);
        }
        // POST: Inventory/SalePrice/Create
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

        // GET: Inventory/SalePrice/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Inventory/SalePrice/Edit/5
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

        // GET: Inventory/SalePrice/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Inventory/SalePrice/Delete/5
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
