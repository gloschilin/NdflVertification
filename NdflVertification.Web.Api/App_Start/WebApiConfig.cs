using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace NdflVertification.Web.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            //config.SuppressDefaultHostAuthentication();
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );



            //Clear all the formatters from the config.Formatters collection and just add back the XmlMediaTypeFormatter.
            //That will ensure you only have one available formatter
            //http://forums.asp.net/t/1804419.aspx/2/10?how+to+set+a+Web+API+REST+service+to+always+return+XML+not+JSON
            GlobalConfiguration.Configuration.Formatters.Clear();
            GlobalConfiguration.Configuration.Formatters.Add(new System.Net.Http.Formatting.XmlMediaTypeFormatter());
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.UseXmlSerializer = true;
        }
    }
}
