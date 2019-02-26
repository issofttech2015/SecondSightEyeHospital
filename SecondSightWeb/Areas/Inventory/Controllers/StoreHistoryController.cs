using SecondSightSouthendEyeCentre.Models;
using SecondSightSouthendEyeCentre.Service.Implementation;
using SecondSightSouthendEyeCentre.Service.Interfaces;
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
    public class StoreHistoryController : Controller
    {
        ICategoryService categoryService = new CategoryService();
        IStoreService storeService = new StoreService();
        IStoreHistoryService storeHistoryService = new StoreHistoryService();
        ISalePriceService salePriceService = new SalePriceService();
        ICategoryMasterService categoryMasterService = new CategoryMasterService();
        ISupplierService supplierService = new SupplierService();
        // GET: Inventory/StoreHistory
        public ActionResult Index()
        {
            List<StoreHistoryViewModel> storeHistoryViewModel = (from cService in categoryService.GetAll()
                                                                 join cMService in categoryMasterService.GetAll() on cService.CategoryMasterId equals cMService.CategoryMasterId
                                                                 join sPService in salePriceService.GetAll() on cService.CategoryId equals sPService.CategroyId
                                                                 join sService in storeService.GetAll() on cService.CategoryId equals sService.CategoryId
                                                                 join sHSerivice in storeHistoryService.GetAll() on sService.Storeid equals sHSerivice.StoreId
                                                                 join supService in supplierService.GetAll() on sHSerivice.SupplierId equals supService.SupplierId
                                                                 where sPService.IsActive == true
                                                                 select new StoreHistoryViewModel
                                                                 {
                                                                     CategoryId = cService.CategoryId,
                                                                     CategoryName = cMService.CategoryName,
                                                                     ItemName = cService.ItemName,
                                                                     ItemDescription = cService.ItemDescription,
                                                                     BatchNumber = sHSerivice.BatchNumber,
                                                                     ExperyDate = sHSerivice.ExperyDate,
                                                                     Location = sHSerivice.Location,
                                                                     ManufacturingDate = sHSerivice.ManufacturingDate,
                                                                     NewRate = sHSerivice.NewRate,
                                                                     SupplierName = supService.SupplierName
                                                                 }).ToList();
            return View(storeHistoryViewModel);
        }

        // GET: Inventory/StoreHistory/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Inventory/StoreHistory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inventory/StoreHistory/Create
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
        private void BindStoreHistoryEditModel(StoreHistoryEditModel storeHistoryEditModelParam)
        {
            storeHistoryEditModelParam.Supplier = supplierService.GetAll();
        }
        // GET: Inventory/StoreHistory/Edit/5
        public ActionResult Edit(int id)
        {
            StoreHistoryEditModel storeHistoryEditModel = new StoreHistoryEditModel();
            BindStoreHistoryEditModel(storeHistoryEditModel);
            Category category = new Category();
            category = categoryService.GetById(id);
            CategoryMaster categoryMaster = new CategoryMaster();
            categoryMaster = categoryMasterService.GetById(int.Parse(category.CategoryMasterId.ToString()));
            Store store = new Store();
            store = storeService.GetAll().Where(x => x.CategoryId == category.CategoryId).Last();
            StoreHistory storeHistory = new StoreHistory();
            storeHistory = storeHistoryService.GetAll().Where(x => x.StoreId == store.Storeid).Last();
            storeHistoryEditModel.Category = category;
            storeHistoryEditModel.Store = store;
            storeHistoryEditModel.StoreHistory = storeHistory;
            storeHistoryEditModel.CategoryMasters = categoryMaster;
            return View(storeHistoryEditModel);
        }

        // POST: Inventory/StoreHistory/Edit/5
        [HttpPost]
        public ActionResult Edit(StoreHistoryEditModel storeHistoryEditModelParam)
        {
            StoreHistoryEditModel storeHistoryEditModel = new StoreHistoryEditModel();
            storeHistoryEditModel = storeHistoryEditModelParam;
            BindStoreHistoryEditModel(storeHistoryEditModel);
            try
            {
                // TODO: Add update logic here
                storeHistoryService.Update(storeHistoryEditModel.StoreHistory);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(storeHistoryEditModel);
            }
        }

        // GET: Inventory/StoreHistory/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Inventory/StoreHistory/Delete/5
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
