using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Web.Http.Description;
using SeconSightAPI.Models.ViewModel;
using SeconSightAPI.Models.EditModel;
using SecondSightWeb.Common_Controle;

namespace SeconSightAPI.Controllers
{
    [RoutePrefix("API")]
    public class MISController : ApiController
    {
        private readonly SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SecondSightDbContext"].ConnectionString);
        [Route("GetAppointmentDetails")]
        [HttpGet]
        [ResponseType(typeof(List<AppointmentDetailsViewModel>))]
        public List<AppointmentDetailsViewModel> GetAppointmentDetailsByRole()
        {
            List<AppointmentDetailsViewModel> listAppointmentDetailsViewModel = new List<AppointmentDetailsViewModel>();
            using (con)
            {
                SqlCommand cmdFetchAppointmentDetails = new SqlCommand("sp_GetAppointmentDetails", con);
                //cmdFetchAppointmentDetails.Parameters.AddWithValue("@RoleId", Common_Methods.Decrypt(employeeDetailsParam.RoleId));
                cmdFetchAppointmentDetails.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader drFetchAppointmentDetails = cmdFetchAppointmentDetails.ExecuteReader();
                while (drFetchAppointmentDetails.Read())
                {
                    listAppointmentDetailsViewModel.Add(new AppointmentDetailsViewModel()
                    {
                        PatCode = drFetchAppointmentDetails[0].ToString(),
                        AppointmentCode = drFetchAppointmentDetails[1].ToString(),
                        PatientName = drFetchAppointmentDetails[2].ToString(),
                        //Contact = Convert.ToDecimal(drFetchAppointmentDetails[3].ToString()),
                        Contact = drFetchAppointmentDetails[3].ToString(),
                        DoctorName = drFetchAppointmentDetails[4].ToString(),
                        AppointmentTime = drFetchAppointmentDetails[5].ToString(),
                        IsConfirmed = drFetchAppointmentDetails[6].ToString(),
                        IsAttented = drFetchAppointmentDetails[7].ToString(),
                        IsCanceled = drFetchAppointmentDetails[8].ToString(),
                    });
                }
                con.Close();
            }
            return listAppointmentDetailsViewModel;
        }

        [Route("GetExaminationDetails")]
        [HttpPost]
        [ResponseType(typeof(List<ExaminationDetailsViewModel>))]
        public List<ExaminationDetailsViewModel> GetExaminationDetailsByRole(EmployeeDetails employeeDetailsParam)
        {
            List<ExaminationDetailsViewModel> listexaminationDetailsViewModels = new List<ExaminationDetailsViewModel>();
            if (employeeDetailsParam != null)
            {
                using (con)
                {
                    SqlCommand cmdFetchExaminationDetails = new SqlCommand("sp_GetExaminationDetails", con);
                    //cmdFetchExaminationDetails.Parameters.AddWithValue("@EmployeeId", employeeDetailsParam.EmployeeId);
                    cmdFetchExaminationDetails.Parameters.AddWithValue("@EmployeeId", Common_Methods.Decrypt(employeeDetailsParam.EmployeeId));
                    //cmdFetchExaminationDetails.Parameters.AddWithValue("@RoleId", employeeDetailsParam.RoleId);
                    cmdFetchExaminationDetails.Parameters.AddWithValue("@RoleId", Common_Methods.Decrypt(employeeDetailsParam.RoleId));
                    cmdFetchExaminationDetails.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader drFetchExaminationDetails = cmdFetchExaminationDetails.ExecuteReader();
                    while (drFetchExaminationDetails.Read())
                    {
                        listexaminationDetailsViewModels.Add(new ExaminationDetailsViewModel()
                        {
                            PatCode = drFetchExaminationDetails[0].ToString(),
                            ExaminationCode = drFetchExaminationDetails[1].ToString(),
                            PatientName = drFetchExaminationDetails[2].ToString(),
                            Contact = drFetchExaminationDetails[3].ToString(),
                            ExaminationName = drFetchExaminationDetails[4].ToString(),
                            ExaminationTime = drFetchExaminationDetails[5].ToString(),
                            IsCompleted = drFetchExaminationDetails[6].ToString()
                        });
                    }
                    con.Close();
                }
            }
            return listexaminationDetailsViewModels;
        }

        [Route("GetOperationDetails")]
        [HttpPost]
        [ResponseType(typeof(List<OperationDetailsViewModel>))]
        public List<OperationDetailsViewModel> GetOperationDetailsByRoleId(EmployeeDetails employeeDetailsParam)
        {
            List<OperationDetailsViewModel> listOperationDetailsViewModels = new List<OperationDetailsViewModel>();
            if (employeeDetailsParam != null)
            {
                using (con)
                {
                    SqlCommand cmdFetchOperationDetails = new SqlCommand("sp_GetOperationDetails", con);
                    cmdFetchOperationDetails.Parameters.AddWithValue("@EmployeeId", Common_Methods.Decrypt(employeeDetailsParam.EmployeeId));
                    cmdFetchOperationDetails.Parameters.AddWithValue("@RoleId", Common_Methods.Decrypt(employeeDetailsParam.RoleId));
                    //cmdFetchOperationDetails.Parameters.AddWithValue("@EmployeeId", employeeDetailsParam.EmployeeId);
                    //cmdFetchOperationDetails.Parameters.AddWithValue("@Roleid", employeeDetailsParam.RoleId);
                    cmdFetchOperationDetails.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader drFetchOperationDetails = cmdFetchOperationDetails.ExecuteReader();
                    while (drFetchOperationDetails.Read())
                    {
                        listOperationDetailsViewModels.Add(new OperationDetailsViewModel()
                        {
                            PatCode = drFetchOperationDetails[0].ToString(),
                            Contact = drFetchOperationDetails[1].ToString(),
                            OperationCode = drFetchOperationDetails[2].ToString(),
                            PatientName = drFetchOperationDetails[3].ToString(),
                            RefferedBy = drFetchOperationDetails[4].ToString(),
                            RefferedTo = drFetchOperationDetails[5].ToString(),
                            SurgeryName = drFetchOperationDetails[6].ToString(),
                            SurgerySubName = drFetchOperationDetails[7].ToString(),
                            Eye = drFetchOperationDetails[8].ToString()
                        });
                    }
                }
            }
            return listOperationDetailsViewModels;
        }

        [Route("GetOperationSuccessRate")]
        [HttpPost]
        [ResponseType(typeof(List<OperationSuccessRateViewModel>))]
        public List<OperationSuccessRateViewModel> GetOperationSuccessRate(EmployeeDetails employeeDetailsParam)
        {
            List<OperationSuccessRateViewModel> listOperationSuccessRateViewModels = new List<OperationSuccessRateViewModel>();
            if (employeeDetailsParam != null && Common_Methods.Decrypt(employeeDetailsParam.RoleId) == "1")
            {
                using (con)
                {
                    SqlCommand cmdFetchOperationSuccessRate = new SqlCommand("sp_GetOperation_Success_Rate", con);
                    cmdFetchOperationSuccessRate.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader drFetchOperationSuccessRate = cmdFetchOperationSuccessRate.ExecuteReader();
                    while (drFetchOperationSuccessRate.Read())
                    {
                        listOperationSuccessRateViewModels.Add(new OperationSuccessRateViewModel()
                        {
                            RefferedOperation = drFetchOperationSuccessRate[0].ToString(),
                            ConvertedOperation = drFetchOperationSuccessRate[1].ToString(),
                            DoctorName = drFetchOperationSuccessRate[2].ToString(),
                            SuccessRate = ((Convert.ToInt32(drFetchOperationSuccessRate[1].ToString()) / Convert.ToInt32(drFetchOperationSuccessRate[0].ToString())) * 100).ToString("#0.00")
                        });
                    }
                    con.Close();
                }
            }
            return listOperationSuccessRateViewModels;
        }
        [Route("GetTreatementDetails")]
        [HttpPost]
        [ResponseType(typeof(List<TreatementDetailsViewModel>))]
        public List<TreatementDetailsViewModel> GetTreatementDetailsByRole(EmployeeDetails employeeDetailsParam)
        {
            List<TreatementDetailsViewModel> listTreatementDetailsViewModel = new List<TreatementDetailsViewModel>();
            if (employeeDetailsParam != null)
            {
                using (con)
                {
                    SqlCommand cmdFetchTreatementDetails = new SqlCommand("sp_GetTreatementDetails", con);
                    cmdFetchTreatementDetails.Parameters.AddWithValue("@EmployeeId", Common_Methods.Decrypt(employeeDetailsParam.EmployeeId));
                    cmdFetchTreatementDetails.Parameters.AddWithValue("@RoleId", Common_Methods.Decrypt(employeeDetailsParam.RoleId));
                    cmdFetchTreatementDetails.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader drFetchTreatementDetails = cmdFetchTreatementDetails.ExecuteReader();
                    while (drFetchTreatementDetails.Read())
                    {
                        listTreatementDetailsViewModel.Add(new TreatementDetailsViewModel()
                        {
                            TreatmentCode = drFetchTreatementDetails[0].ToString(),
                            DoctorName = drFetchTreatementDetails[1].ToString(),
                            PatientName = drFetchTreatementDetails[2].ToString(),
                            PatCode= drFetchTreatementDetails[3].ToString(),
                            Contact = drFetchTreatementDetails[4].ToString(),
                            CheifComplain = drFetchTreatementDetails[5].ToString(),
                            Disease = drFetchTreatementDetails[6].ToString(),
                            Advice = drFetchTreatementDetails[7].ToString(),
                            RefferedDoctorName = drFetchTreatementDetails[8].ToString(),
                            IsRefferedToTest = drFetchTreatementDetails[9].ToString(),
                            IsRefferedToOT = drFetchTreatementDetails[10].ToString(),
                            TreatmentDate = drFetchTreatementDetails[11].ToString(),
                        });
                    }
                    con.Close();
                }
            }
            return listTreatementDetailsViewModel;
        }

    }
}
