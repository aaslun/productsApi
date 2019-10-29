using System.Web.Http;
using Umbraco.Core.Composing;

namespace ProductApi.Composing
{
    public class WebApiComponent : IComponent
    {
        public void Initialize()
        {
            // enable attribute routing
            GlobalConfiguration.Configuration.MapHttpAttributeRoutes();
        }

        public void Terminate()
        {
        }
    }
}
