using SecondSightSouthendEyeCentre.Models;
using SecondSightSouthendEyeCentre.Service.Implementation;
using SecondSightSouthendEyeCentre.Service.Interfaces;
using SecondSightWeb.Areas.Admin.Models.DTO;
using SecondSightWeb.Areas.Admin.Models.ViewModels;
using SecondSightWeb.Areas.OtManager.Models.ViewModels;
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
    public class PatientDirectoryController : Controller
    {
        #region Initialization
        IPatientService patientService = new PatientService();


        IOperationSuggestionService operationSuggestionService = new OperationSuggestionService();
        IOTChargeCategoryService oTChargeCategoryService = new OTChargeCategoryService();

        IEmployeeService employeeService = new EmployeeService();
        IOTChargesService oTChargesService = new OTChargesService();
        IEmployeeLogService employeeLogService = new EmployeeLogService();
        IOtCheckListService otCheckListService = new OtCheckListService();
        IExaminationDropsService examinationDropsService = new ExaminationDropsService();
        IOperarionDetailsService operarionDetailsService = new OperarionDetailsService();
        IBillService billService = new BillService();
        IBillSummeryService billSummeryService = new BillSummeryService();


        IAppointmentService appointmentService = new AppointmentService();
        ISequenceService sequenceService = new SequenceService();

        IConsultantExaminationCombineService consultantExaminationCombineService = new ConsultantExaminationCombineService();
        ITreatementService treatementService = new TreatementService();
        IDischargeDetailsService dischargeDetailsService = new DischargeDetailsService();


        #endregion
        // GET: Admin/PatientDirectory
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PatientDirectory()
        {
            List<Patient> patinet = patientService.GetAll().ToList();
            return View(patinet);
        }
        public ActionResult GetPatientDetailsById(int id)
        {
            IAppointmentService appointmentService = new AppointmentService();
            ITreatementService treatementService = new TreatementService();
            IConsultantExaminationCombineService consultantExaminationCombineService = new ConsultantExaminationCombineService();
            IBillService billService = new BillService();
            IPatientService patientService = new PatientService();


            IDischargeDetailsService dischargeDetailsService = new DischargeDetailsService();
            IOperarionDetailsService operarionDetailsService = new OperarionDetailsService();
            IOperationSuggestionService operationSuggestionService = new OperationSuggestionService();


            var disChargeCertificateCount = from disChargeDet in dischargeDetailsService.GetAll()
                                            join oprdet in operarionDetailsService.GetAll() on disChargeDet.OperationId equals oprdet.OperationId
                                            where oprdet.PatientId == id
                                            select disChargeDet.DischargeDetailsId;
            //var totalSurgeryAdvice=from surgAd in operationSuggestionService.GetAll()
            //ISurgicalConsumptionListService
            //IDischarargeCertificateService
            PatientDirectoryDetialsDTO patientDirectoryDetialsDTO = new PatientDirectoryDetialsDTO()
            {
                TotalAppointments = appointmentService.GetAll().Where(x => x.PatCode == patientService.GetById(id).PatCode).Count(),
                TotalDischargeCertificate = disChargeCertificateCount.Count(),
                TotalCollection = billService.GetAll().Where(x => x.PatientId == id).Sum(x => x.BillAmount),
                TotalExamination = consultantExaminationCombineService.GetAll().Where(x => x.PatientId == id).Count(),
                TotalPreoperativeAdvice = operationSuggestionService.GetAll().Where(x => x.PatientId == id && x.IsCancelled == false && x.IsDeleted == false && x.IsConvertedToOT == true).Count(),
                TotalSurgeryAdvice = operationSuggestionService.GetAll().Where(x => x.PatientId == id).Count(),
                TotalPrescriptions = treatementService.GetAll().Where(x => x.PatientId == id).Count(),
                TotalSurgicalConsumptionList = operarionDetailsService.GetAll().Where(x => x.PatientId == id).Count(),
                PatientId = id
            };

            return View(patientDirectoryDetialsDTO);
        }
        [HttpGet]
        public JsonResult GetPatientDeatils()
        {
            List<Patient> patinet = patientService.GetAll().ToList();

            return Json(patinet, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GeneratePreOperativeAdvice(int id)
        {
            List<OtConfirmationViewModel> lstOtConfirmationViewModel = (from op in operarionDetailsService.GetAll()
                                                                        join otcs in oTChargesService.GetAll() on op.SurgicalProcedure equals otcs.OtChargeId
                                                                        join ops in operationSuggestionService.GetAll() on op.OperationSuggestionId equals ops.Id
                                                                        join emp in employeeService.GetAll() on ops.RefferedBy equals emp.EmployeeId
                                                                        join empDoc in employeeService.GetAll() on op.DoctorId equals empDoc.EmployeeId
                                                                        join ps in patientService.GetAll() on op.PatientId equals ps.PatientId
                                                                        join otCat in oTChargeCategoryService.GetAll() on otcs.OtCategoryId equals otCat.Id
                                                                        where ops.IsCancelled == false && ops.IsDeleted == false && ops.IsConvertedToOT == true && op.IsOperated == false && op.PatientId == id
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
        [HttpPost]
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
        public ActionResult GenerateSurgeryAdvice(int id)
        {
            List<OtConfirmationViewModel> lstOtConfirmationViewModel = (from op in operarionDetailsService.GetAll()
                                                                        join otcs in oTChargesService.GetAll() on op.SurgicalProcedure equals otcs.OtChargeId
                                                                        join ops in operationSuggestionService.GetAll() on op.OperationSuggestionId equals ops.Id
                                                                        join emp in employeeService.GetAll() on ops.RefferedBy equals emp.EmployeeId
                                                                        join empDoc in employeeService.GetAll() on op.DoctorId equals empDoc.EmployeeId
                                                                        join ps in patientService.GetAll() on op.PatientId equals ps.PatientId
                                                                        join otCat in oTChargeCategoryService.GetAll() on otcs.OtCategoryId equals otCat.Id
                                                                        where ops.IsCancelled == false && ops.IsDeleted == false && ops.IsConvertedToOT == true && op.IsOperated == false && op.PatientId == id
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
        public ActionResult TotalAppointments(int id)
        {
            List<TotalAppointmentsViewModel> lstTotalAppointmentsViewModel = new List<TotalAppointmentsViewModel>();
            lstTotalAppointmentsViewModel = (from aps in appointmentService.GetAll()
                                             join ps in patientService.GetAll() on aps.PatCode equals ps.PatCode
                                             join emp in employeeService.GetAll() on aps.DoctorsId equals emp.EmployeeId
                                             where ps.PatientId == id
                                             select new TotalAppointmentsViewModel
                                             {
                                                 AppointmentId = sequenceService.GetById(5).Prefix + "/" + aps.AppointmentId + "/" + Common_Controle.Common_Methods.GetCurrentFinancialYear(),
                                                 AppointmentTime = aps.Time,
                                                 DoctorName = emp.FirstName + " " + emp.OtherName + " " + emp.LastName,
                                                 PatCode = ps.PatCode,
                                                 PatientName = ps.FirstName + " " + ps.MiddleName + " " + ps.LastName,
                                                 PatientId = ps.PatientId,
                                                 Status = aps.IsConfirmed,

                                             }).ToList();
            return View(lstTotalAppointmentsViewModel);
        }
        public ActionResult TotalPrescription(int id)
        {
            List<TotalPrescriptionViewModel> lstTotalPrescriptionViewModel = new List<TotalPrescriptionViewModel>();
            lstTotalPrescriptionViewModel = (from tm in treatementService.GetAll()
                                             join ps in patientService.GetAll() on tm.PatientId equals ps.PatientId
                                             join emp in employeeService.GetAll() on tm.DoctorId equals emp.EmployeeId
                                             where ps.PatientId == id
                                             select new TotalPrescriptionViewModel
                                             {
                                                 AppointmentId = sequenceService.GetById(2).Prefix + "/" + tm.TreatmentId + "/" + Common_Controle.Common_Methods.GetCurrentFinancialYear(),
                                                 AppointmentTime = tm.TreatmentDate,
                                                 DoctorName = emp.FirstName + " " + emp.OtherName + " " + emp.LastName,
                                                 PatCode = ps.PatCode,
                                                 PatientName = ps.FirstName + " " + ps.MiddleName + " " + ps.LastName,
                                                 PatientId = ps.PatientId,
                                                 Id = tm.TreatmentId
                                             }).ToList();
            return View(lstTotalPrescriptionViewModel);
        }
        public ActionResult TotalExaminations(int id)
        {
            List<TotalExaminationsViewModel> lstTotalExaminationsViewModel = new List<TotalExaminationsViewModel>();
            lstTotalExaminationsViewModel = (from exm in consultantExaminationCombineService.GetAll()
                                             join ps in patientService.GetAll() on exm.PatientId equals ps.PatientId
                                             join emp in employeeService.GetAll() on exm.ConsultantId equals emp.EmployeeId
                                             where ps.PatientId == id
                                             select new TotalExaminationsViewModel
                                             {
                                                 AppointmentId = sequenceService.GetById(2).Prefix + "/" + exm.ConsultantExaminationCombineId + "/" + Common_Controle.Common_Methods.GetCurrentFinancialYear(),
                                                 AppointmentTime = exm.Date,
                                                 ExaminerName = emp.FirstName + " " + emp.OtherName + " " + emp.LastName,
                                                 PatCode = ps.PatCode,
                                                 PatientName = ps.FirstName + " " + ps.MiddleName + " " + ps.LastName,
                                                 PatientId = ps.PatientId,
                                                 Status = true,
                                                 Id = exm.ConsultantExaminationCombineId
                                             }).ToList();
            return View(lstTotalExaminationsViewModel);
        }
        public ActionResult TotalDischargeCertificate(int id)
        {
            List<TotalDischargeCertificateViewModel> lstTotalDischargeCertificateViewModel = new List<TotalDischargeCertificateViewModel>();
            lstTotalDischargeCertificateViewModel = (from dsc in dischargeDetailsService.GetAll()
                                                     join ops in operarionDetailsService.GetAll() on dsc.OperationId equals ops.OperationId
                                                     join ps in patientService.GetAll() on ops.PatientId equals ps.PatientId
                                                     join emp in employeeService.GetAll() on ops.DoctorId equals emp.EmployeeId
                                                     where ps.PatientId == id
                                                     select new TotalDischargeCertificateViewModel
                                                     {
                                                         AppointmentId = sequenceService.GetById(2).Prefix + "/" + dsc.DischargeDetailsId + "/" + Common_Controle.Common_Methods.GetCurrentFinancialYear(),
                                                         AppointmentTime = dsc.DischargeDate,
                                                         DoctorName = emp.FirstName + " " + emp.OtherName + " " + emp.LastName,
                                                         PatCode = ps.PatCode,
                                                         PatientName = ps.FirstName + " " + ps.MiddleName + " " + ps.LastName,
                                                         PatientId = ps.PatientId,
                                                         Id = dsc.DischargeDetailsId
                                                     }).ToList();
            return View(lstTotalDischargeCertificateViewModel);
        }
        public ActionResult TotalSurgicalConsumptionList()
        {
            return View();
        }
        public ActionResult TotalBillDetails(int id)
        {
            List<TotalBillDetailsViewModel> lstTotalBillDetailsViewModel = new List<TotalBillDetailsViewModel>();
            lstTotalBillDetailsViewModel = (from bs in billService.GetAll()
                                            join ps in patientService.GetAll() on bs.PatientId equals ps.PatientId
                                            join emp in employeeService.GetAll() on bs.BillBy equals emp.EmployeeId
                                            where bs.PatientId == id
                                            select new TotalBillDetailsViewModel
                                            {
                                                BillId = sequenceService.GetById(4).Prefix + "/" + bs.BillId + "/" + Common_Controle.Common_Methods.GetCurrentFinancialYear(),
                                                BillDate = bs.Date,
                                                BillBy = emp.FirstName + " " + emp.OtherName + " " + emp.LastName,
                                                PatCode = ps.PatCode,
                                                PatientName = ps.FirstName + " " + ps.MiddleName + " " + ps.LastName,
                                                Id = bs.BillId,
                                                BillAmount = bs.BillAmount,
                                                Concession = bs.Concession,
                                                PaidAmount = bs.PaymentDetails.Sum(x => x.PaymentAmount),
                                                Due = bs.BillAmount - (bs.PaymentDetails.Sum(x => x.PaymentAmount) + bs.Concession)
                                            }).ToList();
            return View(lstTotalBillDetailsViewModel);
        }
        public ActionResult GenerateBill(int id)
        {
            Session["Bill_Id"] = id;
            return Redirect("~/ReceptionPages/Bill_Money_Recipt.aspx");
        }
        public ActionResult GenerateDiscahrgeCertificate(int id)
        {
            Session["Operation_Id"] = id;
            switch (dischargeDetailsService.GetById(id).DischargeCertificateType)
            {
                case 1:
                    return Redirect("~/CommonPages/Discharge_Certificate.aspx ");
                case 2:
                    return Redirect("~/CommonPages/Discharge_Certificate_Night_Care.aspx");

            }
            return View();
        }
        public ActionResult GenerateExamination(int id)
        {
            Session["CombineId"] = id;
            return Redirect("~/ReportPages/Report_Examination.aspx");
        }
        public ActionResult GeneratePrescription(int id)
        {
            Session["TreatmentId"] = id;
            return Redirect("~/DoctorPages/Prescription.aspx");
        }
    }
}