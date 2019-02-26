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
    public class ItemEntryController : Controller
    {
        // GET: Inventory/ItemEntry
        IPurchaseOrderService purchaseOrderService = new PurchaseOrderService();
        ISupplierService supplierService = new SupplierService();
        ICategoryMasterService categoryMasterService = new CategoryMasterService();
        ICategoryService categoryService = new CategoryService();
        IEmployeeService employeeService = new EmployeeService();
        IPurchaseOrderDetailsService purchaseOrderDetailsService = new PurchaseOrderDetailsService();
        public ActionResult Index()
        {
            List<ItemEntryViewModel> purchaseOrderViewModel = (from pOService in purchaseOrderService.GetAll()
                                                               join sService in supplierService.GetAll() on pOService.SupplierId equals sService.SupplierId
                                                               join em in employeeService.GetAll() on pOService.GeneratedBy equals em.EmployeeId
                                                               where pOService.IsApproved == true && pOService.IsPurchased == true && pOService.IsDelivered == false
                                                               select new ItemEntryViewModel
                                                               {
                                                                   SupplierName = sService.SupplierName,
                                                                   POID = pOService.POID,
                                                                   GeneratedBy = em.FirstName + " " + em.OtherName + " " + em.LastName,
                                                                   GeteratedTime = pOService.GeteratedTime,
                                                                   PODate = pOService.PODate,
                                                                   PurchaseAmount = pOService.PurchaseAmount
                                                               }).ToList();
            return View(purchaseOrderViewModel);
        }

        // GET: Inventory/ItemEntry/Details/5
        public ActionResult Details(int id)
        {

            List<ItemEntryListViewModel> itemEntryListViewModel = (from pODService in purchaseOrderDetailsService.GetAll()
                                                                   join pOService in purchaseOrderService.GetAll() on pODService.POID equals pOService.POID
                                                                   join cService in categoryService.GetAll() on pODService.CategoryId equals cService.CategoryId
                                                                   join cMService in categoryMasterService.GetAll() on cService.CategoryMasterId equals cMService.CategoryMasterId
                                                                   where pOService.POID == id && pODService.IsDelivered == false
                                                                   select new ItemEntryListViewModel
                                                                   {
                                                                       CategoryName = cMService.CategoryName,
                                                                       ItemName = cService.ItemName,
                                                                       ItemDescription = cService.ItemDescription,
                                                                       PODId = pODService.PODId,
                                                                       Price = pODService.Price,
                                                                       Qty = pODService.Qty - pODService.DeliveredQty,
                                                                   }).ToList();
            return View(itemEntryListViewModel);
        }

        // GET: Inventory/ItemEntry/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inventory/ItemEntry/Create
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

        // GET: Inventory/ItemEntry/Edit/5
        public ActionResult Edit(int id)
        {
            ItemEntryListEditModel itemEntryListEditModel = (from pODService in purchaseOrderDetailsService.GetAll()
                                                             join pOService in purchaseOrderService.GetAll() on pODService.POID equals pOService.POID
                                                             join cService in categoryService.GetAll() on pODService.CategoryId equals cService.CategoryId
                                                             join cMService in categoryMasterService.GetAll() on cService.CategoryMasterId equals cMService.CategoryMasterId
                                                             where pODService.PODId == id
                                                             select new ItemEntryListEditModel
                                                             {
                                                                 CategoryName = cMService.CategoryName,
                                                                 ItemName = cService.ItemName,
                                                                 ItemDescription = cService.ItemDescription,
                                                                 PODId = pODService.PODId,
                                                                 Price = pODService.Price,
                                                                 Qty = pODService.Qty - pODService.DeliveredQty,
                                                                 POID = pOService.POID,
                                                             }).FirstOrDefault();
            return View(itemEntryListEditModel);
        }

        // POST: Inventory/ItemEntry/Edit/5
        [HttpPost]
        public ActionResult Edit(ItemEntryListEditModel itemEntryListEditModelParam)
        {
            try
            {
                // TODO: Add update logic here
                //Update PurchaseOrderDetails
                PurchaseOrderDetails purchaseOrderDetails = purchaseOrderDetailsService.GetById(itemEntryListEditModelParam.PODId);
                if (purchaseOrderDetails.Qty >= purchaseOrderDetails.DeliveredQty + itemEntryListEditModelParam.Qty)
                {
                    PurchaseOrder purchaseOrder = purchaseOrderService.GetById(purchaseOrderDetails.POID);
                    if (purchaseOrderDetails.Qty == purchaseOrderDetails.DeliveredQty + itemEntryListEditModelParam.Qty)
                        purchaseOrderDetails.IsDelivered = true;
                    purchaseOrderDetails.DeliveredQty += itemEntryListEditModelParam.Qty;
                    purchaseOrderDetailsService.Update(purchaseOrderDetails);

                    //Get Store from CategoryId
                    IStoreService storeService = new StoreService();
                    Store store = storeService.GetAll().Where(x => x.CategoryId == purchaseOrderDetails.CategoryId).FirstOrDefault();
                    //ADD StoreHistory
                    IStoreHistoryService storeHistoryService = new StoreHistoryService();
                    StoreHistory storeHistory = new StoreHistory()
                    {
                        BatchNumber = itemEntryListEditModelParam.BatchNumber,
                        ExperyDate = itemEntryListEditModelParam.ExperyDate,
                        Location = itemEntryListEditModelParam.Location,
                        ManufacturingDate = itemEntryListEditModelParam.ManufacturingDate,
                        NewQty = itemEntryListEditModelParam.Qty,
                        NewRate = (purchaseOrderDetails.Price / purchaseOrderDetails.Qty),
                        OldQty = store.Qty,
                        OldRate = (purchaseOrderDetails.Price / purchaseOrderDetails.Qty),
                        RequisitionId = purchaseOrder.POID.ToString(),
                        SIdate = System.DateTime.Now,
                        StoreId = store.Storeid,
                        SupplierId = purchaseOrder.SupplierId,
                    };
                    storeHistoryService.Add(storeHistory);
                    //Update Store
                    store.RequisitionId = purchaseOrder.POID.ToString();
                    store.Qty += itemEntryListEditModelParam.Qty;
                    store.QtyTotal += itemEntryListEditModelParam.Qty;
                    store.QtyBuffer += itemEntryListEditModelParam.Qty;
                    store.SIdate = System.DateTime.Now;
                    storeService.Update(store);
                    //Update PurchaseOrder
                    PurchaseOderUpdate(purchaseOrder.POID);
                    return RedirectToAction("Details", new { id = purchaseOrder.POID });
                }
                else
                {
                    return View(itemEntryListEditModelParam);
                }
            }
            catch
            {
                return View(itemEntryListEditModelParam);
            }
        }



        private void PurchaseOderUpdate(int POId)
        {
            List<ItemEntryListViewModel> itemEntryListViewModel = (from pODService in purchaseOrderDetailsService.GetAll()
                                                                   join pOService in purchaseOrderService.GetAll() on pODService.POID equals pOService.POID
                                                                   where pOService.POID == POId
                                                                   select new ItemEntryListViewModel
                                                                   {
                                                                       IsDelivered = pODService.IsDelivered,
                                                                       Price = pODService.Price,
                                                                   }).ToList();

            bool IsDeliveredFull = true;
            Decimal TotalPrice = 0;
            foreach (var item in itemEntryListViewModel)
            {
                if (!item.IsDelivered)
                    IsDeliveredFull = false;
                else
                    TotalPrice += item.Price;
            }

            PurchaseOrder purchaseOrder = purchaseOrderService.GetById(POId);
            if (IsDeliveredFull)
                purchaseOrder.IsDelivered = true;
            purchaseOrder.PurchaseAmount = TotalPrice;
            purchaseOrderService.Update(purchaseOrder);
        }



        // GET: Inventory/ItemEntry/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Inventory/ItemEntry/Delete/5
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
