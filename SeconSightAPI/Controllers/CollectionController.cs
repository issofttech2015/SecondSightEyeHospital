using SecondSightSouthendEyeCentre.Service.Implementation;
using SecondSightSouthendEyeCentre.Service.Interfaces;
using SecondSightWeb.Common_Controle;
using SecondSightWeb.Service.Implementation;
using SecondSightWeb.Service.Interfaces;
using SeconSightAPI.Models;
using SeconSightAPI.Models.EditModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace SeconSightAPI.Controllers
{
    [RoutePrefix("API")]
    public class CollectionController : ApiController
    {
        private readonly SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SecondSightDbContext"].ConnectionString);
        [Route("GetCollectionDetails")]
        [HttpPost]
        [ResponseType(typeof(List<CollectionDetailsViewModel>))]
        public List<CollectionDetailsViewModel> GetCollectionDetilsByRole(EmployeeDetails objEmeplyee)
        {
            List<CollectionDetailsViewModel> lstCollectionDetailsViewModel = new List<CollectionDetailsViewModel>();
            if (objEmeplyee != null)
            {
                using (con)
                {
                    //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SecondSightDbContext"].ConnectionString);
                    SqlCommand cmdFetchCollectionDetails = new SqlCommand("sp_GetAllCollectionDetails", con);
                    cmdFetchCollectionDetails.Parameters.AddWithValue("@EmployeeId", Common_Methods.Decrypt(objEmeplyee.EmployeeId));
                    cmdFetchCollectionDetails.Parameters.AddWithValue("@RoleId", Common_Methods.Decrypt(objEmeplyee.RoleId));
                    cmdFetchCollectionDetails.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader drFetchcollection = cmdFetchCollectionDetails.ExecuteReader();
                    while (drFetchcollection.Read())
                    {
                        lstCollectionDetailsViewModel.Add(new CollectionDetailsViewModel
                        {
                            EmployeeName = drFetchcollection[0].ToString(),
                            PatientName = drFetchcollection[1].ToString(),
                            BillCode = drFetchcollection[2].ToString(),
                            BillDate = DateTime.Parse(drFetchcollection[3].ToString()),
                            TotalAmount = drFetchcollection[4].ToString(),
                            ConsessionAmount = drFetchcollection[5].ToString(),
                            AoountPaid = drFetchcollection[6].ToString(),
                            AmountDue = drFetchcollection[7].ToString(),
                            ModeofPayment = drFetchcollection[8].ToString(),
                            PatCode = drFetchcollection[9].ToString(),
                            Purpose= drFetchcollection[10].ToString()
                        });
                    }
                    con.Close();
                }
            }
            return lstCollectionDetailsViewModel;
        }

    }
}
