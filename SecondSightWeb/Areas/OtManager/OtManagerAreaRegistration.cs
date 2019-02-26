using System.Web.Mvc;

namespace SecondSightWeb.Areas.OtManager
{
    public class OtManagerAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "OtManager";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "OtManager_default",
                "OtManager/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}