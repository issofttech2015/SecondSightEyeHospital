﻿using System.Web.Http;
using System.Web.Http.Cors;


namespace SeconSightAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            var corsAttribute = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(corsAttribute);
        }
    }
}