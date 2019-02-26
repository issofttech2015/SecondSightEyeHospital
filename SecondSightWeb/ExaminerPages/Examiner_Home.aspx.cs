using SecondSightSouthendEyeCentre.Models;
using SecondSightSouthendEyeCentre.Service.Implementation;
using SecondSightSouthendEyeCentre.Service.Interfaces;
using SecondSightWeb.Models;
using SecondSightWeb.Service.Implementation;
using SecondSightWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecondSightWeb.ExaminerPages
{
    public partial class Examiner_Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddl_Patient_Id.DataBind();
                //ddl_Allergy.DataBind();
                //ddl_Systematic_Diseases.DataBind();
                //ddl_Chife_Complain.DataBind();

                // CheifComplainByExaminer
                DataTable dtCheifComplainByExaminer = new DataTable();
                dtCheifComplainByExaminer.Columns.AddRange(new DataColumn[5] { new DataColumn("SlNo", typeof(int)), new DataColumn("CheifComplainID", typeof(int)), new DataColumn("CheifComplain", typeof(string)), new DataColumn("Duration", typeof(string)), new DataColumn("Eye", typeof(string)) });
                ViewState["CheifComplainByExaminer"] = dtCheifComplainByExaminer;
                gv_CheifComplainByExaminer.DataSource = (DataTable)ViewState["CheifComplainByExaminer"];
                gv_CheifComplainByExaminer.DataBind();
                GetPatientDetails();
            }
        }
        IConsultantExamination1Service consultantExamination1Service = new ConsultantExamination1Service();
        IConsultantExamination2Service consultantExamination2Service = new ConsultantExamination2Service();
        IConsultantExamination3Service consultantExamination3Service = new ConsultantExamination3Service();

        ICheifComplainByExaminationService cheifComplainByExaminationService = new CheifComplainByExaminationService();
        protected void Page_PreInit(Object sender, EventArgs e)
        {
            SecondSightWeb.Common_Controle.Common_Methods.ChangeMasterPage(Page);
        }
        private void GetPatientDetails()
        {
            SecondSightSouthendEyeCentre.Models.Patient patient = patientService.GetById(int.Parse(ddl_Patient_Id.SelectedValue.ToString()));
            if (patient != null)
            {
                lbl_PatName.Text = patient.FirstName + " " + patient.MiddleName + " " + patient.LastName;
                lbl_Age.Text = patient.Age.ToString();
                lbl_Gender.Text = patient.Gender;
            }
        }

        IPatientService patientService = new PatientService();
        protected void btn_Serach_Click(object sender, EventArgs e)
        {
            //Search
            var patientObj = SecondSightSouthendEyeCentre.SELECTDAL.Instance.GetPatientDetails(txt_PatCode.Text, txt_MobileNumber_Search.Text);
            try
            {
                ddl_Patient_Id.SelectedValue = patientObj.Item6;
                lbl_PatName.Text = patientObj.Item1;
                lbl_Age.Text = patientObj.Item7;
                lbl_Gender.Text = patientObj.Rest.Item1;
            }
            catch
            {
                ShowMessage("You can not add because patient does not have any apoointmets", MessageType.Warning);
            }
        }
        public enum MessageType { Success, Error, Info, Warning };

        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }

        protected void ddl_Patient_Id_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetPatientDetails();
            Common_Controle.Common_Methods.ClearTextBoxes(Page);
            Common_Controle.Common_Methods.ClearListBox(Page);
            if (ddl_Patient_Id.SelectedIndex > 1)
            {
                ddl_Appointment.DataSourceID = "ds_AppointmentId";
                ddl_Appointment.DataBind();
            }
            ConsultantExamination2 consultantExamination2 = consultantExamination2Service.GetByPatientId(int.Parse(ddl_Patient_Id.SelectedValue.ToString()));
            if (consultantExamination2 != null)
            {
                txt_Family_History.Text = consultantExamination2.FamilyHistory;
                txt_Past_History.Text = consultantExamination2.PastHistory;
                txt_Current_Treatment.Text = consultantExamination2.CurrentTreatment;
                txt_Current_Investigation.Text = consultantExamination2.CurrentTreatment;
            }
        }

        protected void ddl_Chife_Complain_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddl_Allergy_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddl_Systematic_Diseases_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        IConsultantExaminationCombineService consultantExaminationCombineService = new ConsultantExaminationCombineService();

        protected void btn_Consultant1_Save_Click(object sender, EventArgs e)
        {
            if (checkISPatient(1))
            {
                return;
            }
            if (ddl_Appointment.SelectedIndex < 1)
            {
                ShowMessage("Please select Appointment Id", MessageType.Warning);
                return;
            }
            try
            {
                ConsultantExamination1 consultantExamination1 = new ConsultantExamination1()
                {
                    ConsultantId = int.Parse(Session["EmployeeId"].ToString()),
                    ARSPHLE = txt_SPH_LE.Text,
                    ARSPHRE = txt_SPH_RE.Text,
                    ARCYLLE = txt_CYL_LE.Text,
                    ARCYLRE = txt_CYL_RE.Text,
                    ARAXISLE = txt_AXIS_LE.Text,
                    ARAXISRE = txt_AXIS_RE.Text,
                    NCTOD = txt_OD.Text,
                    NCTOS = txt_OS.Text,
                    PatientId = int.Parse(ddl_Patient_Id.SelectedValue),
                    ExaminationDate = System.DateTime.Now
                };
                consultantExamination1 = consultantExamination1Service.Add(consultantExamination1);
                ConsultantExaminationCombine consultantExaminationCombine = new ConsultantExaminationCombine()
                {
                    ConsultantExaminationId1 = consultantExamination1.ConsultantExaminationId,
                    PatientId = int.Parse(ddl_Patient_Id.SelectedValue),
                    ConsultantId = int.Parse(Session["EmployeeId"].ToString()),
                    AppointmentId = int.Parse(ddl_Appointment.SelectedValue.ToString())
                };
                consultantExaminationCombine = consultantExaminationCombineService.Add(consultantExaminationCombine);
                if (consultantExamination1.ConsultantExaminationId != 0 && consultantExaminationCombine.ConsultantExaminationCombineId != 0)
                {
                    ShowMessage("Record Added!!!", MessageType.Success);
                    Response.AddHeader("REFRESH", "1;URL=Examiner_Home.aspx");
                }
            }
            catch
            {
                ShowMessage(" Something went wrong!!!", MessageType.Error);
            }

        }

        protected void btn_save_examination2_Click(object sender, EventArgs e)
        {
            if (checkISPatient(2))
                return;
            if (ddl_Appointment.SelectedIndex < 1)
            {
                ShowMessage("Please select Appointment Id", MessageType.Warning);
                return;
            }
            string cheifCompalin = "", alergy = "", systematicDisease = "";
            //foreach (ListItem list in lb_Chife_Complain.Items)
            //{
            //    if (list.Selected)
            //    {
            //        cheifCompalin += list.Text + ",";
            //    }
            //}
            foreach (ListItem item in lb_Allergy.Items)
            {
                if (item.Selected)
                {
                    alergy += item.Text + ",";
                }
            }
            foreach (ListItem item in lb_Systematic_Diseases.Items)
            {
                if (item.Selected)
                {
                    systematicDisease += item.Text + ",";
                }
            }
            try
            {
                 SecondSightSouthendEyeCentre.Models.ConsultantExamination2 consultantExamination2 = new ConsultantExamination2()
                {
                    ConsultantId = int.Parse(Session["EmployeeId"].ToString()),
                    Alegry = alergy.TrimEnd(','),
                    CheifComplain = cheifCompalin.TrimEnd(','),
                    SystematicDisease = cheifCompalin.TrimEnd(','),
                    AlegryDuration = txt_Duration_A.Text,
                    CheifComplainDuration = "",
                    SystematicDiseaseDuration = txt_Duration_SD.Text,
                    CurrentInvestigation = txt_Current_Investigation.Text,
                    CurrentTreatment = txt_Current_Treatment.Text,
                    ExaminationDate = System.DateTime.Now,
                    FamilyHistory = txt_Family_History.Text,
                    PastHistory = txt_Past_History.Text,
                    PatientId = int.Parse(ddl_Patient_Id.SelectedValue),
                    VAAidedODRemarks = txt_aided_od.Text,
                    VAAidedOSRemarks = txt_aided_os.Text,
                    VAODAided = ddl_Aided_OD.SelectedValue.ToString(),
                    VAODUnaided = ddl_UnAidedOD.SelectedValue.ToString(),
                    VAODWithph = ddl_withph_od.SelectedValue.ToString(),
                    VAOSAided = ddl_Aided_OS.SelectedValue.ToString(),
                    VAOSUnaided = ddl_Unaided_OS.SelectedValue.ToString(),
                    VAOSWithph = ddl_withph_os.SelectedValue.ToString(),
                    VAUnaidedODRemarks = txt_unaided_od.Text,
                    VAUnaidedOSRemarks = txt_unaided_os.Text,
                    VAwithPhODRemarks = txt_withph_od.Text,
                    VAwithPhOSRemarks = txt_withph_os.Text,
                };
                consultantExamination2 = consultantExamination2Service.Add(consultantExamination2);

                DataTable dataTable = (DataTable)ViewState["CheifComplainByExaminer"];
                foreach (DataRow row in dataTable.Rows)
                {
                    CheifComplainByExamination cheifComplainByDoctor = new CheifComplainByExamination()
                    {
                        ExaminationId = consultantExamination2.ConsultantExaminationId,
                        CheifComplainId = int.Parse(row[1].ToString()),
                        Duration=row[3].ToString(),
                        Eye = row[4].ToString()
                    };
                    cheifComplainByExaminationService.Add(cheifComplainByDoctor);
                }

                ConsultantExaminationCombine consultantExaminationCombine = consultantExaminationCombineService.GetAll().Where(x => x.AppointmentId== int.Parse(ddl_Appointment.SelectedValue)).FirstOrDefault();
                consultantExaminationCombine.ConsultantExaminationId2 = consultantExamination2.ConsultantExaminationId;
                consultantExaminationCombineService.Update(consultantExaminationCombine);
                Common_Controle.Common_Methods.ClearTextBoxes(Page);
                Common_Controle.Common_Methods.ClearListBox(Page);
                if (consultantExamination2.ConsultantExaminationId != 0)
                {
                    ShowMessage("Record Added!!!", MessageType.Success);
                    //Response.AddHeader("REFRESH", "1;URL=Examiner_Home.aspx");
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message + " Something went wrong!!!", MessageType.Error);
            }
        }

        protected void btn_Submit_E3_Click(object sender, EventArgs e)
        {
            if (checkISPatient(3))
                return;
            if (ddl_Appointment.SelectedIndex < 1)
            {
                ShowMessage("Please select Appointment Id", MessageType.Warning);
                return;
            }
            try
            {
                ConsultantExamination3 consultantExamination3 = new ConsultantExamination3()
                {
                    
                    COLORVISIONOD = txt_color_od.Text,
                    COLORVISIONOS = txt_color_os.Text,
                    ConsultantId = int.Parse(Session["EmployeeId"].ToString()),
                    ExaminationDate = System.DateTime.Now,
                    LEFTEYEDISTANCEAXIS = txt_AXIS_LE_Distance.Text,
                    LEFTEYEDISTANCECYL = txt_CYL_LE_Distance.Text,
                    LEFTEYEDISTANCESPH = txt_SPH_LE_Distance.Text,
                    LEFTEYEDISTANCEVA = txt_VA_LE_Distance.Text,
                    LEFTEYENEARAXIS = txt_AXIS_LE_Near.Text,
                    LEFTEYENEARCYL = txt_CYL_LE_Near.Text,
                    LEFTEYENEARSPH = txt_SPH_LE_Near.Text,
                    LEFTEYENEARVA = txt_VA_LE_Near.Text,
                    PatientId = int.Parse(ddl_Patient_Id.SelectedValue),
                    PGPLEFTEYEDISTANCEAXIS = txt_AXIS_LE_Distance_PGP.Text,
                    PGPLEFTEYEDISTANCECYL = txt_CYL_LE_Distance_PGP.Text,
                    PGPLEFTEYEDISTANCESPH = txt_SPH_LE_Distance_PGP.Text,
                    PGPLEFTEYEDISTANCEVA = txt_VA_LE_Distance_PGP.Text,
                    PGPLEFTEYENEARAXIS = txt_AXIS_LE_Near_PGP.Text,
                    PGPLEFTEYENEARCYL = txt_CYL_LE_Near_PGP.Text,
                    PGPLEFTEYENEARSPH = txt_SPH_LE_Near_PGP.Text,
                    PGPLEFTEYENEARVA = txt_VA_LE_Near_PGP.Text,
                    PGPRIGHTEYEDISTANCEAXIS = txt_AXIS_RE_Distance_PGP.Text,
                    PGPRIGHTEYEDISTANCECYL = txt_CYL_RE_Distance_PGP.Text,
                    PGPRIGHTEYEDISTANCESPH = txt_SPH_RE_Distance_PGP.Text,
                    PGPRIGHTEYEDISTANCEVA = txt_VA_RE_Distance_PGP.Text,
                    PGPRIGHTEYENEARAXIS = txt_AXIS_RE_Near_PGP.Text,
                    PGPRIGHTEYENEARCYL = txt_CYL_RE_Near_PGP.Text,
                    PGPRIGHTEYENEARSPH = txt_SPH_RE_Near_PGP.Text,
                    PGPRIGHTEYENEARVA = txt_VA_RE_Near_PGP.Text,
                    PupilOD = txt_pupil_OD.Text,
                    PupilOS = txt_pupil_OS.Text,
                    
                    RatinoscopyDrop = int.Parse(ddl_DropsName.SelectedValue.ToString()),
                    RatinoscopyHMODDegree = txt_OD_HM_Degree.Text,
                    RatinoscopyHMODValue = txt_OD_HM_value.Text,
                    RatinoscopyHMOSDegree = txt_OS_HM_Degree.Text,
                    RatinoscopyHMOSValue = txt_OS_HM_value.Text,
                    RatinoscopyVMODDegree = txt_OD_VM_Degree.Text,
                    RatinoscopyVMODValue = txt_OD_VM_value.Text,
                    RatinoscopyVMOSDegree = txt_OS_VM_Degree.Text,
                    RatinoscopyVMOSValue = txt_OS_VM_value.Text,
                    RIGHTEYEDISTANCEAXIS = txt_AXIS_RE_Distance.Text,
                    RIGHTEYEDISTANCECYL = txt_CYL_RE_Distance.Text,
                    RIGHTEYEDISTANCESPH = txt_SPH_RE_Distance.Text,
                    RIGHTEYEDISTANCEVA = txt_VA_RE_Distance.Text,
                    RIGHTEYENEARAXIS = txt_AXIS_RE_Near.Text,
                    RIGHTEYENEARCYL = txt_CYL_RE_Near_PGP.Text,
                    RIGHTEYENEARSPH = txt_SPH_RE_Near_PGP.Text,
                    RIGHTEYENEARVA = txt_VA_RE_Near_PGP.Text 
                };
                if (rbl_amsler_OD.SelectedIndex > -1)
                    consultantExamination3.AmslergridOD = rbl_amsler_OD.SelectedValue;
                if (rbl_amsler_OD.SelectedIndex > -1)
                    consultantExamination3.AmslergridOS = rbl_amsler_OS.SelectedValue;
                if (rbl_rapd_OD.SelectedIndex > -1)
                    consultantExamination3.RappOD = rbl_rapd_OD.SelectedItem.Text;
                if (rbl_rapd_OS.SelectedIndex > -1)
                    consultantExamination3.RappOS = rbl_rapd_OS.SelectedItem.Text;
                if (rbl_sysinging_OD.SelectedIndex > -1)
                    consultantExamination3.SyringOD = rbl_sysinging_OD.SelectedItem.Text;
                if (rbl_sysinging_OS.SelectedIndex > -1)
                    consultantExamination3.SyringOS = rbl_sysinging_OS.SelectedItem.Text;
                consultantExamination3 = consultantExamination3Service.Add(consultantExamination3);
                ConsultantExaminationCombine consultantExaminationCombine = consultantExaminationCombineService.GetAll().Where(x => x.AppointmentId == int.Parse(ddl_Appointment.SelectedValue)).FirstOrDefault();
                consultantExaminationCombine.ConsultantExaminationId3 = consultantExamination3.ConsultantExaminationId;
                consultantExaminationCombineService.Update(consultantExaminationCombine);
                if (consultantExamination3.ConsultantExaminationId != 0)
                {
                    ShowMessage("Record Added!!!", MessageType.Success);
                    Response.AddHeader("REFRESH", "1;URL=Examiner_Home.aspx");
                }
            }
            catch
            {
                ShowMessage("Something went wrong!!!", MessageType.Error);
            }
        }

        private bool checkISPatient(int Examtype)
        {
            switch (Examtype)
            {
                case 1:
                    if (consultantExaminationCombineService.GetAll().Where(x => x.PatientId == int.Parse(ddl_Patient_Id.SelectedValue.ToString()) && x.Date.Date == DateTime.Now.Date).Select(x => x.PatientId).FirstOrDefault() != 0)
                    {
                        ShowMessage("Examination already completed for that Patient", MessageType.Warning);
                        return true;
                    }
                    break;
                case 2:
                    if (consultantExaminationCombineService.GetAll().Where(x => x.PatientId == int.Parse(ddl_Patient_Id.SelectedValue.ToString()) && x.Date.Date == DateTime.Now.Date && x.ConsultantExaminationId2 != 0).Select(x => x.PatientId).FirstOrDefault() != 0)
                    {
                        ShowMessage("Examination already completed for that Patient", MessageType.Warning);
                        return true;
                    }
                    break;
                case 3:
                    if (consultantExaminationCombineService.GetAll().Where(x => x.PatientId == int.Parse(ddl_Patient_Id.SelectedValue.ToString()) && x.Date.Date == DateTime.Now.Date && x.ConsultantExaminationId3 != 0).Select(x => x.PatientId).FirstOrDefault() != 0)
                    {
                        ShowMessage("Examination already completed for that Patient", MessageType.Warning);
                        return true;
                    }
                    break;
            }
            return false;
        }

        protected void btn_Save_Master_Click(object sender, EventArgs e)
        {
            switch (hdn_Distinguiser.Value)
            {
                case "1":
                    CheifComplainList cheifComplainList = new CheifComplainList()
                    {
                        CompalainName = txt_Name_Master.Text
                    };
                    ICheifComplainListService cheifComplainListService = new CheifComplainListService();
                    cheifComplainListService.Add(cheifComplainList);
                    //lb_Chife_Complain.DataBind();
                    break;
                case "2":
                    SystemicDisease systemicDisease = new SystemicDisease()
                    {
                        DiseaseName = txt_Name_Master.Text
                    };
                    ISystemicDiseaseService systemicDiseaseService = new SystemicDiseaseService();
                    systemicDiseaseService.Add(systemicDisease);
                    lb_Systematic_Diseases.DataBind();
                    break;
                case "3":
                    Alergy alergy = new Alergy()
                    {
                        AlergyName = txt_Name_Master.Text
                    };
                    IAlergyService alergyService = new AlergyService();
                    alergyService.Add(alergy);
                    lb_Allergy.DataBind();
                    break;
            }

        }

        protected void ddl_ExaminaationCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_ExaminaationCode.SelectedIndex != 0)
            {
                Session["CombineId"] = ddl_ExaminaationCode.SelectedValue.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('../ReportPages/Report_Examination.aspx');", true);
            }
        }

        protected void ddl_Prescription_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_Prescription.SelectedIndex != 0)
            {
                Session["TreatmentId"] = ddl_Prescription.SelectedValue.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('../DoctorPages/Prescription.aspx');", true);
            }
        }

        protected void btn_AddCheifComplain_Click(object sender, EventArgs e)
        {
            DataTable dtCheifComplainByExaminer = (DataTable)ViewState["CheifComplainByExaminer"];
            dtCheifComplainByExaminer.Rows.Add(dtCheifComplainByExaminer.Rows.Count + 1, ddl_CheifComplain.SelectedValue, ddl_CheifComplain.SelectedItem, txt_Duration_CC.Text,ddl_Eye_CheifComplain.SelectedValue);
            gv_CheifComplainByExaminer.DataSource = dtCheifComplainByExaminer;
            gv_CheifComplainByExaminer.DataBind();
        }

        protected void gv_CheifComplainByExaminer_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gv_CheifComplainByExaminer.EditIndex = -1;
            gv_CheifComplainByExaminer.DataBind();
        }

        protected void gv_CheifComplainByExaminer_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dataTable = ViewState["CheifComplainByExaminer"] as DataTable;
            deleteRow4CheifComplainByExaminerGV(e.RowIndex, dataTable);
        }

        protected void gv_CheifComplainByExaminer_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gv_CheifComplainByExaminer.EditIndex = e.NewEditIndex;
            gv_CheifComplainByExaminer.DataBind();
            DataTable dataTable = ViewState["CheifComplainByExaminer"] as DataTable;
            ddl_CheifComplain.SelectedValue = dataTable.Rows[e.NewEditIndex][1].ToString();
            ddl_Eye_CheifComplain.SelectedValue = dataTable.Rows[e.NewEditIndex][4].ToString();
            txt_Duration_CC.Text = dataTable.Rows[e.NewEditIndex][3].ToString();
            deleteRow4CheifComplainByExaminerGV(e.NewEditIndex, dataTable);
        }
        private void deleteRow4CheifComplainByExaminerGV(int RowIndex, DataTable dataTable)
        {
            dataTable.Rows[RowIndex].Delete();
            ViewState["CheifComplainByExaminer"] = dataTable;
            gv_CheifComplainByExaminer.DataSource = dataTable;
            gv_CheifComplainByExaminer.DataBind();
        }

        protected void ddl_Appointment_SelectedIndexChanged(object sender, EventArgs e)
        {
            IAppointmentService appointmentService = new AppointmentService();
            if (ddl_Appointment.SelectedIndex != 0)
            {
                lbl_Appointment_Date.Text = appointmentService.GetById(int.Parse(ddl_Appointment.SelectedValue.ToString())).Time.ToString("dd/MM/yyyy hh:mm tt");
            }
        }
    }
}