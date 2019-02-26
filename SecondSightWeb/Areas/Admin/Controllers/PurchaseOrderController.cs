using SecondSightSouthendEyeCentre.Service.Implementation;
using SecondSightSouthendEyeCentre.Service.Interfaces;
using SecondSightWeb.Areas.Admin.Models.ViewModel;
using SecondSightWeb.Service.Implementation;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecondSightWeb.Areas.Admin.Controllers
{
    public class PurchaseOrderController : Controller
    {
        // GET: Admin/PurchaseOrder
        IPurchaseOrderService purchaseOrderService = new PurchaseOrderService();
        ISupplierService supplierService = new SupplierService();
        IEmployeeService employeeService = new EmployeeService();
        public ActionResult Index()
        {
            List<PurchaseOrderViewModel> purchaseOrderViewModel = (from po in purchaseOrderService.GetAll()
                                                                   join ss in supplierService.GetAll() on po.SupplierId equals ss.SupplierId join es in employeeService.GetAll() on po.GeneratedBy equals es.EmployeeId
                                                                   where po.IsApproved == false
                                                                   select new PurchaseOrderViewModel
                                                                   {
                                                                       POID = po.POID,
                                                                       PODate = po.PODate,
                                                                       GeteratedTime = po.GeteratedTime,
                                                                       PreviewAmount = po.PreviewAmount,
                                                                       SupplierName = ss.SupplierName,
                                                                       GeneratedBy =es.FirstName+" "+es.OtherName+" "+es.LastName

                                                                   }).ToList();
            return View(purchaseOrderViewModel);
        }

        // GET: Admin/PurchaseOrder/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/PurchaseOrder/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/PurchaseOrder/Create
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

        // GET: Admin/PurchaseOrder/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/PurchaseOrder/Edit/5
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

        // GET: Admin/PurchaseOrder/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/PurchaseOrder/Delete/5
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
