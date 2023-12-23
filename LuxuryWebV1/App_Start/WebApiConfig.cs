using System.Web.Http;
using System.Web.Http.Cors;
using System.Net.Http.Headers;

namespace LuxuryWebV1
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configure CORS Policy for API 
            EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "*");
            // Web API configuration and services

            // Config for accepting application/x-www-form-urlencoded
            config.Formatters.JsonFormatter.
                SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/x-www-form-urlencoded"));
            config.Formatters.Insert(0, config.Formatters.JsonFormatter);
            // Web API routes
            config.MapHttpAttributeRoutes();
            config.EnableCors(cors);
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
