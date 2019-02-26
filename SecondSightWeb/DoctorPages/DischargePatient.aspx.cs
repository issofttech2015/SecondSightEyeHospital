using SecondSightSouthendEyeCentre.Models;
using SecondSightSouthendEyeCentre.Service.Implementation;
using SecondSightSouthendEyeCentre.Service.Interfaces;
using SecondSightWeb.Areas.OtManager.Models.ViewModels;
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
    public partial class DischargePatient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                All_Visible_off();
                ddl_Operation_List.DataBind();
                if (ddl_Operation_List.Items.Count > 0)
                    GetOperationDetails();
                DataTable dtMedicineList = new DataTable();
                dtMedicineList.Columns.AddRange(new DataColumn[4] { new DataColumn("SlNo", typeof(int)), new DataColumn("MedicineName", typeof(string)), new DataColumn("DossType", typeof(string)), new DataColumn("DossDuration", typeof(string)) });
                ViewState["Prescription"] = dtMedicineList;
                gv_MedicineDetails.DataSource = (DataTable)ViewState["Prescription"];
                gv_MedicineDetails.DataBind();
            }
        }

        protected void ddl_Operation_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            All_Visible_off();
            GetOperationDetails();
        }
        IOperationSuggestionService operationSuggestionService = new OperationSuggestionService();
        IOTChargeCategoryService oTChargeCategoryService = new OTChargeCategoryService();
        IPatientService patientService = new PatientService();
        IEmployeeService employeeService = new EmployeeService();
        IOperarionDetailsService operarionDetailsService = new OperarionDetailsService();
        IOTChargesService oTChargesService = new OTChargesService();
        private void GetOperationDetails()
        {
            OtConfirmationViewModel lstOtConfirmationViewModel = (from op in operarionDetailsService.GetAll()
                                                                  join otcs in oTChargesService.GetAll() on op.SurgicalProcedure equals otcs.OtChargeId
                                                                  join ops in operationSuggestionService.GetAll() on op.OperationSuggestionId equals ops.Id
                                                                  join emp in employeeService.GetAll() on ops.RefferedBy equals emp.EmployeeId
                                                                  join empDoc in employeeService.GetAll() on op.DoctorId equals empDoc.EmployeeId
                                                                  join ps in patientService.GetAll() on op.PatientId equals ps.PatientId
                                                                  join otCat in oTChargeCategoryService.GetAll() on otcs.OtCategoryId equals otCat.Id
                                                                  where ops.IsCancelled == false && ops.IsDeleted == false && ops.IsConvertedToOT == true
                                                                  && op.OperationId == int.Parse(ddl_Operation_List.SelectedValue.ToString())
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

                                                                  }).FirstOrDefault();
            if (lstOtConfirmationViewModel != null)
            {
                lbl_Reffered_Doctor.Text = lstOtConfirmationViewModel.ReffredbyDoctorsName;
                lbl_Patient_Name.Text = lstOtConfirmationViewModel.PatientName;
                lbl_Eye.Text = lstOtConfirmationViewModel.Eye;
                lbl_Suggested_Doctor.Text = lstOtConfirmationViewModel.SuggestedDoctor;
                lbl_Operation_Name.Text = lstOtConfirmationViewModel.Operation;
                lbl_Operation_Date.Text = lstOtConfirmationViewModel.OperationTime.ToString();
                lbl_Surgical_Procedure.Text = lstOtConfirmationViewModel.SurgicalProcedure;
                OperationDetails1.Visible = true;
                OperationDetails2.Visible = true;
                OperationDetails3.Visible = true;
            }
            if (rbl_Is_Operation_Done.SelectedValue.ToString() == "1")
            {
                OperationDetails_Input.Visible = true;
            }
            else
            {
                Discharge_Patient_Input_Group1.Visible = true;
                Discharge_Patient_Input_Group2.Visible = true;
                Discharge_Patient_Input_Group3.Visible = true;
                Discharge_Patient_Input_Group4.Visible = true;
                Discharge_Patient_Input_Group5.Visible = true;
            }
        }

        private void All_Visible_off()
        {
            OperationDetails_Input.Visible = false;
            Discharge_Patient_Input_Group1.Visible = false;
            Discharge_Patient_Input_Group2.Visible = false;
            Discharge_Patient_Input_Group3.Visible = false;
            Discharge_Patient_Input_Group4.Visible = false;
            Discharge_Patient_Input_Group5.Visible = false;
            OperationDetails1.Visible = false;
            OperationDetails2.Visible = false;
            OperationDetails3.Visible = false;
        }

        protected void rbl_Is_Operation_Done_SelectedIndexChanged(object sender, EventArgs e)
        {
            All_Visible_off();
            if (rbl_Is_Operation_Done.SelectedValue.ToString() == "1")
            {
                ddl_Operation_List.DataSource = null;
                ddl_Operation_List.DataSourceID = "ds_Operation_List_Approved_Operated";
                ddl_Operation_List.DataBind();
                ddl_Pat_Code.DataSource = null;
                ddl_Pat_Code.DataSourceID = "ds_PatCode_Operated";
                ddl_Pat_Code.DataBind();
            }
            else
            {
                ddl_Operation_List.DataSource = null;
                ddl_Operation_List.DataSourceID = "ds_Operation_List_Discharge_Patient";
                ddl_Operation_List.DataBind();
                ddl_Pat_Code.DataSource = null;
                ddl_Pat_Code.DataSourceID = "ds_PatCode_Discharge";
                ddl_Pat_Code.DataBind();
            }
            if (ddl_Operation_List.Items.Count > 0)
                GetOperationDetails();
        }

        protected void Approved_Operated_Click(object sender, EventArgs e)
        {
            OperarionDetails operarionDetails = operarionDetailsService.GetById(int.Parse(ddl_Operation_List.SelectedValue.ToString()));
            operarionDetails.IsOperated = true;
            operarionDetails.OTStartTime = DateTime.ParseExact(txt_OT_Start_Date_time.Text, "dd/MM/yyyy HH:mm tt", System.Globalization.CultureInfo.InvariantCulture);
            operarionDetails.OTEndTime = DateTime.ParseExact(txt_OT_End_Date_time.Text, "dd/MM/yyyy HH:mm tt", System.Globalization.CultureInfo.InvariantCulture);
            operarionDetailsService.Update(operarionDetails);
            Response.Redirect("DischargePatient.aspx");
        }

        private void deleteRow4GV(int RowIndex, DataTable dataTable)
        {
            dataTable.Rows[RowIndex].Delete();
            ViewState["Prescription"] = dataTable;
            gv_MedicineDetails.DataSource = dataTable;
            gv_MedicineDetails.DataBind();
        }
        protected void gv_MedicineDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dataTable = ViewState["Prescription"] as DataTable;
            deleteRow4GV(e.RowIndex, dataTable);
        }

        protected void gv_MedicineDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gv_MedicineDetails.EditIndex = e.NewEditIndex;
            gv_MedicineDetails.DataBind();
            DataTable dataTable = ViewState["Prescription"] as DataTable;
            txt_Medicine_Name.Text = dataTable.Rows[e.NewEditIndex][1].ToString();
            ddl_Doss.SelectedValue = dataTable.Rows[e.NewEditIndex][2].ToString();
            txt_For.Text = dataTable.Rows[e.NewEditIndex][3].ToString();
            deleteRow4GV(e.NewEditIndex, dataTable);
        }


        protected void gv_MedicineDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gv_MedicineDetails.EditIndex = -1;
            gv_MedicineDetails.DataBind();
        }

        protected void btn_AddMedicine_Click(object sender, EventArgs e)
        {
            DataTable dtMedicineList = (DataTable)ViewState["Prescription"];
            dtMedicineList.Rows.Add(dtMedicineList.Rows.Count + 1, txt_Medicine_Name.Text, ddl_Doss.SelectedValue, txt_For.Text);
            gv_MedicineDetails.DataSource = dtMedicineList;
            gv_MedicineDetails.DataBind();
            ClearControls();
        }

        private void ClearControls()
        {
            txt_For.Text = "";
            txt_Medicine_Name.Text = "";
            ddl_Doss.SelectedIndex = 0;
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

        protected void Save_Discharge_Patient_Details_Click(object sender, EventArgs e)
        {
            if (ddl_Operation_List.SelectedIndex < 1)
            {
                ShowMessage("Pls Select Operation ID", MessageType.Warning);
                return;
            }
            if(rb_Discharge_Type.SelectedIndex<-1)
            {
                ShowMessage("Please select Discharge Certificate type!!!", MessageType.Warning);
                return;
            }
            try
            {
                //ADD DischargeDetails
                IDischargeDetailsService dischargeDetailsService = new DischargeDetailsService();
                IMedicationService medicationService = new MedicationService();

                DischargeDetails dischargeDetails = new DischargeDetails()
                {
                    DischargeDate = DateTime.Parse(txt_Discharge_Date.Text),
                    Diagonosis = txt_Diagonosis.Text,
                    NextVisitDate = DateTime.Parse(txt_Next_Visit_Date.Text),
                    NextVisitTime = DateTime.Now.TimeOfDay,
                    OperationId = int.Parse(ddl_Operation_List.SelectedValue.ToString()),
                    DischargeCertificateType= int.Parse(rb_Discharge_Type.SelectedValue.ToString()),
                    AdditionalComments=txt_Addnl_Comments.Text.Replace("\n", "\r\n")
            };
                dischargeDetailsService.Add(dischargeDetails);
                //Add Medication
                DataTable dataTable = (DataTable)ViewState["Prescription"];
                foreach (DataRow row in dataTable.Rows)
                {
                    SecondSightSouthendEyeCentre.Models.Medication medication = new SecondSightSouthendEyeCentre.Models.Medication()
                    {
                        OperationId = int.Parse(ddl_Operation_List.SelectedValue.ToString()),
                        MedicineName = row[1].ToString(),
                        Doss = row[2].ToString(),
                        Duration = row[3].ToString(),
                    };
                    medicationService.Add(medication);
                }
                if (dischargeDetails.DischargeDetailsId != 0)
                {
                    Session["Operation_Id"] = operarionDetailsService.GetById(int.Parse(ddl_Operation_List.SelectedValue.ToString())).OperationId;
                    ShowMessage("Record Added!!!", MessageType.Success);
                    switch (rb_Discharge_Type.SelectedValue.ToString())
                    {
                        case "1":
                            Response.AddHeader("REFRESH", "1;URL=../CommonPages/Discharge_Certificate.aspx");
                            break;
                        case "2":
                            Response.AddHeader("REFRESH", "1;URL=../CommonPages/Discharge_Certificate_Night_Care.aspx");
                            break;
                    }
                }
                else
                    ShowMessage("There was an technical error!!!", MessageType.Error);

            }
            catch(Exception ex)
            {
                Common_Controle.Common_Methods.SendErrorToText(ex);
                ShowMessage("Something Went Wrong!!!", MessageType.Error);
                return;
            }
        }
        public enum MessageType { Success, Error, Info, Warning };
        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }

        protected void ddl_Pat_Code_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_Pat_Code.SelectedIndex > -1)
            {

                if (rbl_Is_Operation_Done.SelectedValue.ToString() == "1")
                {
                    ddl_Operation_List.DataSource = null;
                    ddl_Operation_List.DataSourceID = "ds_Operation_List_Approved_Operated";
                    ddl_Operation_List.DataBind();
                }
                else
                {
                    ddl_Operation_List.DataSource = null;
                    ddl_Operation_List.DataSourceID = "ds_Operation_List_Discharge_Patient";
                    ddl_Operation_List.DataBind();

                }
                if (ddl_Operation_List.Items.Count > 0)
                    GetOperationDetails();
            }
        }

        protected void Page_PreInit(Object sender, EventArgs e)
        {
            SecondSightWeb.Common_Controle.Common_Methods.ChangeMasterPage(Page);
        }
    }
}