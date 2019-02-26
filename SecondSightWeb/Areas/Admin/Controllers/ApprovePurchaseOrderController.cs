using SecondSightSouthendEyeCentre.Service.Implementation;
using SecondSightSouthendEyeCentre.Service.Interfaces;
using SecondSightWeb.Areas.Inventory.Models.ViewModel;
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
    public class ApprovePurchaseOrderController : Controller
    {
        IPurchaseOrderService purchaseOrderService = new PurchaseOrderService();
        ISupplierService supplierService = new SupplierService();
        //ICategoryMasterService categoryMasterService = new CategoryMasterService();
        //ICategoryService categoryService = new CategoryService();
        IEmployeeService employeeService = new EmployeeService();
        //IPurchaseOrderDetailsService purchaseOrderDetailsService = new PurchaseOrderDetailsService();
        // GET: Admin/ApprovePurchaseOrder
        public ActionResult Index()
        {
            List<ItemEntryViewModel> purchaseOrderViewModel = (from pOService in purchaseOrderService.GetAll()
                                                               join sService in supplierService.GetAll() on pOService.SupplierId equals sService.SupplierId
                                                               join em in employeeService.GetAll() on pOService.GeneratedBy equals em.EmployeeId
                                                               where pOService.IsApproved == false && pOService.IsPurchased == false && pOService.IsDelivered == false
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

        // GET: Admin/ApprovePurchaseOrder/View
        public ActionResult ViewPurchaseOrder(int id)
        {
            Session["PO_Id"] = id;
            Session["Page"] = "../Admin/ApprovePurchaseOrder";
            return Redirect("~/CommonPages/PurchaseOrderRecipt.aspx");
        }

        public ActionResult ApprovePurchaseOrder(int id)
        {
            try
            {
                // TODO: Add insert logic here
                PurchaseOrder purchaseOrder = purchaseOrderService.GetById(id);
                purchaseOrder.IsApproved = true;
                purchaseOrder.IsPurchased = true;
                purchaseOrderService.Update(purchaseOrder);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

        // GET: Admin/ApprovePurchaseOrder/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: Admin/ApprovePurchaseOrder/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ApprovePurchaseOrder/Create
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

        // GET: Admin/ApprovePurchaseOrder/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/ApprovePurchaseOrder/Edit/5
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

        // GET: Admin/ApprovePurchaseOrder/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/ApprovePurchaseOrder/Delete/5
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
