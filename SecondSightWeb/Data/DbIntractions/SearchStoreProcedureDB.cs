using SecondSightSouthendEyeCentre.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Data.DbIntractions
{
    public class SearchStoreProcedureDB<T> where T : class
    {
        private readonly SecondSightDbContext _dataContext;
        string errorMessage = string.Empty;
        public SearchStoreProcedureDB()
        {
            _dataContext = new SecondSightDbContext();
        }
        public virtual IEnumerable<T> GetAppointmentsbyPatientId(int id)
        {
            //var PatientId = new SqlParameter("@PatientId", id);
            return _dataContext.Database.SqlQuery<T>("dbo.sp_GetAppoinmentsByPatientId @PatientId", new SqlParameter("@PatientId", id)).ToList();
        }
        public virtual IEnumerable<T> GetAdjustmentDetailsAndByBillId(int? id)
        {
            //var PatientId = new SqlParameter("@PatientId", id);
            return _dataContext.Database.SqlQuery<T>("dbo.sp_GetAdjustmentDetailsAndByBillId @BillId", new SqlParameter("@BillId", id)).ToList();
        }
        public virtual IEnumerable<T> GetSumOfOtChargeByOtChargeId(int id)
        {
            return _dataContext.Database.SqlQuery<T>("dbo.sp_GetSumOfOtChargeByOtChargeId @OtChargeId", new SqlParameter("@OtChargeId", id));
        }
        public virtual IEnumerable<T> GetOperationList()
        {
            return _dataContext.Database.SqlQuery<T>("dbo.sp_GetOperationCode @patientId", new SqlParameter("@patientId", int.Parse("-1"))).ToList();
        }
        public virtual IEnumerable<T> GetAppointments30Days()
        {
            return _dataContext.Database.SqlQuery<T>("dbo.sp_GetAppointents_Last30_Days").ToList();
        }
        public virtual IEnumerable<T> GetBills30Days()
        {
            return _dataContext.Database.SqlQuery<T>("dbo.sp_Bills_Last_30_Days").ToList();
        }
        public virtual IEnumerable<T> GetOperationSuccessRate()
        {
            return _dataContext.Database.SqlQuery<T>("dbo.sp_GetOperation_Success_Rate").ToList();
        }
        public virtual IEnumerable<T> GetRefundBillDetailsAndByBillId(int id)
        {
            //var PatientId = new SqlParameter("@PatientId", id);
            return _dataContext.Database.SqlQuery<T>("dbo.sp_GetRefundBillDetailsAndByBillId @BillId", new SqlParameter("@BillId", id)).ToList();
        }

    }
}