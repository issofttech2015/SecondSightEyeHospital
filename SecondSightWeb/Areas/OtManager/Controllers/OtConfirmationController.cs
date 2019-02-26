using SecondSightSouthendEyeCentre;
using SecondSightSouthendEyeCentre.Models;
using SecondSightSouthendEyeCentre.Service.Implementation;
using SecondSightSouthendEyeCentre.Service.Interfaces;
using SecondSightWeb.Areas.OtManager.Models.DTO;
using SecondSightWeb.Areas.OtManager.Models.EditModels;
using SecondSightWeb.Areas.OtManager.Models.ViewModels;
using SecondSightWeb.Common_Controle;
using SecondSightWeb.Data.DbIntractions;
using SecondSightWeb.Models;
using SecondSightWeb.Service.Implementation;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecondSightWeb.Areas.OtManager.Controllers
{
    public class OtConfirmationController : Controller
    {
        IOperationSuggestionService operationSuggestionService = new OperationSuggestionService();
        IOTChargeCategoryService oTChargeCategoryService = new OTChargeCategoryService();
        IPatientService patientService = new PatientService();
        IEmployeeService employeeService = new EmployeeService();
        IOTChargesService oTChargesService = new OTChargesService();
        IEmployeeLogService employeeLogService = new EmployeeLogService();
        IOtCheckListService otCheckListService = new OtCheckListService();
        IExaminationDropsService examinationDropsService = new ExaminationDropsService();
        IOperarionDetailsService operarionDetailsService = new OperarionDetailsService();
        IBillService billService = new BillService();
        IBillSummeryService billSummeryService = new BillSummeryService();
        // GET: OtManager/OtConfirmation
        public ActionResult Index()
        {
            List<OtConfirmationViewModel> lstOtConfirmationViewModel = (from op in operationSuggestionService.GetAll()
                                                                        join otcs in oTChargesService.GetAll() on op.OperationCategory equals otcs.OtChargeId
                                                                        join emp in employeeService.GetAll() on op.RefferedBy equals emp.EmployeeId
                                                                        join ps in patientService.GetAll() on op.PatientId equals ps.PatientId
                                                                        join otCat in oTChargeCategoryService.GetAll() on otcs.OtCategoryId equals otCat.Id
                                                                        where op.IsCancelled == false && op.IsDeleted == false && op.IsConvertedToOT == false
                                                                        select new OtConfirmationViewModel
                                                                        {
                                                                            ReffredbyDoctorsName = emp.FirstName + " " + emp.OtherName + " " + emp.LastName,
                                                                            Eye = op.Eye,
                                                                            OperationSuggessitionId = op.Id,
                                                                            Operation = otCat.OtChargeCategory,
                                                                            SurgicalProcedure = otcs.Name,
                                                                            OperationTime = op.OperationDate,
                                                                            PatientName = ps.FirstName + " " + ps.MiddleName + " " + ps.LastName,
                                                                            SuggestedDoctor = op.DoctorsName

                                                                        }).ToList();
            return View(lstOtConfirmationViewModel);
        }
        [HttpPost]
        public ActionResult Details(OperationDetailsEditModel operationDetailsEditModel)
        {
            try
            {
                operationDetailsEditModel.OperationSuggestion = operationSuggestionService.GetById(operationDetailsEditModel.OperationSuggestion.Id);
                operationDetailsEditModel.OperationSuggestion.IsConvertedToOT = true;
                operationDetailsEditModel.OperationSuggestion.OperationCategory = operationDetailsEditModel.OperarionDetails.SurgicalProcedure;
                operationSuggestionService.Update(operationDetailsEditModel.OperationSuggestion);
                //OperarionDetails
                DateTime startDate = operationDetailsEditModel.OperarionDetails.FromDate;
                DateTime endDate = operationDetailsEditModel.OperarionDetails.ToDate;
                //operationDetailsEditModel.OperarionDetails.FromDate = ;
                operationDetailsEditModel.OperarionDetails.IsOperated = false;
                operationDetailsEditModel.OperarionDetails.OperationEye = operationDetailsEditModel.OperationSuggestion.Eye;
                operationDetailsEditModel.OperarionDetails.OperationSuggestionId = operationDetailsEditModel.OperationSuggestion.Id;
                operationDetailsEditModel.OperarionDetails.PatientId = operationDetailsEditModel.OperationSuggestion.PatientId;
                operationDetailsEditModel.OperarionDetails.FromDate= operationDetailsEditModel.OperarionDetails.OperationDate;
                operationDetailsEditModel.OperarionDetails.ToDate = operationDetailsEditModel.OperarionDetails.OperationDate.AddDays((double)operationDetailsEditModel.OperarionDetails.Duration);
                operationDetailsEditModel.OperarionDetails.IsGeneratedSurgicalConsumptionList = false;

                operationDetailsEditModel.OperarionDetails = operarionDetailsService.Add(operationDetailsEditModel.OperarionDetails);
                //Bill
                SearchStoreProcedureDB<SumOfOtCharge> searchStoreProcedureDB = new SearchStoreProcedureDB<SumOfOtCharge>();
                SumOfOtCharge Cost_Associated = searchStoreProcedureDB.GetSumOfOtChargeByOtChargeId(operationDetailsEditModel.OperarionDetails.SurgicalProcedure).FirstOrDefault();
                ISequenceService sequenceService = new SequenceService();
                Sequence sequence = sequenceService.GetById(4);
                Bill bill = new Bill()
                {
                    PatientId = operationDetailsEditModel.OperationSuggestion.PatientId,
                    BillAmount = decimal.Parse(Cost_Associated.Cost_Associated.ToString()),
                    OperationId = operationDetailsEditModel.OperarionDetails.OperationId,
                    Date = System.DateTime.Now,
                    IsPaid = false,
                    BillCode = sequence.Prefix + "/" + (sequence.SequenceCode + 1) + "/" + Common_Methods.GetCurrentFinancialYear(),
                    IsSettlementDone = false,
                };
                bill = billService.Add(bill);
                //BillSummery
                BillSummery billSummery = new BillSummery()
                {
                    BillId = bill.BillId,
                    OperationId = bill.OperationId,
                    PatientId = bill.PatientId,
                    BedDays = operationDetailsEditModel.OperarionDetails.Duration,
                    StartDate = startDate,
                    EndDate = endDate
                };
                billSummeryService.Add(billSummery);
                sequence.SequenceCode = sequence.SequenceCode + 1;
                sequenceService.Update(sequence);
                return RedirectToAction("Index");
            }
            catch
            {
                BindOpeartionDetaiils(operationDetailsEditModel);
                return View(operationDetailsEditModel);
            }
        }
        // GET: OtManager/OtConfirmation/Details/5
        public ActionResult Details(int id)
        {
            OperationDetailsEditModel operationDetailsEditModelDisplay = new OperationDetailsEditModel();
            operationDetailsEditModelDisplay.OperationSuggestion = operationSuggestionService.GetById(id);
            operationDetailsEditModelDisplay.SurgicalProcedure = oTChargesService.GetAll().Where(x => x.OtChargeId == operationDetailsEditModelDisplay.OperationSuggestion.OperationCategory);
            BindOpeartionDetaiils(operationDetailsEditModelDisplay);
            return View(operationDetailsEditModelDisplay);
        }
        private void BindOpeartionDetaiils(OperationDetailsEditModel operationDetailsEditModel)
        {
            operationDetailsEditModel.Patient = patientService.GetById(operationDetailsEditModel.OperationSuggestion.PatientId);
            operationDetailsEditModel.OperationId = oTChargesService.GetById(operationDetailsEditModel.OperationSuggestion.OperationCategory).OtCategoryId;
            operationDetailsEditModel.SurgicalProcedure = oTChargesService.GetAll().Where(x => x.OtCategoryId == operationDetailsEditModel.OperationId);
            operationDetailsEditModel.OtCheckLists = otCheckListService.GetAll().Where(x => x.IsDeleted == false).ToList();
            operationDetailsEditModel.OTChargeCategories = oTChargeCategoryService.GetAll();
            operationDetailsEditModel.Doctors = from emp in employeeService.GetAll()
                                                join empLg in employeeLogService.GetAll() on emp.EmployeeId equals empLg.EmployeeId
                                                where empLg.RoleId == 2
                                                select new EmployeeShortInfo
                                                {
                                                    EmployeeId = emp.EmployeeId,
                                                    EmployeeName = emp.FirstName + " " + emp.OtherName + " " + emp.LastName
                                                };
            operationDetailsEditModel.ExaminationDrops = examinationDropsService.GetAll();
        }
        // GET: OtManager/OtConfirmation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OtManager/OtConfirmation/Create
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
        public JsonResult GetAppointsByPatientId(int PatientId)
        {
            OTSuggessitionDTO oTSuggessitionDTO = new OTSuggessitionDTO();
            SearchStoreProcedureDB<AppointmentDTO> searchStoreProcedureDB = new SearchStoreProcedureDB<AppointmentDTO>();
            oTSuggessitionDTO.AppointmenList = searchStoreProcedureDB.GetAppointmentsbyPatientId(PatientId);
            oTSuggessitionDTO.Patient = patientService.GetAll().Where(x => x.PatientId == PatientId).Select(x => new EmployeeShortInfo { EmployeeId = x.PatientId, EmployeeName = x.FirstName + " " + x.MiddleName + " " + x.LastName }).FirstOrDefault();
            return Json(oTSuggessitionDTO, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSurgicalProcedureByOtCategoryId(int CategoryId)
        {
            IEnumerable<OTCharges> lstOTCharges = oTChargesService.GetAll().Where(x => x.OtCategoryId == CategoryId);
            return Json(lstOTCharges, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSumOfOtChargeByOtChargeId(int OtChargeId)
        {
            SearchStoreProcedureDB<SumOfOtCharge> searchStoreProcedureDB = new SearchStoreProcedureDB<SumOfOtCharge>();
            SumOfOtCharge Cost_Associated = searchStoreProcedureDB.GetSumOfOtChargeByOtChargeId(OtChargeId).FirstOrDefault();
            return Json(Cost_Associated, JsonRequestBehavior.AllowGet);
        }

        // GET: OtManager/OtConfirmation/Edit/5
        public ActionResult Edit(int id)
        {
            OtSuggesstionEditModel otSuggesstionEditModelView = new OtSuggesstionEditModel();
            otSuggesstionEditModelView.OperationSuggestion = operationSuggestionService.GetById(id);
            otSuggesstionEditModelView.Patient = patientService.GetAll().Where(x => x.PatientId == otSuggesstionEditModelView.OperationSuggestion.PatientId).Select(x => new EmployeeShortInfo { EmployeeId = x.PatientId, EmployeeName = x.FirstName + " " + x.MiddleName + " " + x.LastName }).FirstOrDefault();

            SearchStoreProcedureDB<AppointmentDTO> searchStoreProcedureDB = new SearchStoreProcedureDB<AppointmentDTO>();
            otSuggesstionEditModelView.Appointments = searchStoreProcedureDB.GetAppointmentsbyPatientId(otSuggesstionEditModelView.OperationSuggestion.PatientId);
            BindOtSuggesstionEditModel(otSuggesstionEditModelView);
            return View(otSuggesstionEditModelView);
        }
        public void BindOtSuggesstionEditModel(OtSuggesstionEditModel otSuggesstionEditModel)
        {
            otSuggesstionEditModel.Patients = patientService.GetAll();
            otSuggesstionEditModel.OtChargeCategories = oTChargeCategoryService.GetAll();
            otSuggesstionEditModel.OtCategoryId = oTChargesService.GetById(otSuggesstionEditModel.OperationSuggestion.OperationCategory).OtCategoryId;
            otSuggesstionEditModel.OTCharges = oTChargesService.GetAll().Where(x => x.OtCategoryId == otSuggesstionEditModel.OtCategoryId);
            otSuggesstionEditModel.Employees = from emp in employeeService.GetAll()
                                               join empLg in employeeLogService.GetAll() on emp.EmployeeId equals empLg.EmployeeId
                                               where empLg.RoleId == 2
                                               select new EmployeeShortInfo
                                               {
                                                   EmployeeId = emp.EmployeeId,
                                                   EmployeeName = emp.FirstName + " " + emp.OtherName + " " + emp.LastName
                                               };
        }
        // POST: OtManager/OtConfirmation/Edit/5
        [HttpPost]
        public ActionResult Edit(OtSuggesstionEditModel otSuggesstionEditModel)
        {

            try
            {
                // TODO: Add update logic here
                operationSuggestionService.Update(otSuggesstionEditModel.OperationSuggestion);
                return RedirectToAction("Index");
            }
            catch
            {
                OtSuggesstionEditModel otSuggesstionEditModelView = new OtSuggesstionEditModel();
                otSuggesstionEditModelView.OperationSuggestion = operationSuggestionService.GetById(otSuggesstionEditModel.OperationSuggestion.Id);
                otSuggesstionEditModelView.Patient = patientService.GetAll().Where(x => x.PatientId == otSuggesstionEditModelView.OperationSuggestion.PatientId).Select(x => new EmployeeShortInfo { EmployeeId = x.PatientId, EmployeeName = x.FirstName + " " + x.MiddleName + " " + x.LastName }).FirstOrDefault();

                SearchStoreProcedureDB<AppointmentDTO> searchStoreProcedureDB = new SearchStoreProcedureDB<AppointmentDTO>();
                otSuggesstionEditModelView.Appointments = searchStoreProcedureDB.GetAppointmentsbyPatientId(otSuggesstionEditModelView.OperationSuggestion.PatientId);
                BindOtSuggesstionEditModel(otSuggesstionEditModelView);
                return View(otSuggesstionEditModelView);
            }
        }

        // GET: OtManager/OtConfirmation/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                OperationSuggestion operationSuggestion = operationSuggestionService.GetById(id);
                operationSuggestion.IsDeleted = true;
                operationSuggestionService.Update(operationSuggestion);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult Cancel(int id)
        {
            OperationSuggestion operationSuggestion = operationSuggestionService.GetById(id);
            operationSuggestion.IsCancelled = true;
            operationSuggestionService.Update(operationSuggestion);
            return RedirectToAction("Index");
        }
        // POST: OtManager/OtConfirmation/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id)
        //{

        //}
        public ActionResult GeneratePreOperativeAdvice()
        {
            List<OtConfirmationViewModel> lstOtConfirmationViewModel = (from op in operarionDetailsService.GetAll()
                                                                        join otcs in oTChargesService.GetAll() on op.SurgicalProcedure equals otcs.OtChargeId
                                                                        join ops in operationSuggestionService.GetAll() on op.OperationSuggestionId equals ops.Id
                                                                        join emp in employeeService.GetAll() on ops.RefferedBy equals emp.EmployeeId
                                                                        join empDoc in employeeService.GetAll() on op.DoctorId equals empDoc.EmployeeId
                                                                        join ps in patientService.GetAll() on op.PatientId equals ps.PatientId
                                                                        join otCat in oTChargeCategoryService.GetAll() on otcs.OtCategoryId equals otCat.Id
                                                                        where ops.IsCancelled == false && ops.IsDeleted == false && ops.IsConvertedToOT == true && op.IsOperated == false
                                                                        select new OtConfirmationViewModel
                                                                        {
                                                                            ReffredbyDoctorsName = emp.FirstName + " " + emp.OtherName + " " + emp.LastName,
                                                                            Eye = ops.Eye,
                                                                            OperationSuggessitionId = op.OperationId,
                                                                            Operation = otCat.OtChargeCategory,
                                                                            SurgicalProcedure = otcs.Name,
                                                                            OperationTime = op.OperationDate,
                                                                            PatientName = ps.FirstName + " " + ps.MiddleName + " " + ps.LastName,
                                                                            SuggestedDoctor = empDoc.FirstName + " " + empDoc.OtherName + " " + empDoc.LastName,

                                                                        }).ToList();
            return View(lstOtConfirmationViewModel);
        }

        public ActionResult GeneratePreOperationAdvice(int id)
        {
            Session["OperationSuggesstionId"] = operarionDetailsService.GetById(id).OperationSuggestionId;
            Session["OperationId"] = id;
            return Redirect("~/CommonPages/Pre_Operative_Advice.aspx");
        }
        public ActionResult GenerateSurgeryAdvicePrint(int id)
        {
            Session["OperationSuggesstionId"] = operarionDetailsService.GetById(id).OperationSuggestionId;
            Session["OperationId"] = id;
            //HttpContext.Response.AddHeader.Write(@"<script type='text/javascript' language='javascript'>window.open('page.html','_blank').focus();</script>");
            return Redirect("~/CommonPages/Surgery_Advice.aspx");
            //return RedirectToAction("GenerateSurgeryAdvice");
        }
        public ActionResult GenerateSurgeryAdvice()
        {
            List<OtConfirmationViewModel> lstOtConfirmationViewModel = (from op in operarionDetailsService.GetAll()
                                                                        join otcs in oTChargesService.GetAll() on op.SurgicalProcedure equals otcs.OtChargeId
                                                                        join ops in operationSuggestionService.GetAll() on op.OperationSuggestionId equals ops.Id
                                                                        join emp in employeeService.GetAll() on ops.RefferedBy equals emp.EmployeeId
                                                                        join empDoc in employeeService.GetAll() on op.DoctorId equals empDoc.EmployeeId
                                                                        join ps in patientService.GetAll() on op.PatientId equals ps.PatientId
                                                                        join otCat in oTChargeCategoryService.GetAll() on otcs.OtCategoryId equals otCat.Id
                                                                        where ops.IsCancelled == false && ops.IsDeleted == false && ops.IsConvertedToOT == true && op.IsOperated == false
                                                                        select new OtConfirmationViewModel
                                                                        {
                                                                            ReffredbyDoctorsName = emp.FirstName + " " + emp.OtherName + " " + emp.LastName,
                                                                            Eye = ops.Eye,
                                                                            OperationSuggessitionId = op.OperationId,
                                                                            Operation = otCat.OtChargeCategory,
                                                                            SurgicalProcedure = otcs.Name,
                                                                            OperationTime = op.OperationDate,
                                                                            PatientName = ps.FirstName + " " + ps.MiddleName + " " + ps.LastName,
                                                                            SuggestedDoctor = empDoc.FirstName + " " + empDoc.OtherName + " " + empDoc.LastName,

                                                                        }).ToList();
            return View(lstOtConfirmationViewModel);
        }
    }
    public class SumOfOtCharge
    {
        public decimal Cost_Associated { get; set; }
    }
}
