using System.Web.Http;
using Umbraco.Core.Composing;

namespace ProductApi.Composing
{
    /**
     * <summary>20191030: Attribute routing disabled.
     * Using traditional ASP.NET Web Api routing instead.
     * Web Api 2 attribute routing causes problems with UmbracoApiController.
     * The actual routes works but throws error in Umbraco admin.
     * It seems that UmbracoApiController registers attribute routes multiple times
     * which causes a route naming conflict.
     * Even though it handles this error silently in the API it is not considered
     * acceptable for a customer production app.
     * I have not been able to find any solution or workarounds yet.
     * Feel free to look into this or discuss the issue with me.
     * andreas.wall@tromb.com
     * .</summary>
     */
    public class WebApiComponent : IComponent
    {
        public void Initialize()
        {
            // Attribute routing (Disabled. See comment above.)
            // GlobalConfiguration.Configuration.MapHttpAttributeRoutes();
            GlobalConfiguration.Configuration.Routes.MapHttpRoute(
                name: "ProductApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
        }

        public void Terminate()
        {
        }
    }
}
