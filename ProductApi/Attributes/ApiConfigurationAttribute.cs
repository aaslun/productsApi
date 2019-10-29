using System;
using System.Net.Http.Formatting;
using System.Web.Http.Controllers;
using Newtonsoft.Json.Serialization;

namespace ProductApi.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ApiConfigurationAttribute : Attribute, IControllerConfiguration
    {
        public void Initialize(
            HttpControllerSettings controllerSettings,
            HttpControllerDescriptor controllerDescriptor)
        {
            if (controllerSettings != null)
            {
                controllerSettings.Formatters.Clear();
                controllerSettings.Formatters.Add(new JsonMediaTypeFormatter());
                controllerSettings.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            }
        }
    }
}
