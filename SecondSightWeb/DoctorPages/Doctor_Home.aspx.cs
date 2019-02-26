using SecondSightSouthendEyeCentre;
using SecondSightSouthendEyeCentre.Data;
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
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecondSightWeb.DoctorPages
{
    public partial class Doctor_Home : System.Web.UI.Page
    {
        IPatientService patientService = new PatientService();
        IMedicineListService medicineListService = new MedicineListService();
        IAppointmentService appointmentService = new AppointmentService();
        ITreatementService treatementService = new TreatementService();
        ISuggestedTestsService suggestedTestsService = new SuggestedTestsService();
        IMedicationService medicationService = new MedicationService();
        IOperationSuggestionService operationSuggestionService = new OperationSuggestionService();
        IOperationCheckListDetailsService operationCheckListDetailsService = new OperationCheckListDetailsService();

        private static int OperationId = 0;
        Appointment appointment = new Appointment();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ddl_PatCode.DataBind();
                    if (ddl_PatCode.Items.Count > 0)
                    {
                        GetPatientDetails();
                    }
                    // Prescription
                    DataTable dtMedicineList = new DataTable();
                    dtMedicineList.Columns.AddRange(new DataColumn[5] { new DataColumn("SlNo", typeof(int)), new DataColumn("MedicineName", typeof(string)), new DataColumn("DossType", typeof(string)), new DataColumn("Eye", typeof(string)), new DataColumn("DossDuration", typeof(string)) });
                    ViewState["Prescription"] = dtMedicineList;
                    gv_MedicineDetails.DataSource = (DataTable)ViewState["Prescription"];
                    gv_MedicineDetails.DataBind();
                    // MainComplaints
                    DataTable dtMainComplaints = new DataTable();
                    dtMainComplaints.Columns.AddRange(new DataColumn[3] { new DataColumn("SlNo", typeof(int)), new DataColumn("MainComplaints", typeof(string)), new DataColumn("Eye", typeof(string)) });
                    ViewState["MainComplaints"] = dtMainComplaints;
                    gv_MainComplaints.DataSource = (DataTable)ViewState["MainComplaints"];
                    gv_MainComplaints.DataBind();
                    // PastOcularHistory
                    DataTable dtPastOcularHistory = new DataTable();
                    dtPastOcularHistory.Columns.AddRange(new DataColumn[3] { new DataColumn("SlNo", typeof(int)), new DataColumn("PastOcularHistory", typeof(string)), new DataColumn("Eye", typeof(string)) });
                    ViewState["PastOcularHistory"] = dtPastOcularHistory;
                    gv_PastOcularHistory.DataSource = (DataTable)ViewState["PastOcularHistory"];
                    gv_PastOcularHistory.DataBind();
                    // PastMedicalHistory
                    DataTable dtPastMedicalHistory = new DataTable();
                    dtPastMedicalHistory.Columns.AddRange(new DataColumn[3] { new DataColumn("SlNo", typeof(int)), new DataColumn("PastMedicalHistor", typeof(string)), new DataColumn("Eye", typeof(string)) });
                    ViewState["PastMedicalHistory"] = dtPastMedicalHistory;
                    gv_PastMedicalHistory.DataSource = (DataTable)ViewState["PastMedicalHistory"];
                    gv_PastMedicalHistory.DataBind();
                    // CheifComplainByDoctor
                    DataTable dtCheifComplainByDoctor = new DataTable();
                    dtCheifComplainByDoctor.Columns.AddRange(new DataColumn[5] { new DataColumn("SlNo", typeof(int)), new DataColumn("CheifComplainID", typeof(int)), new DataColumn("CheifComplain", typeof(string)), new DataColumn("Duration", typeof(string)), new DataColumn("Eye", typeof(string)) });
                    ViewState["CheifComplainByDoctor"] = dtCheifComplainByDoctor;
                    gv_CheifComplainByDoctor.DataSource = (DataTable)ViewState["CheifComplainByDoctor"];
                    gv_CheifComplainByDoctor.DataBind();
                    // DiseasesByDoctor
                    DataTable dtDiseasesByDoctor = new DataTable();
                    dtDiseasesByDoctor.Columns.AddRange(new DataColumn[4] { new DataColumn("SlNo", typeof(int)), new DataColumn("DiseasesID", typeof(int)), new DataColumn("Diseases", typeof(string)), new DataColumn("Eye", typeof(string)) });
                    ViewState["DiseasesByDoctor"] = dtDiseasesByDoctor;
                    gv_DiseasesByDoctor.DataSource = (DataTable)ViewState["DiseasesByDoctor"];
                    gv_DiseasesByDoctor.DataBind();
                }
            }
            catch (Exception ex)
            {
                txt_Date_Search.Text = ex.Message;
            }

        }
        protected void Page_PreInit(Object sender, EventArgs e)
        {
            SecondSightWeb.Common_Controle.Common_Methods.ChangeMasterPage(Page);
        }

        protected void btn_Serach_Patient_Date_Click(object sender, EventArgs e)
        {
            if (txt_Date_Search.Text != "")
            {
                ddl_PatCode.DataSource = null;
                ddl_PatCode.DataSourceID = "ds_PatCode_Date";
                ddl_PatCode.DataBind();
                ddl_Appointment.DataBind();
            }
            if (ddl_PatCode.SelectedValue.ToString() != "")
                GetPatientDetails();
        }
        private void GetPatientDetails()
        {
            SecondSightSouthendEyeCentre.Models.Patient patient = patientService.GetById(int.Parse(ddl_PatCode.SelectedValue.ToString()));
            if (patient != null)
            {
                lbl_PatName.Text = patient.FirstName + " " + patient.MiddleName + " " + patient.LastName;
                lbl_Age.Text = patient.Age.ToString();
                lbl_Gender.Text = patient.Gender;
            }
        }

        protected void ddl_PatCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetPatientDetails();
            if (ddl_PatCode.SelectedIndex > -1)
            {
                ddl_Appointment.DataSource = null;
                ddl_Appointment.DataSourceID = "ds_AppointmentId";
                ddl_Appointment.DataBind();
            }
            if (ddl_AppointmentDates.SelectedIndex > 0)
            {
                ddl_Appointment.DataSource = null;
                ddl_Appointment.DataSourceID = "ds_AppointmentId_Dates";
                ddl_Appointment.DataBind();
            }

        }
        [WebMethod]
        public static string[] GetMedicineName(string medicinename)
        {
            IMedicineListService medicineListService = new MedicineListService();
            IMedicineTypeListService medicineTypeListService = new MedicineTypeListService();
            List<String> medicineList = new List<string>();
            var list = (from mediCineListAll in medicineListService.GetAll() join medicineTypeList in medicineTypeListService.GetAll() on mediCineListAll.MedicineTypeId equals medicineTypeList.MedicineTypeId where mediCineListAll.MedicineName.ToLower().Contains(medicinename.ToLower()) select medicineTypeList.MedicineTypeShortCode + " - " + mediCineListAll.MedicineName).ToList();
            foreach (var name in list)
            {
                medicineList.Add(name.ToString());
            }
            return medicineList.ToArray();
        }

        protected void btn_AddMedicine_Click(object sender, EventArgs e)
        {
            DataTable dtMedicineList = (DataTable)ViewState["Prescription"];
            dtMedicineList.Rows.Add(dtMedicineList.Rows.Count + 1, txt_Medicine_Name.Text, ddl_Doss.SelectedValue, ddl_Eye.SelectedValue, txt_For.Text);
            gv_MedicineDetails.DataSource = dtMedicineList;
            gv_MedicineDetails.DataBind();
            ClearControls4MedicineDetails();
            //txt_Advice.Text = GetClintID();
        }
        private void ClearControls4MedicineDetails()
        {
            txt_For.Text = "";
            txt_Medicine_Name.Text = "";
            ddl_Doss.SelectedIndex = 0;
        }
        [WebMethod]
        public static string[] GetDoctorName(string employeeName)
        {
            IEmployeeService employeeService = new EmployeeService();
            IEmployeeLogService employeeLogService = new EmployeeLogService();
            List<String> medicineList = new List<string>();
            var list = (from employee in employeeService.GetAll()
                        join employeeLog in employeeLogService.GetAll() on employee.EmployeeId equals employeeLog.EmployeeId
                        where employeeLog.RoleId == 2
                        select new EmployeeShortInfo { EmployeeName = employee.FirstName + " " + employee.OtherName + " " + employee.LastName, EmployeeId = employee.EmployeeId }).ToList();
            list = (from lstName in list where lstName.EmployeeName.ToLower().Contains(employeeName.ToLower()) select lstName).ToList();
            foreach (var name in list.Select(x => x.EmployeeName))
            {
                medicineList.Add(name.ToString());
            }
            return medicineList.ToArray();
        }


        protected void ddl_ExaminaationCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_ExaminaationCode.SelectedIndex != 0)
            {
                Session["CombineId"] = ddl_ExaminaationCode.SelectedValue.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('../ReportPages/Report_Examination.aspx');", true);
            }
        }

        private void deleteRow4MedicineGV(int RowIndex, DataTable dataTable)
        {
            dataTable.Rows[RowIndex].Delete();
            ViewState["Prescription"] = dataTable;
            gv_MedicineDetails.DataSource = dataTable;
            gv_MedicineDetails.DataBind();
        }

        protected void gv_MedicineDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dataTable = ViewState["Prescription"] as DataTable;
            deleteRow4MedicineGV(e.RowIndex, dataTable);
        }

        protected void gv_MedicineDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gv_MedicineDetails.EditIndex = e.NewEditIndex;
            gv_MedicineDetails.DataBind();
            DataTable dataTable = ViewState["Prescription"] as DataTable;
            txt_Medicine_Name.Text = dataTable.Rows[e.NewEditIndex][1].ToString();
            ddl_Doss.SelectedValue = dataTable.Rows[e.NewEditIndex][2].ToString();
            ddl_Eye.SelectedValue = dataTable.Rows[e.NewEditIndex][3].ToString();
            txt_For.Text = dataTable.Rows[e.NewEditIndex][4].ToString();
            deleteRow4MedicineGV(e.NewEditIndex, dataTable);
        }

        protected void gv_MedicineDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gv_MedicineDetails.EditIndex = -1;
            gv_MedicineDetails.DataBind();
        }


        protected void ddl_Appointment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_Appointment.SelectedIndex != 0)
            {
                lbl_Appointment_Date.Text = appointmentService.GetById(int.Parse(ddl_Appointment.SelectedValue.ToString())).Time.ToString("dd/MM/yyyy hh:mm tt");
            }
        }
        public enum MessageType { Success, Error, Info, Warning };
        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            if (ddl_Appointment.SelectedIndex < 1)
            {
                ShowMessage("Pls Select Appointment ID", MessageType.Warning);
                return;
            }
            string disease = string.Empty, cheifComplain = string.Empty, testDetails = string.Empty;
            bool TestAssigned = false;
            using (var context = new SecondSightDbContext())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        // TODO
                        //foreach (ListItem itemsDisease in lb_Disease.Items)
                        //{
                        //    if (itemsDisease.Selected)
                        //    {
                        //        disease += itemsDisease.Text + ",";
                        //    }
                        //}
                        //foreach (ListItem itemsCheifComplain in lb_cheifComplain.Items)
                        //{
                        //    if (itemsCheifComplain.Selected)
                        //    {
                        //        cheifComplain += itemsCheifComplain.Text + ",";
                        //    }
                        //}
                        foreach (ListItem itemsTests in lb_Tset_Master.Items)
                        {
                            if (itemsTests.Selected)
                            {
                                TestAssigned = true;
                            }
                        }
                        bool isRefferedToOT = false;
                        foreach (ListItem items in chk_Ot.Items)
                        {
                            if (items.Selected)
                                isRefferedToOT = true;
                        }
                        SecondSightSouthendEyeCentre.Models.Treatement treatement = new SecondSightSouthendEyeCentre.Models.Treatement()
                        {
                            Advice = txt_Advice.Text,
                            AppointmentId = int.Parse(ddl_Appointment.SelectedValue.ToString()),
                            CheifComplain = cheifComplain.TrimEnd(','),
                            Disease = disease.TrimEnd(','),
                            DoctorId = int.Parse(Session["EmployeeId"].ToString()),
                            IsRefferedToOT = isRefferedToOT,
                            IsRefferedToTest = TestAssigned,
                            PatientId = int.Parse(ddl_PatCode.SelectedValue.ToString()),
                            RefferedDoctorName = txt_doc_name.Text,
                        };
                        // TODO
                        //if (rbl_CC.SelectedIndex > -1)
                        //{
                        //    treatement.CheifComplainEye = rbl_CC.SelectedValue.ToString();
                        //}
                        //if (rbl_Dis.SelectedIndex > -1)
                        //{
                        //    treatement.DiseaseEye = rbl_Dis.SelectedValue.ToString();
                        //}
                        treatement = context.Treatement.Add(treatement);
                        context.SaveChanges();
                        Combine(treatement.TreatmentId, context);
                        appointment = appointmentService.GetById(treatement.AppointmentId);
                        appointment.IsAttented = true;
                        //Change will be later.
                        appointmentService.Update(appointment);

                        AddExternalTest(treatement.TreatmentId, context);


                        DataTable dataTable = (DataTable)ViewState["Prescription"];
                        foreach (DataRow row in dataTable.Rows)
                        {
                            SecondSightSouthendEyeCentre.Models.Medication medication = new SecondSightSouthendEyeCentre.Models.Medication()
                            {
                                TreatmentId = treatement.TreatmentId,
                                MedicineName = row[1].ToString(),
                                Doss = row[2].ToString(),
                                Duration = row[3].ToString(),
                            };
                            //medicationService.Add(medication);
                            context.Medication.Add(medication);
                            context.SaveChanges();
                        }
                        foreach (ListItem itemsTests in lb_Tset_Master.Items)
                        {
                            if (itemsTests.Selected)
                            {
                                SuggestedTests suggestedTests = new SuggestedTests()
                                {
                                    TreatmentId = treatement.TreatmentId,
                                    TestId = int.Parse(itemsTests.Value)
                                };
                                //suggestedTestsService.Add(suggestedTests);
                                context.SuggestedTests.Add(suggestedTests);
                                context.SaveChanges();
                            }
                        }
                        if (OperationId != 0)
                        {
                            foreach (ListItem items in cbl_ot_Check_lists.Items)
                            {
                                if (items.Selected)
                                {
                                    OperationCheckListDetails operationCheckListDetails = new OperationCheckListDetails()
                                    {
                                        OpeationSuggessitionId = OperationId,
                                        OtCheckListId = int.Parse(items.Value)
                                    };
                                    //operationCheckListDetailsService.Add(operationCheckListDetails);
                                    context.OtOperationCheckListDetails.Add(operationCheckListDetails);
                                    context.SaveChanges();
                                }
                            }
                        }
                        if (treatement.TreatmentId != 0)
                        {
                            ShowMessage("Record Added!!!", MessageType.Success);
                            Session["TreatmentId"] = treatement.TreatmentId;
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('../DoctorPages/Prescription.aspx');", true);
                            if (OperationId != 0)
                            {
                                Session["OperationSuggesstionId"] = OperationId;
                                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('../CommonPages/Surgery_Advice.aspx');", true);
                                OperationId = 0;
                            }
                            dbContextTransaction.Commit();
                            Response.AddHeader("REFRESH", "1;URL=Doctor_Home.aspx");
                        }
                        else
                        {
                            appointment = appointmentService.GetById(treatement.AppointmentId);
                            appointment.IsAttented = false;
                            dbContextTransaction.Rollback();
                            ShowMessage("There was an technical error!!!", MessageType.Error);
                        }
                    }
                    catch (Exception Ex)
                    {
                        dbContextTransaction.Rollback();
                        Common_Controle.Common_Methods.SendErrorToText(Ex);
                        ShowMessage(Ex.Message + "Something went wrong!!!", MessageType.Error);
                    }
                }
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

        protected void btn_Submit_Operation_Click(object sender, EventArgs e)
        {
            if (ddl_Appointment.SelectedIndex <= 0 && ddl_PatCode.SelectedIndex <= 0)
            {
                ShowMessage("Please select AppointmentID/Pat Code", MessageType.Warning);
                return;
            }
            else
            {
                try
                {
                    OperationSuggestion operationSuggestion = new OperationSuggestion()
                    {
                        AppointmentId = int.Parse(ddl_Appointment.SelectedValue.ToString()),
                        Eye = rbl_Eye.SelectedValue.ToString(),
                        DoctorsName = txt_DoctorName_OT.Text,
                        IsConvertedToOT = false,
                        IsDeleted = false,
                        OperationCategory = int.Parse(ddl_Operation_Procedure.SelectedValue.ToString()),
                        OperationDate = DateTime.Parse(txt_Date.Value),
                        PatientId = int.Parse(ddl_PatCode.SelectedValue.ToString()),
                        RefferedBy = int.Parse(Session["EmployeeId"].ToString()),
                        RefferTime = DateTime.Now
                    };
                    operationSuggestion = operationSuggestionService.Add(operationSuggestion);
                    if (operationSuggestion.Id != 0)
                    {
                        chk_Ot.Enabled = false;
                        cbl_ot_Check_lists.Visible = true;
                        OperationId = operationSuggestion.Id;
                    }
                }
                catch
                {
                    ShowMessage("Please check the details and try again!!!", MessageType.Warning);
                }

            }
        }

        protected void ddl_Operation_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_Operation_Type.SelectedIndex > 0)
            {
                ddl_Operation_Procedure.DataSource = null;
                ddl_Operation_Procedure.DataSourceID = "ds_Ot_Procedure";
                ddl_Operation_Procedure.DataBind();
            }
        }

        //private DoctorExaminationGlassPrescription GlassPrescription(SecondSightDbContext context)
        //{
        //    //IDoctorExaminationGlassPrescriptionService doctorExaminationGlassPrescriptionService = new DoctorExaminationGlassPrescriptionService();
        //    DoctorExaminationGlassPrescription doctorExaminationGlassPrescription = new DoctorExaminationGlassPrescription()
        //    {
        //        DVRESph = txt_RE_DV_SPh.Text,
        //        DVRECyl = txt_RE_Cyl.Text,
        //        DVREAxis = txt_RE_Axis.Text,
        //        DVREVA = txt_RE_DV_VA.Text,
        //        DVLESph = txt_LE_DV_SPh.Text,
        //        DVLECyl = txt_LE_Cyl.Text,
        //        DVLEAxis = txt_LE_Axis.Text,
        //        DVLEVA = txt_LE_DV_VA.Text,
        //        ADDRESph = txt_RE_ADD_SPh.Text,
        //        ADDREVA = txt_RE_ADD_VA.Text,
        //        ADDREDistance = txt_RE_Distance.Text,
        //        ADDLESph = txt_LE_ADD_SPh.Text,
        //        ADDLEVA = txt_LE_ADD_VA.Text,
        //        ADDLEDistance = txt_LE_Distance.Text
        //    };
        //    doctorExaminationGlassPrescription = context.DoctorExaminationGlassPrescription.Add(doctorExaminationGlassPrescription);
        //    context.SaveChanges();
        //    return doctorExaminationGlassPrescription;
        //}

        private DoctorExaminationLens Lens(SecondSightDbContext context)
        {
            //IDoctorExaminationLensService doctorExaminationLensService = new DoctorExaminationLensService();
            DoctorExaminationLens doctorExaminationLens = new DoctorExaminationLens()
            {
                RELensStatus = txt_RE_LensStatus.Text,
                REPigmentsOnAnteriorLenCapsule = txt_RE_PigmentsOnAnteriorLenCapsule.Text,
                LELensStatus = txt_LE_LensStatus.Text,
                LEPigmentsOnAnteriorLenCapsule = txt_LE_PigmentsOnAnteriorLenCapsule.Text
            };
            doctorExaminationLens = context.DoctorExaminationLens.Add(doctorExaminationLens);
            context.SaveChanges();
            return doctorExaminationLens;
        }

        private DoctorExaminationPupil Pupil(SecondSightDbContext context)
        {
            //IDoctorExaminationPupilService doctorExaminationPupilService = new DoctorExaminationPupilService();
            DoctorExaminationPupil doctorExaminationPupil = new DoctorExaminationPupil()
            {
                RESize = txt_RE_Size.Text,
                REShape = txt_RE_Shape.Text,
                REReactionOfLight = txt_RE_ReactionOfLight.Text,
                RERemarks = txt_RE_Remarks.Text,
                REUpperLidMargin = txt_RE_UpperLidMargin.Text,
                RELowerLidMargin = txt_RE_LowerLidMargin.Text,
                REUpperLash = txt_RE_UpperLash.Text,
                RELowerLash = txt_RE_LowerLash.Text,
                REUpperPunctum = txt_RE_UpperPunctum.Text,
                RELowerPunctum = txt_RE_LowerPunctum.Text,
                RESpecialConditions = txt_RE_SpecialConditions_Pupil.Text,
                LESize = txt_LE_Size.Text,
                LEShape = txt_LE_Shape.Text,
                LEReactionOfLight = txt_LE_ReactionOfLight.Text,
                LERemarks = txt_LE_Remarks.Text,
                LEUpperLidMargin = txt_LE_UpperLidMargin.Text,
                LELowerLidMargin = txt_LE_LowerLidMargin.Text,
                LEUpperLash = txt_LE_UpperLash.Text,
                LELowerLash = txt_LE_LowerLash.Text,
                LEUpperPunctum = txt_LE_UpperPunctum.Text,
                LELowerPunctum = txt_LE_LowerPunctum.Text,
                LESpecialConditions = txt_LE_SpecialConditions_Pupil.Text
            };
            doctorExaminationPupil = context.DoctorExaminationPupil.Add(doctorExaminationPupil);
            context.SaveChanges();
            return doctorExaminationPupil;
        }

        private DoctorExaminationIris Iris(SecondSightDbContext context)
        {
            //IDoctorExaminationIrisService doctorExaminationIrisService = new DoctorExaminationIrisService();
            DoctorExaminationIris doctorExaminationIris = new DoctorExaminationIris()
            {
                REIrisDetail = txt_RE_IrisDetail.Text,
                LEIrisDetail = txt_LE_IrisDetail.Text
            };
            doctorExaminationIris = context.DoctorExaminationIris.Add(doctorExaminationIris);
            context.SaveChanges();
            return doctorExaminationIris;
        }

        private DoctorExaminationConjuctiva Conjuctiva(SecondSightDbContext context)
        {
            //IDoctorExaminationConjuctivaService doctorExaminationConjuctivaService = new DoctorExaminationConjuctivaService();
            DoctorExaminationConjuctiva doctorExaminationConjuctiva = new DoctorExaminationConjuctiva()
            {
                REUpperPalperbal = txt_RE_UpperPalperbal.Text,
                RELowerPalperbal = txt_RE_LowerPalperbal.Text,
                REBulbarNasal = txt_RE_BulbarNasal.Text,
                REBulberTemporal = txt_RE_BulberTemporal.Text,
                RELimbus = txt_RE_Limbus.Text,
                REFornix = txt_RE_Fornix.Text,
                RESpecialConditions = txt_RE_SpecialConditions_Conjuctiva.Text,
                LEUpperPalperbal = txt_LE_UpperPalperbal.Text,
                LELowerPalperbal = txt_LE_LowerPalperbal.Text,
                LEBulbarNasal = txt_LE_BulbarNasal.Text,
                LEBulberTemporal = txt_LE_BulberTemporal.Text,
                LELimbus = txt_LE_Limbus.Text,
                LEFornix = txt_LE_Fornix.Text,
                LESpecialConditions = txt_LE_SpecialConditions_Conjuctiva.Text
            };
            doctorExaminationConjuctiva = context.DoctorExaminationConjuctiva.Add(doctorExaminationConjuctiva);
            context.SaveChanges();
            return doctorExaminationConjuctiva;
        }

        private DoctorExaminationDiagnosis Diagnosis(SecondSightDbContext context)
        {
            //IDoctorExaminationDiagnosisService doctorExaminationDiagnosisService = new DoctorExaminationDiagnosisService();
            DoctorExaminationDiagnosis doctorExaminationDiagnosis = new DoctorExaminationDiagnosis()
            {
                REDescription = txt_RE_Description.Text,
                LEDescription = txt_LE_Description.Text
            };
            doctorExaminationDiagnosis = context.DoctorExaminationDiagnosis.Add(doctorExaminationDiagnosis);
            context.SaveChanges();
            return doctorExaminationDiagnosis;
        }

        private DoctorExaminationCornea Cornea(SecondSightDbContext context)
        {
            IDoctorExaminationCorneaService doctorExaminationCorneaService = new DoctorExaminationCorneaService();
            DoctorExaminationCornea doctorExaminationCornea = new DoctorExaminationCornea()
            {
                RESclera = txt_RE_Sclera.Text,
                RECornea = txt_RE_Cornea.Text,
                REAnteriorChamberCentralDepth = txt_RE_AnteriorChamberCentraldepth.Text,
                REAnteriorChamberPeripheralDepth = txt_RE_AnteriorChamberPeripheraldepth.Text,
                REVonHenricksGrading = txt_RE_VonHenricksGrading.Text,
                RESpecialConditions = txt_RE_SpecialConditions_Cornea.Text,
                LESclera = txt_LE_Sclera.Text,
                LECornea = txt_LE_Cornea.Text,
                LEAnteriorChamberCentralDepth = txt_LE_AnteriorChamberCentraldepth.Text,
                LEAnteriorChamberPeripheralDepth = txt_LE_AnteriorChamberPeripheraldepth.Text,
                LEVonHenricksGrading = txt_LE_VonHenricksGrading.Text,
                LESpecialConditions = txt_LE_SpecialConditions_Cornea.Text
            };
            doctorExaminationCornea = context.DoctorExaminationCornea.Add(doctorExaminationCornea);
            context.SaveChanges();
            return doctorExaminationCornea;
        }

        private DoctorExaminationIntraOcularPressure IntraOcularPressure(SecondSightDbContext context)
        {
            IDoctorExaminationIntraOcularPressureService doctorExaminationIntraOcularPressureService = new DoctorExaminationIntraOcularPressureService();
            DoctorExaminationIntraOcularPressure doctorExaminationIntraOcularPressure = new DoctorExaminationIntraOcularPressure()
            {
                REApplanationValue = txt_RE_Applanation.Text,
                LEApplanationValue = txt_LE_Applanation.Text,
                //ApplanationActualTime = DateTime.Parse(txt_ActualTime.Text),
                ApplanationActualTime = DateTime.Now,
            };
            doctorExaminationIntraOcularPressure = context.DoctorExaminationIntraOcularPressure.Add(doctorExaminationIntraOcularPressure);
            context.SaveChanges();
            return doctorExaminationIntraOcularPressure;
        }

        private DoctorExaminationFollowUp FollowUp(SecondSightDbContext context)
        {
            IDoctorExaminationFollowUpService doctorExaminationFollowUpService = new DoctorExaminationFollowUpService();
            DoctorExaminationFollowUp doctorExaminationFollowUp = new DoctorExaminationFollowUp()
            {
                FollowUpInFormation = txt_FollowUp.Text
            };
            doctorExaminationFollowUp = context.DoctorExaminationFollowUp.Add(doctorExaminationFollowUp);
            context.SaveChanges();
            return doctorExaminationFollowUp;
        }

        private DoctorExaminationGonioscopy Gonioscopy(SecondSightDbContext context)
        {
            IDoctorExaminationGonioscopyService doctorExaminationGonioscopyService = new DoctorExaminationGonioscopyService();
            DoctorExaminationGonioscopy doctorExaminationGonioscopy = new DoctorExaminationGonioscopy()
            {
                LEGonioscopy = txt_RE_Gonioscopy.Text,
                REGonioscopy = txt_LE_Gonioscopy.Text
            };
            doctorExaminationGonioscopy = context.DoctorExaminationGonioscopy.Add(doctorExaminationGonioscopy);
            context.SaveChanges();
            return doctorExaminationGonioscopy;
        }

        private DoctorExaminationOcularAlignment OcularAlignment(SecondSightDbContext context)
        {
            IDoctorExaminationOcularAlignmentService doctorExaminationOcularAlignmentService = new DoctorExaminationOcularAlignmentService();
            DoctorExaminationOcularAlignment doctorExaminationOcularAlignment = new DoctorExaminationOcularAlignment()
            {
                OcularAlignment = txt_OcularAlignment.Text
            };
            doctorExaminationOcularAlignment = context.DoctorExaminationOcularAlignment.Add(doctorExaminationOcularAlignment);
            context.SaveChanges();
            return doctorExaminationOcularAlignment;
        }

        private DoctorExaminationOculerMovement OculerMovement(SecondSightDbContext context)
        {
            IDoctorExaminationOculerMovementService doctorExaminationOculerMovementService = new DoctorExaminationOculerMovementService();
            DoctorExaminationOculerMovement doctorExaminationOculerMovement = new DoctorExaminationOculerMovement()
            {
                REOculerMovement = txt_RE_OculerMovement.Text,
                LEOculerMovement = txt_LE_OculerMovement.Text
            };
            doctorExaminationOculerMovement = context.DoctorExaminationOculerMovement.Add(doctorExaminationOculerMovement);
            context.SaveChanges();
            return doctorExaminationOculerMovement;
        }

        private DoctorExaminationVitreous Vitreous(SecondSightDbContext context)
        {
            IDoctorExaminationVitreousService doctorExaminationVitreousService = new DoctorExaminationVitreousService();
            DoctorExaminationVitreous doctorExaminationVitreous = new DoctorExaminationVitreous()
            {
                LEVitreous = txt_LE_Vitreous.Text,
                REVitreous = txt_RE_Vitreous.Text
            };
            doctorExaminationVitreous = context.DoctorExaminationVitreous.Add(doctorExaminationVitreous);
            context.SaveChanges();
            return doctorExaminationVitreous;
        }

        private DoctorExaminationFundus Fundus(SecondSightDbContext context)
        {
            IDoctorExaminationFundusService doctorExaminationFundusService = new DoctorExaminationFundusService();
            DoctorExaminationFundus doctorExaminationFundus = new DoctorExaminationFundus()
            {
                LEFundusUp = txt_LE_FundusUp.Text,
                LEFundusDown = txt_LE_FundusDown.Text,
                LESpecialConditions = txt_LE_SpecialConditions_Fundus.Text,
                REFundusUp = txt_RE_FundusUp.Text,
                REFundusDown = txt_RE_FundusDown.Text,
                RESpecialConditions = txt_RE_SpecialConditions_Fundus.Text
            };
            doctorExaminationFundus = context.DoctorExaminationFundus.Add(doctorExaminationFundus);
            context.SaveChanges();
            return doctorExaminationFundus;
        }

        private void Combine(int treatmentId, SecondSightDbContext context)
        {
            IDoctorExaminationCombineService doctorExaminationCombineService = new DoctorExaminationCombineService();
            // Doctor Examination..
            //var doctorExaminationGlassPrescription = GlassPrescription(context);
            var doctorExaminationLens = Lens(context);
            var doctorExaminationPupil = Pupil(context);
            var doctorExaminationIris = Iris(context);
            var doctorExaminationConjuctiva = Conjuctiva(context);
            var doctorExaminationDiagnosis = Diagnosis(context);
            var doctorExaminationCornea = Cornea(context);
            var doctorExaminationIntraOcularPressure = IntraOcularPressure(context);
            var doctorExaminationFollowUp = FollowUp(context);
            var doctorExaminationGonioscopy = Gonioscopy(context);
            var doctorExaminationOcularAlignment = OcularAlignment(context);
            var doctorExaminationOculerMovement = OculerMovement(context);
            var doctorExaminationVitreous = Vitreous(context);
            var doctorExaminationFundus = Fundus(context);

            DoctorExaminationCombine doctorExaminationCombine = new DoctorExaminationCombine()
            {
                DoctorExaminationGlassPrescriptionId = -1,
                //DoctorExaminationGlassPrescriptionId = doctorExaminationGlassPrescription.DoctorExaminationGlassPrescriptionId,
                DoctorExaminationLensId = doctorExaminationLens.DoctorExaminationLensId,
                DoctorExaminationPupilId = doctorExaminationPupil.DoctorExaminationPupilId,
                DoctorExaminationIrisId = doctorExaminationIris.DoctorExaminationIrisId,
                DoctorExaminationConjuctivaId = doctorExaminationConjuctiva.DoctorExaminationConjuctivaId,
                DoctorExaminationDiagnosisId = doctorExaminationDiagnosis.DoctorExaminationDiagnosisId,
                DoctorExaminationCorneaId = doctorExaminationCornea.DoctorExaminationCorneaId,
                DoctorExaminationIntraOcularPressureId = doctorExaminationIntraOcularPressure.DoctorExaminationIntraOcularPressureId,
                DoctorExaminationFollowUpId = doctorExaminationFollowUp.DoctorExaminationFollowUpId,
                DoctorExaminationGonioscopyId = doctorExaminationGonioscopy.DoctorExaminationGonioscopyId,
                DoctorExaminationOcularAlignmentId = doctorExaminationOculerMovement.DoctorExaminationOculerMovementId,
                DoctorExaminationOculerMovementId = doctorExaminationOculerMovement.DoctorExaminationOculerMovementId,
                DoctorExaminationVitreousId = doctorExaminationVitreous.DoctorExaminationVitreousId,
                DoctorExaminationFundusId = doctorExaminationFundus.DoctorExaminationFundusId,
                TreatmentId = treatmentId,
                Date = DateTime.Now,
                isDeleted = false
            };
            doctorExaminationCombine = context.DoctorExaminationCombine.Add(doctorExaminationCombine);
            context.SaveChanges();
            DataTable dataTable = (DataTable)ViewState["MainComplaints"];
            foreach (DataRow row in dataTable.Rows)
            {
                MainComplaints mainComplaints = new MainComplaints()
                {
                    TreatmentId = treatmentId,
                    Complaints = row[1].ToString(),
                    Eye = row[2].ToString()

                };
                mainComplaints = context.MainComplaints.Add(mainComplaints);
                context.SaveChanges();


            }
            dataTable = (DataTable)ViewState["PastOcularHistory"];
            foreach (DataRow row in dataTable.Rows)
            {
                PastOcularHistory pastOcularHistory = new PastOcularHistory()
                {
                    TreatmentId = treatmentId,
                    OcularHistory = row[1].ToString(),
                    Eye = row[2].ToString()
                };
                pastOcularHistory = context.PastOcularHistory.Add(pastOcularHistory);
                context.SaveChanges();
            }

            dataTable = (DataTable)ViewState["PastMedicalHistory"];
            foreach (DataRow row in dataTable.Rows)
            {
                PastMedicalHistory pastMedicalHistory = new PastMedicalHistory()
                {
                    TreatmentId = treatmentId,
                    MedicalHistory = row[1].ToString(),
                    Eye = row[2].ToString()
                };
                pastMedicalHistory = context.PastMedicalHistory.Add(pastMedicalHistory);
                context.SaveChanges();
            }

            dataTable = (DataTable)ViewState["CheifComplainByDoctor"];
            foreach (DataRow row in dataTable.Rows)
            {
                CheifComplainByDoctor cheifComplainByDoctor = new CheifComplainByDoctor()
                {
                    TreatmentId = treatmentId,
                    CheifComplainListId = int.Parse(row[1].ToString()),
                    Duration = row[3].ToString(),
                    Eye = row[4].ToString()
                };
                cheifComplainByDoctor = context.CheifComplainByDoctor.Add(cheifComplainByDoctor);
                context.SaveChanges();
            }

            dataTable = (DataTable)ViewState["DiseasesByDoctor"];
            foreach (DataRow row in dataTable.Rows)
            {
                DiseasesByDoctor diseasesByDoctor = new DiseasesByDoctor()
                {
                    TreatmentId = treatmentId,
                    DiseasesId = int.Parse(row[1].ToString()),
                    Eye = row[3].ToString()
                };
                diseasesByDoctor = context.DiseasesByDoctor.Add(diseasesByDoctor);
                context.SaveChanges();
            }

        }

        [WebMethod]
        public static string[] GetMainComplaintList(string complaint)
        {
            IMainComplaintsService mainComplaintsService = new MainComplaintsService();
            List<String> complaintList = new List<string>();

            var list = mainComplaintsService.GetAll().ToList();
            list = (from mainComplaint in list where mainComplaint.Complaints.ToLower().Contains(complaint.ToLower()) select mainComplaint).ToList();
            foreach (var complaintName in list.Select(x => x.Complaints))
            {
                complaintList.Add(complaintName.ToString());
            }
            return complaintList.ToArray();
        }

        [WebMethod]
        public static string[] GetPastOcularHistoryList(string ocularHistory)
        {
            IPastOcularHistoryService pastOcularHistoryService = new PastOcularHistoryService();
            List<String> ocularHistoryList = new List<string>();

            var list = pastOcularHistoryService.GetAll();
            list = (from pastOcularHistory in list where pastOcularHistory.OcularHistory.ToLower().Contains(ocularHistory.ToLower()) select pastOcularHistory).ToList();
            foreach (var ocularHistoryName in list.Select(x => x.OcularHistory))
            {
                ocularHistoryList.Add(ocularHistoryName.ToString());
            }
            return ocularHistoryList.ToArray();
        }

        [WebMethod]
        public static string[] GetPastMedicalHistorList(string medicalHistory)
        {
            IPastMedicalHistoryService pastMedicalHistoryService = new PastMedicalHistoryService();
            List<String> medicalHistoryList = new List<string>();

            var list = pastMedicalHistoryService.GetAll();
            list = (from pastMedicalHistory in list where pastMedicalHistory.MedicalHistory.ToLower().Contains(medicalHistory.ToLower()) select pastMedicalHistory).ToList();
            foreach (var medicalHistoryName in list.Select(x => x.MedicalHistory))
            {
                medicalHistoryList.Add(medicalHistoryName.ToString());
            }
            return medicalHistoryList.ToArray();
        }

        protected void gv_MainComplaints_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dataTable = ViewState["MainComplaints"] as DataTable;
            deleteRow4MainComplaintsGV(e.RowIndex, dataTable);
        }

        protected void gv_MainComplaints_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gv_MainComplaints.EditIndex = e.NewEditIndex;
            gv_MainComplaints.DataBind();
            DataTable dataTable = ViewState["MainComplaints"] as DataTable;
            txt_MainComplaints.Text = dataTable.Rows[e.NewEditIndex][1].ToString();
            ddl_Eye_MainComplaints.SelectedValue = dataTable.Rows[e.NewEditIndex][2].ToString();
            deleteRow4MedicineGV(e.NewEditIndex, dataTable);
        }

        protected void gv_MainComplaints_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gv_MainComplaints.EditIndex = -1;
            gv_MainComplaints.DataBind();
        }

        protected void btn_AddMainComplaints_Click(object sender, EventArgs e)
        {
            DataTable dtAdviceList = (DataTable)ViewState["MainComplaints"];
            dtAdviceList.Rows.Add(dtAdviceList.Rows.Count + 1, txt_MainComplaints.Text, ddl_Eye_MainComplaints.SelectedValue);
            gv_MainComplaints.DataSource = dtAdviceList;
            gv_MainComplaints.DataBind();
            txt_MainComplaints.Text = string.Empty;
        }


        private void deleteRow4MainComplaintsGV(int RowIndex, DataTable dataTable)
        {
            dataTable.Rows[RowIndex].Delete();
            ViewState["MainComplaints"] = dataTable;
            gv_MainComplaints.DataSource = dataTable;
            gv_MainComplaints.DataBind();
        }

        protected void gv_PastOcularHistory_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dataTable = ViewState["PastOcularHistory"] as DataTable;
            deleteRow4PastOcularHistoryGV(e.RowIndex, dataTable);
        }

        protected void gv_PastOcularHistory_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gv_PastOcularHistory.EditIndex = e.NewEditIndex;
            gv_PastOcularHistory.DataBind();
            DataTable dataTable = ViewState["PastOcularHistory"] as DataTable;
            txt_PastOcularHistory.Text = dataTable.Rows[e.NewEditIndex][1].ToString();
            ddl_Eye_PastOcularHistory.SelectedValue = dataTable.Rows[e.NewEditIndex][2].ToString();
            deleteRow4PastOcularHistoryGV(e.NewEditIndex, dataTable);
        }

        protected void gv_PastOcularHistory_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gv_PastOcularHistory.EditIndex = -1;
            gv_PastOcularHistory.DataBind();
        }

        protected void btn_AddPastOcularHistory_Click(object sender, EventArgs e)
        {
            DataTable dtAdviceList = (DataTable)ViewState["PastOcularHistory"];
            dtAdviceList.Rows.Add(dtAdviceList.Rows.Count + 1, txt_PastOcularHistory.Text, ddl_Eye_PastOcularHistory.SelectedValue);
            gv_PastOcularHistory.DataSource = dtAdviceList;
            gv_PastOcularHistory.DataBind();
            txt_PastOcularHistory.Text = string.Empty;
        }

        private void deleteRow4PastOcularHistoryGV(int RowIndex, DataTable dataTable)
        {
            dataTable.Rows[RowIndex].Delete();
            ViewState["PastOcularHistory"] = dataTable;
            gv_PastOcularHistory.DataSource = dataTable;
            gv_PastOcularHistory.DataBind();
        }

        protected void gv_PastMedicalHistory_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dataTable = ViewState["PastMedicalHistory"] as DataTable;
            deleteRow4PastMedicalHistoryGV(e.RowIndex, dataTable);
        }

        protected void gv_PastMedicalHistory_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gv_PastMedicalHistory.EditIndex = e.NewEditIndex;
            gv_PastMedicalHistory.DataBind();
            DataTable dataTable = ViewState["PastMedicalHistory"] as DataTable;
            txt_PastMedicalHistory.Text = dataTable.Rows[e.NewEditIndex][1].ToString();
            ddl_Eye_PastMedicalHistory.SelectedValue = dataTable.Rows[e.NewEditIndex][2].ToString();
            deleteRow4PastMedicalHistoryGV(e.NewEditIndex, dataTable);
        }

        protected void gv_PastMedicalHistory_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gv_PastMedicalHistory.EditIndex = -1;
            gv_PastMedicalHistory.DataBind();
        }

        protected void btn_AddPastMedicalHistory_Click(object sender, EventArgs e)
        {
            DataTable dtPastMedicalHistory = (DataTable)ViewState["PastMedicalHistory"];
            dtPastMedicalHistory.Rows.Add(dtPastMedicalHistory.Rows.Count + 1, txt_PastMedicalHistory.Text, ddl_Eye_PastMedicalHistory.SelectedValue);
            gv_PastMedicalHistory.DataSource = dtPastMedicalHistory;
            gv_PastMedicalHistory.DataBind();
            txt_PastMedicalHistory.Text = string.Empty;
        }

        private void deleteRow4PastMedicalHistoryGV(int RowIndex, DataTable dataTable)
        {
            dataTable.Rows[RowIndex].Delete();
            ViewState["PastMedicalHistory"] = dataTable;
            gv_PastMedicalHistory.DataSource = dataTable;
            gv_PastMedicalHistory.DataBind();
        }

        protected void ddl_AppointmentDates_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_AppointmentDates.SelectedIndex > 0)
            {
                ddl_Appointment.DataSource = null;
                ddl_Appointment.DataSourceID = "ds_AppointmentId_Dates";
                ddl_Appointment.DataBind();
                ddl_PatCode.DataSource = null;
                ddl_PatCode.DataSourceID = "ds_PatCode_Date";
                ddl_PatCode.DataBind();
            }
        }

        protected void ddl_AppointmentDates_DataBound(object sender, EventArgs e)
        {
            //DropDownList list = sender as DropDownList;
            //if (list != null)
            //    list.Items.Insert(0, "-Select Date-");
        }
        private void AddExternalTest(int treatmentId, SecondSightDbContext context)
        {
            foreach (ListItem items in cbl_ot_Check_lists.Items)
            {
                if (items.Selected)
                {
                    OperationCheckListDetails operationCheckListDetails = new OperationCheckListDetails()
                    {
                        TreatmentId = treatmentId,
                        OtCheckListId = int.Parse(items.Value)
                    };
                    //operationCheckListDetailsService.Add(operationCheckListDetails);
                    context.OtOperationCheckListDetails.Add(operationCheckListDetails);
                    context.SaveChanges();
                }
            }
        }

        protected void gv_CheifComplainByDoctor_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dataTable = ViewState["CheifComplainByDoctor"] as DataTable;
            deleteRow4CheifComplainByDoctorGV(e.RowIndex, dataTable);
        }

        protected void gv_CheifComplainByDoctor_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gv_CheifComplainByDoctor.EditIndex = e.NewEditIndex;
            gv_CheifComplainByDoctor.DataBind();
            DataTable dataTable = ViewState["CheifComplainByDoctor"] as DataTable;
            ddl_CheifComplain.SelectedValue = dataTable.Rows[e.NewEditIndex][1].ToString();
            ddl_Eye_CheifComplain.SelectedValue = dataTable.Rows[e.NewEditIndex][4].ToString();
            txt_Duration_CC.Text = dataTable.Rows[e.NewEditIndex][3].ToString();
            deleteRow4CheifComplainByDoctorGV(e.NewEditIndex, dataTable);
        }

        protected void gv_CheifComplainByDoctor_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gv_CheifComplainByDoctor.EditIndex = -1;
            gv_CheifComplainByDoctor.DataBind();
        }

        protected void btn_AddCheifComplain_Click(object sender, EventArgs e)
        {
            DataTable dtCheifComplainByDoctor = (DataTable)ViewState["CheifComplainByDoctor"];
            dtCheifComplainByDoctor.Rows.Add(dtCheifComplainByDoctor.Rows.Count + 1, ddl_CheifComplain.SelectedValue, ddl_CheifComplain.SelectedItem, txt_Duration_CC.Text, ddl_Eye_CheifComplain.SelectedValue);
            gv_CheifComplainByDoctor.DataSource = dtCheifComplainByDoctor;
            gv_CheifComplainByDoctor.DataBind();
        }

        private void deleteRow4CheifComplainByDoctorGV(int RowIndex, DataTable dataTable)
        {
            dataTable.Rows[RowIndex].Delete();
            ViewState["CheifComplainByDoctor"] = dataTable;
            gv_CheifComplainByDoctor.DataSource = dataTable;
            gv_CheifComplainByDoctor.DataBind();
        }

        protected void gv_DiseasesByDoctor_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dataTable = ViewState["DiseasesByDoctor"] as DataTable;
            deleteRow4DiseasesByDoctorGV(e.RowIndex, dataTable);
        }

        protected void gv_DiseasesByDoctor_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gv_DiseasesByDoctor.EditIndex = e.NewEditIndex;
            gv_DiseasesByDoctor.DataBind();
            DataTable dataTable = ViewState["DiseasesByDoctor"] as DataTable;
            ddl_DiseasesByDoctor.SelectedValue = dataTable.Rows[e.NewEditIndex][1].ToString();
            ddl_Eye_DiseasesByDoctor.SelectedValue = dataTable.Rows[e.NewEditIndex][3].ToString();
            deleteRow4DiseasesByDoctorGV(e.NewEditIndex, dataTable);
        }



        protected void gv_DiseasesByDoctor_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gv_DiseasesByDoctor.EditIndex = -1;
            gv_DiseasesByDoctor.DataBind();
        }

        protected void btn_AddDiseasesByDoctor_Click(object sender, EventArgs e)
        {
            DataTable dtDiseasesByDoctor = (DataTable)ViewState["DiseasesByDoctor"];
            dtDiseasesByDoctor.Rows.Add(dtDiseasesByDoctor.Rows.Count + 1, ddl_DiseasesByDoctor.SelectedValue, ddl_DiseasesByDoctor.SelectedItem, ddl_Eye_DiseasesByDoctor.SelectedValue);
            gv_DiseasesByDoctor.DataSource = dtDiseasesByDoctor;
            gv_DiseasesByDoctor.DataBind();
        }

        private void deleteRow4DiseasesByDoctorGV(int RowIndex, DataTable dataTable)
        {
            dataTable.Rows[RowIndex].Delete();
            ViewState["DiseasesByDoctor"] = dataTable;
            gv_DiseasesByDoctor.DataSource = dataTable;
            gv_DiseasesByDoctor.DataBind();
        }
    }
}