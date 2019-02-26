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
    public class AdjustmentController : Controller
    {
        IPatientService patientService = new PatientService();
        IBillService billService = new BillService();
        IPaymentDetalisService paymentDetalisService = new PaymentDetalisService();
        // GET: Inventory/Adjustment
        public ActionResult Index()
        {
            //List<AdjustmentViewModel> lstAdjustmentViewModel = (from bs in billService.GetAll()
            //                                                    join ps in patientService.GetAll() on bs.PatientId equals ps.PatientId
            //                                                    where bs.IsPaid == false && bs.IsSettlementDone == true
            //                                                    select new AdjustmentViewModel
            //                                                    {
            //                                                        BillId = bs.BillId,
            //                                                        BillAmount = bs.BillAmount,
            //                                                        PaidAmount = bs.PaymentDetails.Sum(x => x.PaymentAmount),
            //                                                        BillCode = bs.BillCode,
            //                                                        Concession = bs.Concession,
            //                                                        Contact = bs.Concession,
            //                                                        Date = bs.Date,
            //                                                        DueAmount = bs.BillAmount - (bs.Concession + bs.PaymentDetails.Sum(x => x.PaymentAmount)),
            //                                                        PatCode = ps.PatCode,
            //                                                        PatientName = ps.FirstName + " " + ps.MiddleName + " " + ps.LastName,
            //                                                    }).ToList();
            SearchStoreProcedureDB<AdjustmentViewModel> searchStoreProcedureDB = new SearchStoreProcedureDB<AdjustmentViewModel>();
            List<AdjustmentViewModel> lstAdjustmentViewModel = searchStoreProcedureDB.GetAdjustmentDetailsAndByBillId(-1).ToList();

            return View(lstAdjustmentViewModel);
        }

        // GET: Admin/Adjustment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Adjustment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Adjustment/Create
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

        // GET: Admin/Adjustment/Edit/5
        public ActionResult Edit(int id)
        {
            //AdjustmenEditModel adjustmenEditModel = (from bs in billService.GetAll()
            //                                         join ps in patientService.GetAll() on bs.PatientId equals ps.PatientId
            //                                         join pds in paymentDetalisService.GetAll() on bs.BillId equals pds.BillId
            //                                         where bs.BillId == id
            //                                         select new AdjustmenEditModel
            //                                         {
            //                                             BillId = bs.BillId,
            //                                             BillAmount = bs.BillAmount,
            //                                             BillCode = bs.BillCode,
            //                                             Concession = bs.Concession,
            //                                             Contact = ps.Contact,
            //                                             Date = bs.Date,
            //                                             PatCode = ps.PatCode,
            //                                             PatientName = ps.FirstName + " " + ps.MiddleName + " " + ps.LastName,
            //                                             PaidAmount = bs.PaymentDetails.Sum(x => x.PaymentAmount),
            //                                             DueAmount = bs.BillAmount - (bs.Concession + bs.PaymentDetails.Sum(x => x.PaymentAmount)),
            //                                             ModeOfPayment = bs.PaymentDetails.Last().ModeOfPayment,
            //                                         }).FirstOrDefault();

            SearchStoreProcedureDB<AdjustmentViewModel> searchStoreProcedureDB = new SearchStoreProcedureDB<AdjustmentViewModel>();
            AdjustmentViewModel adjustmentViewModel = searchStoreProcedureDB.GetAdjustmentDetailsAndByBillId(id).FirstOrDefault();
            AdjustmenEditModel adjustmenEditModel = new AdjustmenEditModel();
            adjustmenEditModel.BillId = adjustmentViewModel.BillId;
            adjustmenEditModel.BillAmount = adjustmentViewModel.BillAmount;
            adjustmenEditModel.BillCode = adjustmentViewModel.BillCode;
            adjustmenEditModel.Concession = adjustmentViewModel.Concession;
            adjustmenEditModel.Contact = adjustmentViewModel.Contact;
            adjustmenEditModel.Date = adjustmentViewModel.Date;
            adjustmenEditModel.PatCode = adjustmentViewModel.PatCode;
            adjustmenEditModel.PatientName = adjustmentViewModel.PatientName;
            adjustmenEditModel.PaidAmount = adjustmentViewModel.PaidAmount;
            adjustmenEditModel.DueAmount = adjustmentViewModel.DueAmount;
            adjustmenEditModel.ModeOfPayment = adjustmentViewModel.ModeOfPayment;

            adjustmenEditModel.PayAmount = adjustmentViewModel.DueAmount;
            return View(adjustmenEditModel);
        }

        // POST: Admin/Adjustment/Edit/5
        [HttpPost]
        public ActionResult Edit(AdjustmenEditModel adjustmenEditModelParam)
        {
            AdjustmenEditModel adjustmenEditModel = new AdjustmenEditModel();
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid && decimal.Parse(adjustmenEditModelParam.PayAmount.ToString()) != 0)
                {
                    // TODO: Add update logic here
                    decimal totalAmount = (adjustmenEditModelParam.Concession + adjustmenEditModelParam.PaidAmount + adjustmenEditModelParam.PayAmount);
                    if (adjustmenEditModelParam.BillAmount == totalAmount)
                    {
                        Bill bill = billService.GetById(adjustmenEditModelParam.BillId);
                        bill.IsPaid = true;
                        billService.Update(bill);
                        PaymentDetalis paymentDetalis = new PaymentDetalis()
                        {
                            BillId = adjustmenEditModelParam.BillId,
                            ModeOfPayment = adjustmenEditModelParam.ModeOfPayment,
                            ModeOfPaymentNo = adjustmenEditModelParam.ModeOfPaymentNo,
                            PaymentAmount = adjustmenEditModelParam.PayAmount,
                            PaymentDate = adjustmenEditModelParam.PaymentDate,
                            PaymentBy = int.Parse(Session["EmployeeId"].ToString())
                        };
                        paymentDetalisService.Add(paymentDetalis);
                        Session["Bill_Id"] = adjustmenEditModelParam.BillId;
                        Session["Page"] = "../Admin/Adjustment";
                        return Redirect("~/ReceptionPages/Bill_Money_Recipt.aspx");
                    }
                    else if (adjustmenEditModelParam.BillAmount > totalAmount)
                    {
                        PaymentDetalis paymentDetalis = new PaymentDetalis()
                        {
                            BillId = adjustmenEditModelParam.BillId,
                            ModeOfPayment = adjustmenEditModelParam.ModeOfPayment,
                            ModeOfPaymentNo = adjustmenEditModelParam.ModeOfPaymentNo,
                            PaymentAmount = adjustmenEditModelParam.PayAmount,
                            PaymentDate = adjustmenEditModelParam.PaymentDate,
                            PaymentBy = int.Parse(Session["EmployeeId"].ToString())
                        };
                        paymentDetalisService.Add(paymentDetalis);
                        Session["Bill_Id"] = adjustmenEditModelParam.BillId;
                        Session["Page"] = "../Admin/Adjustment";
                        return Redirect("~/ReceptionPages/Bill_Money_Recipt.aspx");
                    }
                    else
                    {
                        return View(adjustmenEditModel);
                    }
                }
                else
                {
                    return View(adjustmenEditModel);
                }
            }
            catch (Exception ex)
            {
                return View(adjustmenEditModel);
            }
        }

        // GET: Admin/Adjustment/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Adjustment/Delete/5
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
