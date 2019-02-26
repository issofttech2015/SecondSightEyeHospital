using SecondSightSouthendEyeCentre.Service.Implementation;
using SecondSightSouthendEyeCentre.Service.Interfaces;
using SecondSightWeb.Areas.Inventory.Models.EditModel;
using SecondSightWeb.Areas.Inventory.Models.ViewModel;
using SecondSightWeb.Common_Controle;
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
    public class PurchaseOrderController : Controller
    {
        IPurchaseOrderService purchaseOrderService = new PurchaseOrderService();
        ISupplierService supplierService = new SupplierService();
        ICategoryMasterService categoryMasterService = new CategoryMasterService();
        ICategoryService categoryService = new CategoryService();
        IStoreHistoryService storeHistoryService = new StoreHistoryService();
        IStoreService storeService = new StoreService();
        IEmployeeService employeeService = new EmployeeService();
        IPurchaseOrderDetailsService purchaseOrderDetailsService = new PurchaseOrderDetailsService();
        // GET: Inventory/PurchaseOrder
        public ActionResult Index()
        {
            List<PurchaseOrderViewModel> purchaseOrderViewModel = (from pOService in purchaseOrderService.GetAll()
                                                                   join sService in supplierService.GetAll() on pOService.SupplierId equals sService.SupplierId
                                                                   join em in employeeService.GetAll() on pOService.GeneratedBy equals em.EmployeeId
                                                                   where pOService.IsApproved == false && pOService.IsPurchased == false && pOService.IsRejected == false
                                                                   select new PurchaseOrderViewModel
                                                                   {
                                                                       SupplierName = sService.SupplierName,
                                                                       POID = pOService.POID,
                                                                       GeneratedBy = em.FirstName + " " + em.OtherName + " " + em.LastName,
                                                                       GeteratedTime = pOService.GeteratedTime,
                                                                       IsApproved = pOService.IsApproved,
                                                                       IsPurchased = pOService.IsPurchased,
                                                                       IsRejected = pOService.IsRejected,
                                                                       PODate = pOService.PODate,
                                                                       PreviewAmount = pOService.PreviewAmount,
                                                                       PurchaseAmount = pOService.PurchaseAmount
                                                                   }).ToList();
            return View(purchaseOrderViewModel);
        }

        // GET: Inventory/PurchaseOrder/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Inventory/PurchaseOrder/Create
        public ActionResult Create()
        {
            PurchaseOrderEditModel purchaseOrderEditModel = new PurchaseOrderEditModel();
            BindPurchaseOrder(purchaseOrderEditModel);
            return View(purchaseOrderEditModel);
        }
        public JsonResult GetCategorybyMaster(int id)
        {
            var categroyNames = categoryService.GetCategoryByMaster(id).Select(x => x.ItemName).Distinct();
            return Json(categroyNames, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCategoryByNames(string name)
        {
            var categoryDescription = categoryService.GetCategoryByName(name);
            return Json(categoryDescription, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetLastPricebyCategoryId(int id)
        {
            var price = from sh in storeHistoryService.GetAll()
                        join st in storeService.GetAll().OrderByDescending(x => x.SIdate) on sh.StoreId equals st.Storeid
                        join ct in categoryService.GetAll() on st.CategoryId equals ct.CategoryId
                        where ct.CategoryId == id
                        select sh.NewRate;
            return Json(price.LastOrDefault(), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult AddPurchaseOrder(string purchaseList, string supplierId, string date)
        {
            Result result = new Result();
            try
            {
                List<PurchaseOrderDetails> lstPurchaseOrderDetails = new List<PurchaseOrderDetails>();
                lstPurchaseOrderDetails = CRMSerializer.Instance.Deserialize<List<PurchaseOrderDetails>>(lstPurchaseOrderDetails, purchaseList);
                PurchaseOrder purchaseOrder = new PurchaseOrder()
                {
                    GeneratedBy = int.Parse(Session["EmployeeId"].ToString()),
                    GeteratedTime = DateTime.Now,
                    IsApproved = false,
                    IsPurchased = false,
                    IsRejected = false,
                    PODate = DateTime.Parse(date),//This must be calender control
                    SupplierId = int.Parse(supplierId),//this must be a dropdown,
                    PreviewAmount = 0,
                    PurchaseAmount = 0
                };
                purchaseOrder = purchaseOrderService.Add(purchaseOrder);
                //lstPurchaseOrderDetails.ForEach(x => x.POID = purchaseOrder.POID);
                decimal TotalPrice = 0;
                if (purchaseOrder.POID != 0)
                {
                    foreach (var item in lstPurchaseOrderDetails)
                    {
                        item.POID = purchaseOrder.POID;
                        TotalPrice += item.Price;
                        purchaseOrderDetailsService.Add(item);
                    }
                }
                purchaseOrder.PreviewAmount = TotalPrice;
                purchaseOrderService.Update(purchaseOrder);
                Session["PO_Id"] = purchaseOrder.POID;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                result.Data = false;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }
        public void BindPurchaseOrder(PurchaseOrderEditModel purchaseOrderEditModel)
        {
            purchaseOrderEditModel.CategoryMasters = categoryMasterService.GetAll();
            purchaseOrderEditModel.CategoryNames = categoryService.GetAll();
            purchaseOrderEditModel.Categories = categoryService.GetAll();
            purchaseOrderEditModel.Suppliers = supplierService.GetAll();
        }
        // POST: Inventory/PurchaseOrder/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: Inventory/PurchaseOrder/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Inventory/PurchaseOrder/Edit/5
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

        // GET: Inventory/PurchaseOrder/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Inventory/PurchaseOrder/Delete/5
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
        public ActionResult PurchaseOrderRe_Print(int id)
        {
            Session["PO_Id"] = id;
            Session["Page"] = "../Inventory/PurchaseOrder";
            return Redirect("~/CommonPages/PurchaseOrderRecipt.aspx");
        }
    }
    public class Result
    {
        public bool Data { get; set; } = true;
    }
}