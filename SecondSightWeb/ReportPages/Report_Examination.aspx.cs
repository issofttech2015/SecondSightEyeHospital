using SecondSightSouthendEyeCentre.Models;
using SecondSightSouthendEyeCentre.Service.Implementation;
using SecondSightSouthendEyeCentre.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecondSightWeb.ReportPages
{
    public partial class Report_Examination : System.Web.UI.Page
    {
        IConsultantExaminationCombineService consultantExaminationCombineService = new ConsultantExaminationCombineService();
        IConsultantExamination1Service consultantExamination1Service = new ConsultantExamination1Service();
        IConsultantExamination2Service consultantExamination2Service = new ConsultantExamination2Service();
        IConsultantExamination3Service consultantExamination3Service = new ConsultantExamination3Service();
        IPatientService patientService = new PatientService();
        IEmployeeService employeeService = new EmployeeService();
        ISequenceService sequenceService = new SequenceService();

        ConsultantExamination1 consultantExamination1 = new ConsultantExamination1();
        ConsultantExamination2 consultantExamination2 = new ConsultantExamination2();
        ConsultantExamination3 consultantExamination3 = new ConsultantExamination3();
        ConsultantExaminationCombine examinationCombine = new ConsultantExaminationCombine();
        Patient patient = new Patient();
        Employee employee = new Employee();
        Sequence sequence = new Sequence();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                examinationCombine = consultantExaminationCombineService.GetById(int.Parse(Session["CombineId"].ToString()));
                consultantExamination1 = consultantExamination1Service.GetById(examinationCombine.ConsultantExaminationId1);
                consultantExamination2 = consultantExamination2Service.GetById(examinationCombine.ConsultantExaminationId2);
                consultantExamination3 = consultantExamination3Service.GetById(examinationCombine.ConsultantExaminationId3);
                patient = patientService.GetById(examinationCombine.PatientId);
                employee = employeeService.GetById(examinationCombine.ConsultantId);

                LoadHeaderInformation(patient, employee, examinationCombine.Date);
                if (consultantExamination1 != null)
                    LoadExamination1(consultantExamination1);
                if (consultantExamination2 != null)
                    LoadExamination2(consultantExamination2);
                if (consultantExamination3 != null)
                    LoadExamination3(consultantExamination3);
            }
        }

        private void LoadHeaderInformation(Patient patient, Employee employee, DateTime date)
        {
            lbl_PatCode.Text = patient.PatCode;
            lbl_PatientName.Text = patient.FirstName + " " + patient.MiddleName + " " + patient.LastName;
            lbl_Gender.Text = patient.Gender;
            lbl_Age.Text = patient.Age.ToString();
            lbl_Examiner_Name.Text = employee.FirstName + " " + employee.OtherName + " " + employee.LastName;
            lbl_Bill_No.Text = sequenceService.GetById(2).Prefix + "/" + Session["CombineId"].ToString() + "/" + Common_Controle.Common_Methods.GetCurrentFinancialYear();
            lbl_Date.Text = date.Date.ToString();
        }
        private void LoadExamination1(ConsultantExamination1 consultantExamination)
        {
            lbl_SPH_RE.Text = consultantExamination.ARSPHRE;
            lbl_SPH_LE.Text = consultantExamination.ARSPHLE;
            lbl_CYL_RE.Text = consultantExamination.ARCYLRE;
            lbl_CYL_LE.Text = consultantExamination.ARCYLLE;
            lbl_AXIS_RE.Text = consultantExamination.ARAXISRE;
            lbl_AXIS_LE.Text = consultantExamination.ARAXISLE;
            lbl_NCT_OD.Text = consultantExamination.NCTOD;
            lbl_NCT_OS.Text = consultantExamination.NCTOS;

        }
        private void LoadExamination2(ConsultantExamination2 consultantExamination)
        {
            lbl_CC.Text = consultantExamination.CheifComplain;
            lbl_CC_Duration.Text = consultantExamination.CheifComplainDuration;
            lbl_SD.Text = consultantExamination.SystematicDisease;
            lbl_SD_Duration.Text = consultantExamination.SystematicDiseaseDuration;
            lbl_A.Text = consultantExamination.Alegry;
            lbl_A_Duration.Text = consultantExamination.AlegryDuration;
            lbl_PH.Text = consultantExamination.PastHistory;
            lbl_FH.Text = consultantExamination.FamilyHistory;
            lbl_CT.Text = consultantExamination.CurrentTreatment;
            lbl_CI.Text = consultantExamination.CurrentInvestigation;

            //VA
            lbl_OD_Aided.Text = consultantExamination.VAODAided;
            lbl_OD_Aided_Remarks.Text = consultantExamination.VAAidedODRemarks;
            lbl_OD_Unaided.Text = consultantExamination.VAODUnaided;
            lbl_OD_Unaided_Remarks.Text = consultantExamination.VAUnaidedODRemarks;
            lbl_OD_Withph.Text = consultantExamination.VAODWithph;
            lbl_OD_Withph_Remarks.Text = consultantExamination.VAwithPhODRemarks;

            lbl_OS_Aided.Text = consultantExamination.VAOSAided;
            lbl_OS_Aided_Remarks.Text = consultantExamination.VAAidedOSRemarks;
            lbl_OS_Unaided.Text = consultantExamination.VAOSUnaided;
            lbl_OS_Unaided_Remarks.Text = consultantExamination.VAUnaidedOSRemarks;
            lbl_OS_Withph.Text = consultantExamination.VAOSWithph;
            lbl_OS_Withph_Remarks.Text = consultantExamination.VAwithPhOSRemarks;
        }
        private void LoadExamination3(ConsultantExamination3 consultantExamination)
        {
            lbl_Distance_SPH_RE.Text = consultantExamination.PGPRIGHTEYEDISTANCESPH;
            lbl_Distance_CYL_RE.Text = consultantExamination.PGPRIGHTEYEDISTANCECYL;
            lbl_Distance_AXIS_RE.Text = consultantExamination.PGPRIGHTEYEDISTANCEAXIS;
            lbl_Distance_VA_RE.Text = consultantExamination.PGPRIGHTEYEDISTANCEVA;

            lbl_Distance_SPH_LE.Text = consultantExamination.PGPLEFTEYEDISTANCESPH;
            lbl_Distance_CYL_LE.Text = consultantExamination.PGPLEFTEYEDISTANCECYL;
            lbl_Distance_AXIS_LE.Text = consultantExamination.PGPLEFTEYEDISTANCEAXIS;
            lbl_Distance_VA_LE.Text = consultantExamination.PGPLEFTEYEDISTANCEVA;

            lbl_Distance_SPH_RE_A.Text = consultantExamination.RIGHTEYEDISTANCESPH;
            lbl_Distance_CYL_RE_A.Text = consultantExamination.RIGHTEYEDISTANCECYL;
            lbl_Distance_AXIS_RE_A.Text = consultantExamination.RIGHTEYEDISTANCEAXIS;
            lbl_Distance_VA_RE_A.Text = consultantExamination.RIGHTEYEDISTANCEVA;

            lbl_Distance_SPH_LE_A.Text = consultantExamination.LEFTEYEDISTANCESPH;
            lbl_Distance_CYL_A.Text = consultantExamination.LEFTEYEDISTANCECYL;
            lbl_Distance_AXIS_A.Text = consultantExamination.LEFTEYEDISTANCEAXIS;
            lbl_Distance_VA_A.Text = consultantExamination.LEFTEYEDISTANCEVA;

            lbl_Near_SPH_RE.Text = consultantExamination.PGPRIGHTEYENEARSPH;
            lbl_Near_CYL_RE.Text = consultantExamination.PGPRIGHTEYENEARCYL;
            lbl_Near_AXIS_RE.Text = consultantExamination.PGPRIGHTEYENEARAXIS;
            lbl_Near_VA_RE.Text = consultantExamination.PGPRIGHTEYENEARVA;

            lbl_Near_SPH_LE.Text = consultantExamination.PGPLEFTEYENEARSPH;
            lbl_Near_CYL_LE.Text = consultantExamination.PGPLEFTEYENEARCYL;
            lbl_Near_AXIS_LE.Text = consultantExamination.PGPLEFTEYENEARAXIS;
            lbl_Near_VA_LE.Text = consultantExamination.PGPLEFTEYENEARVA;

            lbl_Near_SPH_RE_A.Text = consultantExamination.RIGHTEYENEARSPH;
            lbl_Near_CYL_RE_A.Text = consultantExamination.RIGHTEYENEARCYL;
            lbl_Near_AXIS_RE_A.Text = consultantExamination.RIGHTEYENEARAXIS;
            lbl_Near_VA_RE_A.Text = consultantExamination.RIGHTEYENEARVA;

            lbl_Near_SPH_LE_A.Text = consultantExamination.LEFTEYENEARSPH;
            lbl_Near_CYL_LE_A.Text = consultantExamination.LEFTEYENEARCYL;
            lbl_Near_AXIS_LE_A.Text = consultantExamination.LEFTEYENEARAXIS;
            lbl_Near_VA_LE_A.Text = consultantExamination.LEFTEYENEARVA;

            lbl_CV_OD.Text = consultantExamination.COLORVISIONOD;
            lbl_PUPIL_OD.Text = consultantExamination.PupilOD;
            lbl_RAPD_OD.Text = consultantExamination.RappOD;
            lbl_AG_OD.Text = consultantExamination.AmslergridOD;
            lbl_SR_OD.Text = consultantExamination.SyringOD;

            lbl_CV_OS.Text = consultantExamination.COLORVISIONOS;
            lbl_PUPIL_OS.Text = consultantExamination.PupilOS;
            lbl_RAPD_OS.Text = consultantExamination.RappOS;
            lbl_AG_OS.Text = consultantExamination.AmslergridOS;
            lbl_SR_OS.Text = consultantExamination.SyringOS;

        }

        [WebMethod]
        public static string[] GetODOSVMHMAngle()
        {
            List<string> list = new List<string>();
            ConsultantExamination3 consultantExamination = new ConsultantExamination3();
            ConsultantExaminationCombine consultantExaminationCombine = new ConsultantExaminationCombine();
            IConsultantExaminationCombineService consultantExaminationCombineService = new ConsultantExaminationCombineService();
            IConsultantExamination3Service consultantExamination3Service = new ConsultantExamination3Service();
            consultantExaminationCombine = consultantExaminationCombineService.GetById(int.Parse(HttpContext.Current.Session["CombineId"].ToString()));

            consultantExamination = consultantExamination3Service.GetById(consultantExaminationCombine.ConsultantExaminationId3);
            if (consultantExamination != null)
            {
                list.Add(consultantExamination.RatinoscopyHMODDegree);
                list.Add(consultantExamination.RatinoscopyHMOSDegree);
                list.Add(consultantExamination.RatinoscopyVMODDegree);
                list.Add(consultantExamination.RatinoscopyVMOSDegree);

                list.Add(consultantExamination.RatinoscopyHMODValue);
                list.Add(consultantExamination.RatinoscopyHMOSValue);
                list.Add(consultantExamination.RatinoscopyVMODValue);
                list.Add(consultantExamination.RatinoscopyVMOSValue);
            }
            return list.ToArray();
        }
    }
}