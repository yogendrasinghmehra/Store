using System.Web.Mvc;

namespace Store.Web.Areas.Vendor
{
    public class VendorAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Vendor";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Vendor_default",
                "Vendor/{controller}/{action}/{id}",
                new {controller="Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] {"Store.Web.Areas.Vendor.Controllers"}
            );
        }
    }
}