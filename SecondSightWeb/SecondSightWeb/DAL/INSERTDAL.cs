using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SecondSightSouthendEyeCentre
{
    public class INSERTDAL
    {
        #region Singleton Object
        private static INSERTDAL instance;
        private static object syncObject = new Object();
        private INSERTDAL() { }

        public static INSERTDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncObject)
                    {
                        if (instance == null)
                        {
                            instance = new INSERTDAL();
                        }
                    }
                }
                return instance;
            }
        }
        #endregion
        private readonly SqlConnection conString = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SecondSightDbContext"].ConnectionString);
        public bool AddPatient(Patitent patitent)
        {
            SqlCommand cmdAddPAtient = new SqlCommand();
            cmdAddPAtient.CommandText = "sp_InsertPatient";
            cmdAddPAtient.CommandType = System.Data.CommandType.StoredProcedure;
            cmdAddPAtient.Connection = conString;
            cmdAddPAtient.Parameters.AddWithValue("@FirstName", patitent.FirstName);
            cmdAddPAtient.Parameters.AddWithValue("@MiddleName", patitent.MiddeleName);
            cmdAddPAtient.Parameters.AddWithValue("@LastName", patitent.LastName);
            cmdAddPAtient.Parameters.AddWithValue("@Gender", patitent.Gender);
            cmdAddPAtient.Parameters.AddWithValue("@DateofBirth", patitent.DateofBirth);
            cmdAddPAtient.Parameters.AddWithValue("@Nationality", patitent.Natationality);
            cmdAddPAtient.Parameters.AddWithValue("@Age", patitent.Age);
            cmdAddPAtient.Parameters.AddWithValue("@Contact", patitent.Contact);
            cmdAddPAtient.Parameters.AddWithValue("@ResidanceAddress", patitent.ResidanceAddress);
            cmdAddPAtient.Parameters.AddWithValue("@Email", patitent.Email);
            cmdAddPAtient.Parameters.AddWithValue("@GuardianFirstName", patitent.GuardianFirstName);
            cmdAddPAtient.Parameters.AddWithValue("@GuardianLastName", patitent.GuardianLastName);
            cmdAddPAtient.Parameters.AddWithValue("@GuardianContact", patitent.GuardianContact);
            cmdAddPAtient.Parameters.AddWithValue("@GuardianRelateAs", patitent.GuardianRelateAs);
            cmdAddPAtient.Parameters.AddWithValue("@Ocupation", patitent.Ocupation);
            cmdAddPAtient.Parameters.AddWithValue("@PatCode", patitent.PatCode);
            cmdAddPAtient.Parameters.AddWithValue("@AdharNo", patitent.Adhar);
            conString.Open();
            int result=cmdAddPAtient.ExecuteNonQuery();
            conString.Close();
            if (result > 0)
                return true;
            return false;
        }
        public bool AddEmployee(Employee employee)
        {
            SqlCommand cmdAddPAtient = new SqlCommand();
            cmdAddPAtient.CommandText = "sp_InsertEmployee";
            cmdAddPAtient.CommandType = System.Data.CommandType.StoredProcedure;
            cmdAddPAtient.Connection = conString;
            cmdAddPAtient.Parameters.AddWithValue("@FirstName", employee.FirstName);
            cmdAddPAtient.Parameters.AddWithValue("@OtherName", employee.MiddeleName);
            cmdAddPAtient.Parameters.AddWithValue("@LastName", employee.LastName);
            cmdAddPAtient.Parameters.AddWithValue("@Gender", employee.Gender);
            cmdAddPAtient.Parameters.AddWithValue("@DateofBirth", employee.DateofBirth);
            cmdAddPAtient.Parameters.AddWithValue("@Nationality", employee.Natationality);
            cmdAddPAtient.Parameters.AddWithValue("@Age", employee.Age);
            cmdAddPAtient.Parameters.AddWithValue("@Contact", employee.Contact);
            cmdAddPAtient.Parameters.AddWithValue("@Qualification", employee.Qualification);
            cmdAddPAtient.Parameters.AddWithValue("@DepartmentId", employee.DepartmentId);
            cmdAddPAtient.Parameters.AddWithValue("@Designation", employee.Designation);
            cmdAddPAtient.Parameters.AddWithValue("@ResidanceAddress", employee.ResidanceAddress);
            cmdAddPAtient.Parameters.AddWithValue("@DateJoined", employee.DateofJoin);
            cmdAddPAtient.Parameters.AddWithValue("@Email", employee.Email);
            cmdAddPAtient.Parameters.AddWithValue("@ReferanceName", employee.RefrenceName);
            cmdAddPAtient.Parameters.AddWithValue("@RefrenceContact", employee.RefrenceContact);
            cmdAddPAtient.Parameters.AddWithValue("@ImageName", employee.ImageName);
            cmdAddPAtient.Parameters.AddWithValue("@ImagePath", employee.ImagePath);
            cmdAddPAtient.Parameters.AddWithValue("@RoleId", employee.RoleId);
            conString.Open();
           int result = cmdAddPAtient.ExecuteNonQuery();
            conString.Close();
            if (result > 0)
                return true;
            return false;
        }
        public bool AddAppointment(Appointments appoints)
        {
            SqlCommand cmd = new SqlCommand("Insert into Appointment values(@AppointmentType,@Name,@Mobile,@Address,@DoctorsId,@Time,@Comments,@PatCode,@IsAttented,@IsConfirmed,@IsNew,@IsCanceled)", conString);
            cmd.Parameters.AddWithValue("@AppointmentType",appoints.AppointmentType);
            cmd.Parameters.AddWithValue("@Name", appoints.PatientName);
            cmd.Parameters.AddWithValue("@Mobile", appoints.MobileNo);
            cmd.Parameters.AddWithValue("@Address", appoints.Address);
            cmd.Parameters.AddWithValue("@DoctorsId", appoints.DoctorsId);
            cmd.Parameters.AddWithValue("@Time", appoints.Time);
            cmd.Parameters.AddWithValue("@Comments", appoints.Comments);
            cmd.Parameters.AddWithValue("@PatCode", appoints.PatCode);
            cmd.Parameters.AddWithValue("@IsAttented",appoints.IsAttented);
            cmd.Parameters.AddWithValue("@IsConfirmed", appoints.IsConfirmed);
            cmd.Parameters.AddWithValue("@IsNew", appoints.IsNew);
            cmd.Parameters.AddWithValue("@IsCanceled", appoints.IsCanceled);
            conString.Open(); 
            int result=cmd.ExecuteNonQuery();
            conString.Close();
            if (result > 0)
                return true;
            return false;

        }
        public int AddTreatment(Treatment tretment)
        {
            int result = 0;
            SqlCommand cmdAddPAtient = new SqlCommand();
            cmdAddPAtient.CommandText = "sp_InsertTreatment";
            cmdAddPAtient.CommandType = System.Data.CommandType.StoredProcedure;
            cmdAddPAtient.Connection = conString;
            cmdAddPAtient.Parameters.AddWithValue("@DoctorId", tretment.DoctorId);
            cmdAddPAtient.Parameters.AddWithValue("@PatientId", tretment.PatientId);
            cmdAddPAtient.Parameters.AddWithValue("@CheifComplain", tretment.CheifComplain);
            cmdAddPAtient.Parameters.AddWithValue("@EyeDiseaseLeft", tretment.EyeDiseaseLeft);
            cmdAddPAtient.Parameters.AddWithValue("@EyeDiseaseRight", tretment.EyeDiseaseRight);
            cmdAddPAtient.Parameters.AddWithValue("@Advice", tretment.Advice);
            cmdAddPAtient.Parameters.AddWithValue("@Duration", tretment.Duration);
            conString.Open();
            result = (int)cmdAddPAtient.ExecuteScalar();
            conString.Close();
            return result;
        }
        public bool AddMedication(Medication medication)
        {
            SqlCommand cmd = new SqlCommand("Insert into Medication values(@TreatmentId,@PatientId,@MedicineName)", conString);
            cmd.Parameters.AddWithValue("@TreatmentId", medication.TreatmentId);
            cmd.Parameters.AddWithValue("@PatientId", medication.PatientId);
            cmd.Parameters.AddWithValue("@MedicineName", medication.MedicationName);
            conString.Open();
            int result = cmd.ExecuteNonQuery();
            conString.Close();
            if (result > 0)
                return true;
            return false;
        }
        public bool AddConsultant1(ConsultantExamination1 consultantExamination1)
        {
            SqlCommand cmdAddPAtient = new SqlCommand();
            cmdAddPAtient.CommandText = "sp_InsertConsultantExamination1";
            cmdAddPAtient.CommandType = System.Data.CommandType.StoredProcedure;
            cmdAddPAtient.Connection = conString;
            cmdAddPAtient.Parameters.AddWithValue("@PatientId", consultantExamination1.PatientId);
            cmdAddPAtient.Parameters.AddWithValue("@ConsultantId", consultantExamination1.ConsultantId);
            cmdAddPAtient.Parameters.AddWithValue("@ARSPHRE", consultantExamination1.ARSPHRE);
            cmdAddPAtient.Parameters.AddWithValue("@ARCYLRE", consultantExamination1.ARCYLRE);
            cmdAddPAtient.Parameters.AddWithValue("@ARAXISRE", consultantExamination1.ARAXISRE);
            cmdAddPAtient.Parameters.AddWithValue("@ARSPHLE", consultantExamination1.ARSPHLE);
            cmdAddPAtient.Parameters.AddWithValue("@ARCYLLE", consultantExamination1.ARCYLLE);
            cmdAddPAtient.Parameters.AddWithValue("@ARAXISLE", consultantExamination1.ARAXISLE);
            cmdAddPAtient.Parameters.AddWithValue("@NCTOD", consultantExamination1.NCTOD);
            cmdAddPAtient.Parameters.AddWithValue("@NCTOS", consultantExamination1.NCTOS);

            conString.Open();
            int result = cmdAddPAtient.ExecuteNonQuery();
            conString.Close();
            if (result > 0)
                return true;
            return false;
        }

        public bool AddConsultant2(ConsultantExamination2 consultantExamination2)
        {
            SqlCommand cmdAddPAtient = new SqlCommand();
            cmdAddPAtient.CommandText = "sp_InsertConsultatntExamination2";
            cmdAddPAtient.CommandType = System.Data.CommandType.StoredProcedure;
            cmdAddPAtient.Connection = conString;
            cmdAddPAtient.Parameters.AddWithValue("@PatientId", consultantExamination2.PatientId);
            cmdAddPAtient.Parameters.AddWithValue("@ConsultantId", consultantExamination2.ConsultantId);
            cmdAddPAtient.Parameters.AddWithValue("@CheifComplain", consultantExamination2.CheifComplain);
            cmdAddPAtient.Parameters.AddWithValue("@SystematicDisease", consultantExamination2.SystematicDisease);
            cmdAddPAtient.Parameters.AddWithValue("@Alegry", consultantExamination2.Alegry);

            //=============================================
            cmdAddPAtient.Parameters.AddWithValue("@PastHistory", consultantExamination2.PastHistory);
            cmdAddPAtient.Parameters.AddWithValue("@FamilyHistory", consultantExamination2.FamilyHistory);
            cmdAddPAtient.Parameters.AddWithValue("@CurrentTreatment", consultantExamination2.CurrentTreatment);
            cmdAddPAtient.Parameters.AddWithValue("@CurrentInvestigation", consultantExamination2.CurrentInvestigation);
            cmdAddPAtient.Parameters.AddWithValue("@VAODUnaided", consultantExamination2.VAODUnaided);
            cmdAddPAtient.Parameters.AddWithValue("@VAODAided", consultantExamination2.VAODAided);
            cmdAddPAtient.Parameters.AddWithValue("@VAODWithph", consultantExamination2.VAODWithph);
            cmdAddPAtient.Parameters.AddWithValue("@VAOSUnaided", consultantExamination2.VAOSUnaided);
            cmdAddPAtient.Parameters.AddWithValue("@VAOSAided", consultantExamination2.VAOSAided);
            cmdAddPAtient.Parameters.AddWithValue("@VAOSWithph", consultantExamination2.VAOSWithph);
            cmdAddPAtient.Parameters.AddWithValue("@VAODRemarks", consultantExamination2.VAODRemarks);
            cmdAddPAtient.Parameters.AddWithValue("@VAOSRemarks", consultantExamination2.VAOSRemarks);
            //=============================================
            conString.Open();
            int result = cmdAddPAtient.ExecuteNonQuery();
            conString.Close();
            if (result > 0)
                return true;
            return false;
        }
        public string ReturnFinYear()
        {
            int CurrentYear = DateTime.Today.Year;
            int PreviousYear = DateTime.Today.Year - 1;
            int NextYear = DateTime.Today.Year + 1;
            string PreYear = PreviousYear.ToString();
            string NexYear = NextYear.ToString();
            string CurYear = CurrentYear.ToString();
            string FinYear = null;

            if (DateTime.Today.Month > 3)
            {
                FinYear = CurYear + "-" + NexYear;
            }
            else
            {
                FinYear = PreYear + "-" + CurYear;
            }
            return FinYear;
        }
        public bool AddConsultant3(ConsulatntExamination3 consultantExamination3)
        {
            SqlCommand cmdAddPAtient = new SqlCommand();
            cmdAddPAtient.CommandText = "sp_InsertConsultatntExamination3";
            cmdAddPAtient.CommandType = System.Data.CommandType.StoredProcedure;
            cmdAddPAtient.Connection = conString;
            cmdAddPAtient.Parameters.AddWithValue("@PatientId", consultantExamination3.PatientId);
            cmdAddPAtient.Parameters.AddWithValue("@ConsultantId", consultantExamination3.ConsultantId);
            cmdAddPAtient.Parameters.AddWithValue("@RatinoscopyPENTOL", consultantExamination3.RatinoscopyPENTOL);
            cmdAddPAtient.Parameters.AddWithValue("@RatinoscopyTROPYCALCYPLUS", consultantExamination3.RatinoscopyTROPYCALCYPLUS);
            cmdAddPAtient.Parameters.AddWithValue("@RatinoscopyATROPIN", consultantExamination3.RatinoscopyATROPIN);

            //=============================================
            cmdAddPAtient.Parameters.AddWithValue("@PupilOD1", consultantExamination3.PupilOD1);
            cmdAddPAtient.Parameters.AddWithValue("@PupilOD2", consultantExamination3.PupilOD2);
            cmdAddPAtient.Parameters.AddWithValue("@PupilOS1", consultantExamination3.PupilOS1);
            cmdAddPAtient.Parameters.AddWithValue("@PupilOS2", consultantExamination3.PupilOS2);
            cmdAddPAtient.Parameters.AddWithValue("@RappOS", consultantExamination3.RappOS);
            cmdAddPAtient.Parameters.AddWithValue("@RappOD", consultantExamination3.RappOD);
            cmdAddPAtient.Parameters.AddWithValue("@AmslergridOS", consultantExamination3.AmslergridOS);
            cmdAddPAtient.Parameters.AddWithValue("@AmslergridOD", consultantExamination3.AmslergridOD);
            cmdAddPAtient.Parameters.AddWithValue("@SyringOD", consultantExamination3.SyringOD);
            cmdAddPAtient.Parameters.AddWithValue("@SyringOS", consultantExamination3.SyringOS);

            //=============================================
            conString.Open();
            int result = cmdAddPAtient.ExecuteNonQuery();
            conString.Close();
            if (result > 0)
                return true;
            return false;
        }
    }
    
}
