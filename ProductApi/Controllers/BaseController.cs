using System;
using System.Globalization;
using System.Linq;
using ProductApi.Attributes;
using Umbraco.Web.WebApi;

namespace ProductApi.Controllers
{
    [ApiConfiguration]
    [ApiActionException]
    public class BaseController : UmbracoApiController
    {
        /// <summary>
        /// Get culture based on the Accept-Language header.
        /// </summary>
        /// <returns>The first language matching an enabled language
        /// in Umbraco or the default language if no match.</returns>
        protected string GetRequestedCulture()
        {
            var acceptLanguages = Request.Headers.AcceptLanguage;
            var allLanguages = Services.LocalizationService.GetAllLanguages();

            // check for exact matches, "en == en", "en-US == en-US"
            foreach (var acceptLanguage in acceptLanguages)
            {
                var umbracoLanguage = allLanguages.FirstOrDefault(x =>
                    x.IsoCode.Equals(acceptLanguage.Value, StringComparison.InvariantCultureIgnoreCase));

                if (umbracoLanguage != null)
                {
                    return umbracoLanguage.IsoCode.ToLower(CultureInfo.CurrentCulture);
                }
            }

            // check language matches, "en == en", "en == en-US"
            foreach (var acceptLanguage in acceptLanguages)
            {
                var umbracoLanguage = allLanguages.FirstOrDefault(x =>
                    x.IsoCode.StartsWith(acceptLanguage.Value, StringComparison.InvariantCultureIgnoreCase));

                if (umbracoLanguage != null)
                {
                    return umbracoLanguage.IsoCode.ToLower(CultureInfo.CurrentCulture);
                }
            }

            // default language
            return allLanguages.First(x => x.IsDefault).IsoCode.ToLower(CultureInfo.CurrentCulture);
        }
    }
}
