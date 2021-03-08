using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SocialNetworking_Kata.Web
{
	public class WebApiConfig
   {
      public static void Register(HttpConfiguration config)
      {
         config.MapHttpAttributeRoutes();

         config.Routes.MapHttpRoute(
             name: "DefaultApi",
             // /api/userprofile
             routeTemplate: "api/{controller}/{id}",
             defaults: new { id = RouteParameter.Optional }
         );
      }
   }
}