using SecondSightSouthendEyeCentre.Models;
using SecondSightSouthendEyeCentre.Service.Implementation;
using SecondSightSouthendEyeCentre.Service.Interfaces;
using SecondSightWeb.Areas.Inventory.Models.EditModel;
using SecondSightWeb.Areas.Inventory.Models.ViewModel;
using SecondSightWeb.Models;
using SecondSightWeb.Service.Implementation;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecondSightWeb.Areas.Inventory.Controllers
{
    public class CategroyController : Controller
    {
        ICategoryService categoryService = new CategoryService();
        IStoreService storeService = new StoreService();
        IStoreHistoryService storeHistoryService = new StoreHistoryService();
        ISalePriceService salePriceService = new SalePriceService();
        ICategoryMasterService categoryMasterService = new CategoryMasterService();
        ISupplierService supplierService = new SupplierService();
        // GET: Inventory/Categroy
        public ActionResult Index()
        {
            List<CategroyViewModel> categroyViewModel = (from cService in categoryService.GetAll()
                                                         join sService in storeService.GetAll() on cService.CategoryId equals sService.CategoryId
                                                         join sPService in salePriceService.GetAll() on sService.CategoryId equals sPService.CategroyId
                                                         join cMService in categoryMasterService.GetAll() on cService.CategoryMasterId equals cMService.CategoryMasterId
                                                         where sPService.IsActive == true
                                                         select new CategroyViewModel
                                                         {
                                                             CategoryId = cService.CategoryId,
                                                             ItemName = cService.ItemName,
                                                             ItemDescription = cService.ItemDescription,
                                                             Type = cService.Type,
                                                             Unit = cService.Unit,
                                                             AssetTag = cService.AssetTag,
                                                             ReOrderLevel = cService.ReOrderLevel,
                                                             Qty = sService.Qty,
                                                             SaleingPrice = sPService.SaleingPrice,
                                                             CategoryName = cMService.CategoryName
                                                         }).ToList();
            return View(categroyViewModel);
        }

        // GET: Inventory/Categroy/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        private void BindCategoryEditModel(CategroyEditModel categroyEditModel)
        {
            categroyEditModel.CategoryMasters = categoryMasterService.GetAll();
            categroyEditModel.Supplier = supplierService.GetAll();
        }
        // GET: Inventory/Categroy/Create
        public ActionResult Create()
        {
            CategroyEditModel categroyEditModel = new CategroyEditModel();
            BindCategoryEditModel(categroyEditModel);
            return View(categroyEditModel);
        }

        // POST: Inventory/Categroy/Create
        [HttpPost]
        public ActionResult Create(CategroyEditModel CategroyEditModel)
        {
            CategroyEditModel categroyEditModel = new CategroyEditModel();
            BindCategoryEditModel(categroyEditModel);
            try
            {
                if (ModelState.IsValid)
                {
                    Category category = new Category()
                    {
                        ItemName = CategroyEditModel.Category.ItemName,
                        ItemDescription = CategroyEditModel.Category.ItemDescription,
                        AssetTag = CategroyEditModel.Category.AssetTag,
                        ReOrderLevel = CategroyEditModel.Category.ReOrderLevel,
                        Type = CategroyEditModel.Category.Unit,
                        Unit = CategroyEditModel.Category.Unit,
                        CategoryMasterId = CategroyEditModel.Category.CategoryMasterId
                    };
                    category = categoryService.Add(category);
                    Store store = new Store()
                    {
                        CategoryId = category.CategoryId,
                        Qty = CategroyEditModel.Store.Qty,
                        QtyBuffer = CategroyEditModel.Store.Qty,
                        QtyTotal = CategroyEditModel.Store.Qty,
                        SIdate = System.DateTime.Now.Date,
                        SOdate = System.DateTime.Now.Date,
                        RequisitionId = "",
                        SStatus = "Present",
                    };
                    store = storeService.Add(store);
                    StoreHistory storeHistory = new StoreHistory()
                    {
                        SIdate = System.DateTime.Now.Date,
                        StoreId = store.Storeid,
                        SupplierId = CategroyEditModel.StoreHistory.SupplierId,
                        Location = CategroyEditModel.StoreHistory.Location,
                        RequisitionId = "N/A",
                        ManufacturingDate = CategroyEditModel.StoreHistory.ManufacturingDate,
                        ExperyDate = CategroyEditModel.StoreHistory.ExperyDate,
                        BatchNumber = CategroyEditModel.StoreHistory.BatchNumber,
                        NewQty = CategroyEditModel.Store.Qty,
                        OldQty = 0,
                        NewRate = CategroyEditModel.StoreHistory.NewRate,
                        OldRate = 0
                    };
                    storeHistory = storeHistoryService.Add(storeHistory);
                    SalePrice salePrice = new SalePrice()
                    {
                        AddedOn = System.DateTime.Now.Date,
                        SaleingPrice = CategroyEditModel.SalePrice.SaleingPrice,
                        CategroyId = category.CategoryId,
                        ClosedOn = System.DateTime.Now.Date,
                        IsActive = true
                    };
                    salePriceService.Add(salePrice);
                    // TODO: Add insert logic here
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(categroyEditModel);
                }

            }
            catch
            {
                return View(categroyEditModel);
            }
        }

        // GET: Inventory/Categroy/Edit/5
        public ActionResult Edit(int id)
        {
            CategroyEditModel categroyEditModel = new CategroyEditModel();
            Category category = new Category();
            category = categoryService.GetById(id);
            categroyEditModel.Category = category;
            BindCategoryEditModel(categroyEditModel);
            return View(categroyEditModel);
        }

        // POST: Inventory/Categroy/Edit/5
        [HttpPost]
        public ActionResult Edit(CategroyEditModel categroyEditModel)
        {
            CategroyEditModel categroyEditModelVeiw = new CategroyEditModel();
            BindCategoryEditModel(categroyEditModelVeiw);
            try
            {
                // TODO: Add update logic here
                categroyEditModelVeiw = categroyEditModel;
                categoryService.Update(categroyEditModelVeiw.Category);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(categroyEditModelVeiw);
            }
        }

        // GET: Inventory/Categroy/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Inventory/Categroy/Delete/5
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
