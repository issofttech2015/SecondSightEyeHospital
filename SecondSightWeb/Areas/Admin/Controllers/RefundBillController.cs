using SecondSightSouthendEyeCentre.Models;
using SecondSightSouthendEyeCentre.Service.Implementation;
using SecondSightSouthendEyeCentre.Service.Interfaces;
using SecondSightWeb.Areas.Admin.Models.EditModel;
using SecondSightWeb.Areas.Admin.Models.ViewModels;
using SecondSightWeb.Data.DbIntractions;
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
    public class RefundBillController : Controller
    {
        IBillService billService = new BillService();
        IPatientService patientService = new PatientService();
        IRefundBillService refundBillService = new RefundBillService();
        // GET: Admin/RefundBill
        public ActionResult Index()
        {
            //List<RefundBillViewModel> refundBillViewModel = (from bService in billService.GetAll()
            //                                                 join pService in patientService.GetAll() on bService.PatientId equals pService.PatientId
            //                                                 where bService.IsRefunded == false
            //                                                 select new RefundBillViewModel
            //                                                 {
            //                                                     BillId = bService.BillId,
            //                                                     BillCode = bService.BillCode,
            //                                                     Contact = pService.Contact,
            //                                                     BillAmount = bService.BillAmount,
            //                                                     Date = bService.Date,
            //                                                     PatCode = pService.PatCode,
            //                                                     PatientName = pService.FirstName + pService.MiddleName + pService.LastName
            //                                                 }
            //                                                 ).ToList();
            SearchStoreProcedureDB<RefundBillViewModel> searchStoreProcedureDB = new SearchStoreProcedureDB<RefundBillViewModel>();
            List<RefundBillViewModel> lstRefundBillViewModel = searchStoreProcedureDB.GetRefundBillDetailsAndByBillId(-1).ToList();
            return View(lstRefundBillViewModel);
        }

        // GET: Admin/RefundBill/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/RefundBill/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/RefundBill/Create
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

        // GET: Admin/RefundBill/Edit/5
        public ActionResult Edit(int id)
        {
            SearchStoreProcedureDB<RefundBillViewModel> searchStoreProcedureDB = new SearchStoreProcedureDB<RefundBillViewModel>();
            RefundBillViewModel refundBillViewModel = searchStoreProcedureDB.GetRefundBillDetailsAndByBillId(id).FirstOrDefault();
            RefundBillEditModel refundBillEditModel = new RefundBillEditModel();
            refundBillEditModel.BillId = refundBillViewModel.BillId;
            refundBillEditModel.BillAmount = refundBillViewModel.BillAmount;
            refundBillEditModel.BillCode = refundBillViewModel.BillCode;
            refundBillEditModel.Concession = refundBillViewModel.Concession;
            refundBillEditModel.Contact = refundBillViewModel.Contact;
            refundBillEditModel.Date = refundBillViewModel.Date;
            refundBillEditModel.PatCode = refundBillViewModel.PatCode;
            refundBillEditModel.PatientName = refundBillViewModel.PatientName;
            refundBillEditModel.PaidAmount = refundBillViewModel.PaidAmount;
            refundBillEditModel.DueAmount = refundBillViewModel.DueAmount;
            refundBillEditModel.ModeOfPayment = refundBillViewModel.ModeOfPayment;

            refundBillEditModel.RefundAmount = refundBillViewModel.PaidAmount;
            return View(refundBillEditModel);
        }

        // POST: Admin/RefundBill/Edit/5
        [HttpPost]
        public ActionResult Edit(RefundBillEditModel refundBillEditModelParam)
        {
            RefundBillEditModel refundBillEditModel = new RefundBillEditModel();
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid && decimal.Parse(refundBillEditModelParam.RefundAmount.ToString()) != 0)
                {
                    // TODO: Add update logic here
                    if (refundBillEditModelParam.PaidAmount >= refundBillEditModelParam.RefundAmount)
                    {
                        Bill bill = billService.GetById(refundBillEditModelParam.BillId);
                        bill.IsRefunded = true;
                        billService.Update(bill);
                        RefundBill refundBill = new RefundBill()
                        {
                            BillId = bill.BillId,
                            RefundBy = int.Parse(Session["EmployeeId"].ToString()),
                            Date=DateTime.Now,
                            RefundAmount= decimal.Parse( refundBillEditModelParam.RefundAmount.ToString()),
                            ChequeNo= refundBillEditModelParam.ModeOfPaymentNo,
                            ModeOfPayment = refundBillEditModelParam.ModeOfPayment,
                            Purpose = refundBillEditModelParam.Purpose
                        };
                        refundBillService.Add(refundBill);
                        Session["Bill_Id"] = refundBillEditModelParam.BillId;
                        Session["Page"] = "../Admin/RefundBill";
                        return Redirect("~/ReceptionPages/Bill_Money_Recipt.aspx");
                    }
                    else
                    {
                        return View(refundBillEditModel);
                    }
                }
                else
                {
                    return View(refundBillEditModel);
                }
            }
            catch (Exception ex)
            {
                return View(refundBillEditModel);
            }
        }

        // GET: Admin/RefundBill/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/RefundBill/Delete/5
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
