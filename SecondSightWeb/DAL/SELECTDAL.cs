using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre
{
    public class SELECTDAL
    {
        #region Singleton Object
        private static SELECTDAL instance;
        private static object syncObject = new Object();
        private SELECTDAL() { }

        public static SELECTDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncObject)
                    {
                        if (instance == null)
                        {
                            instance = new SELECTDAL();
                        }
                    }
                }
                return instance;
            }
        }
        #endregion
        private readonly SqlConnection conString = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SecondSightDbContext"].ConnectionString);

        public List<Roles> GetUserRoles()
        {
            List<Roles> roles = new List<Roles>();

            SqlCommand cmdRoles = new SqlCommand("Select * from Role", conString);

            conString.Open();
            SqlDataReader drRoles = cmdRoles.ExecuteReader();
            while (drRoles.Read())
            {
                roles.Add(new Roles
                {
                    Id = int.Parse(drRoles[0].ToString()),
                    RoleName = drRoles[1].ToString()
                });
            }
            conString.Close();
            return roles;

        }
        public List<Departments> GetDepartment()
        {
            List<Departments> departments = new List<Departments>();

            SqlCommand cmdRoles = new SqlCommand("Select * from tblDepartment", conString);

            conString.Open();
            SqlDataReader drRoles = cmdRoles.ExecuteReader();
            while (drRoles.Read())
            {
                departments.Add(new Departments
                {
                    DepartmentId = int.Parse(drRoles[0].ToString()),
                    DepartmentName = drRoles[1].ToString(),
                    DepartmentLocation = drRoles[2].ToString(),
                    ManagerId = int.Parse(drRoles[3].ToString())
                });
            }
            conString.Close();
            return departments;
        }
        public List<EmployeeShortInfo> GetEmployeebyRole(int Id)
        {
            List<EmployeeShortInfo> employees = new List<EmployeeShortInfo>();

            SqlCommand cmdRoles = new SqlCommand("Select tblEmployee.EmployeeId,FirstName,LastName from tblEmployee inner join tblEmployeeLog on tblEmployee.EmployeeId=tblEmployeeLog.EmployeeId where RoleId=@RoleId", conString);
            cmdRoles.Parameters.AddWithValue("@RoleId", Id);
            conString.Open();
            SqlDataReader drRoles = cmdRoles.ExecuteReader();
            while (drRoles.Read())
            {
                employees.Add(new EmployeeShortInfo
                {
                    EmployeeId = int.Parse(drRoles[0].ToString()),
                    EmployeeName = drRoles[1].ToString() + " " + drRoles[2].ToString()
                });
            }
            conString.Close();
            return employees;
        }
        public List<ProcedureRate> ProcedureRates()
        {
            List<ProcedureRate> procedureRates = new List<ProcedureRate>();

            SqlCommand cmdRoles = new SqlCommand("Select * from ProcedureRate", conString);
            conString.Open();
            SqlDataReader drRoles = cmdRoles.ExecuteReader();
            while (drRoles.Read())
            {
                procedureRates.Add(new ProcedureRate
                {
                    Id = int.Parse(drRoles[0].ToString()),
                    ProcedureName = drRoles[1].ToString(),
                    Rate = decimal.Parse(drRoles[2].ToString())
                });
            }
            conString.Close();
            return procedureRates;
        }
        public List<ChieifComplainList> CheifComplainLists()
        {
            List<ChieifComplainList> chieifComplainList = new List<ChieifComplainList>();

            SqlCommand cmdRoles = new SqlCommand("Select * from CheifComplainList", conString);
            conString.Open();
            SqlDataReader drRoles = cmdRoles.ExecuteReader();
            while (drRoles.Read())
            {
                chieifComplainList.Add(new ChieifComplainList
                {
                    ChieifComplainId = int.Parse(drRoles[0].ToString()),
                    ChieifComplainName = drRoles[1].ToString()
                });
            }
            conString.Close();
            return chieifComplainList;
        }
        public List<Disease> Diseases()
        {
            List<Disease> disease = new List<Disease>();

            SqlCommand cmdRoles = new SqlCommand("Select * from Diseases", conString);
            conString.Open();
            SqlDataReader drRoles = cmdRoles.ExecuteReader();
            while (drRoles.Read())
            {
                disease.Add(new Disease
                {
                    DiseaseId = int.Parse(drRoles[0].ToString()),
                    DiseaseName = drRoles[1].ToString()
                });
            }
            conString.Close();
            return disease;
        }
        public PatientShortInfo PatientGetById(string PaitientId)
        {
            PatientShortInfo patientShortInfo = new PatientShortInfo();
            SqlCommand cmdRoles = new SqlCommand("Select PatientId,FirstName,LastName,MiddleName,Gender,DateofBirth,Age,Contact from tblPatient where PatCode=@Pid", conString);
            cmdRoles.Parameters.AddWithValue("@Pid", PaitientId);
            conString.Open();
            SqlDataReader drRoles = cmdRoles.ExecuteReader();
            while (drRoles.Read())
            {
                patientShortInfo.PatitentId = int.Parse(drRoles[0].ToString());
                patientShortInfo.FirstName = drRoles[1].ToString();
                patientShortInfo.LastName = drRoles[2].ToString();
                patientShortInfo.MiddeleName = drRoles[3].ToString();
                patientShortInfo.Gender = drRoles[4].ToString();
                patientShortInfo.DateofBirth = DateTime.Parse(drRoles[5].ToString());
                patientShortInfo.Age = int.Parse(drRoles[6].ToString());
                patientShortInfo.Contact = decimal.Parse(drRoles[7].ToString());

            }
            conString.Close();
            return patientShortInfo;
        }
        public List<EmployeeShortInfo> LoadPatientIds()
        {
            List<EmployeeShortInfo> patientIds = new List<EmployeeShortInfo>();
            SqlCommand cmdRoles = new SqlCommand("Select PatientId,PatCode from tblPatient", conString);

            conString.Open();
            SqlDataReader drRoles = cmdRoles.ExecuteReader();
            while (drRoles.Read())
            {
                patientIds.Add(new EmployeeShortInfo
                {
                    EmployeeId = int.Parse(drRoles[0].ToString()),
                    EmployeeName = drRoles[1].ToString()
                });
            }
            conString.Close();
            return patientIds;
        }
        public List<Disease> Alergies()
        {
            List<Disease> disease = new List<Disease>();

            SqlCommand cmdRoles = new SqlCommand("Select * from Alergy", conString);
            conString.Open();
            SqlDataReader drRoles = cmdRoles.ExecuteReader();
            while (drRoles.Read())
            {
                disease.Add(new Disease
                {
                    DiseaseId = int.Parse(drRoles[0].ToString()),
                    DiseaseName = drRoles[1].ToString()
                });
            }
            conString.Close();
            return disease;
        }
        public Tuple<string, string, string, string, string, string, string, Tuple<string>> GetPatientDetails(string name, string mobileNumber)
        {
            string patCode = "", patName = "", address = "", adhar = "", contact = "", patentId = "", age = "", gender = "";
            SqlCommand cmdPat = new SqlCommand("sp_GetPatientByTreatOrNameOrMobile", conString);
            cmdPat.Parameters.AddWithValue("@Name", name);
            cmdPat.Parameters.AddWithValue("@MobileNo", mobileNumber);
            cmdPat.CommandType = System.Data.CommandType.StoredProcedure;
            conString.Open();
            SqlDataReader dr = cmdPat.ExecuteReader();
            while (dr.Read())
            {
                patName = dr[0].ToString();
                patCode = dr[1].ToString();
                address = dr[2].ToString();
                adhar = dr[3].ToString();
                contact = dr[4].ToString();
                patentId = dr[5].ToString();
                age = dr[6].ToString();
                gender = dr[7].ToString();
            }
            conString.Close();
            return new Tuple<string, string, string, string, string, string, string, Tuple<string>>(patName, patCode, address, adhar, contact, patentId, age, new Tuple<string>(gender));
        }
        public List<PatientDetails> GetEmployeeDetailsInDetails(string name, string mobileNumber)
        {
            List<PatientDetails> employeeDetails = new List<PatientDetails>();
            SqlCommand cmdPat = new SqlCommand("sp_GetPatientByTreatOrNameOrMobile", conString);
            cmdPat.Parameters.AddWithValue("@Name", name);
            cmdPat.Parameters.AddWithValue("@MobileNo", mobileNumber);
            cmdPat.CommandType = System.Data.CommandType.StoredProcedure;
            conString.Open();
            SqlDataReader dr = cmdPat.ExecuteReader();
            while (dr.Read())
            {
                employeeDetails.Add(new PatientDetails()
                {
                    patName = dr[0].ToString(),
                    patCode = dr[1].ToString(),
                    address = dr[2].ToString(),
                    adhar = dr[3].ToString(),
                    contact = dr[4].ToString(),
                    patentId = dr[5].ToString(),
                    age = dr[6].ToString(),
                    gender = dr[7].ToString()
                });
            }
            conString.Close();
            return employeeDetails;
        }
        public string GetPassWord(int UserId, string MobileNo, string userName)
        {
            string password = "";
            SqlCommand cmdPassword = new SqlCommand("sp_GetPassword", conString);
            cmdPassword.CommandType = System.Data.CommandType.StoredProcedure;
            cmdPassword.Parameters.AddWithValue("@UserId", UserId);
            if (MobileNo == "")
                cmdPassword.Parameters.AddWithValue("@MobileNo", DBNull.Value);
            else
                cmdPassword.Parameters.AddWithValue("@MobileNo", MobileNo);
            cmdPassword.Parameters.AddWithValue("@UserName", userName);
            conString.Open();
            SqlDataReader dr = cmdPassword.ExecuteReader();
            if (dr.HasRows == true)
            {
                while (dr.Read())
                {
                    password = dr[0].ToString();
                }
            }
            if (dr.HasRows == false)
            {
                password = "Wrong User Name/Employee Id";
            }
            return password;
        }
        public List<Disease> SystematicDiseases()
        {
            List<Disease> disease = new List<Disease>();

            SqlCommand cmdRoles = new SqlCommand("Select * from SystemicDisease", conString);
            conString.Open();
            SqlDataReader drRoles = cmdRoles.ExecuteReader();
            while (drRoles.Read())
            {
                disease.Add(new Disease
                {
                    DiseaseId = int.Parse(drRoles[0].ToString()),
                    DiseaseName = drRoles[1].ToString()
                });
            }
            conString.Close();
            return disease;
        }
        public string GetDueAmount(int appointmentId)
        {
            string ammount = "0.00";
            SqlCommand cmdPat = new SqlCommand("sp_GetAmountDuebyAppoinmetId", conString);
            cmdPat.Parameters.AddWithValue("@AppointmentId", appointmentId);
            cmdPat.CommandType = System.Data.CommandType.StoredProcedure;
            conString.Open();
            SqlDataReader dr = cmdPat.ExecuteReader();
            while (dr.Read())
            {
                ammount = dr[0].ToString();
            }
            conString.Close();
            return ammount;
        }
    }
}