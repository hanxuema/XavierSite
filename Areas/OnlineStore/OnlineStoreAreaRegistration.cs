using System.Web.Mvc;

namespace XavierSite.Areas.OnlineStore
{
    public class OnlineStoreAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "OnlineStore";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "OnlineStore_default",
                "OnlineStore/{controller}/{action}/{id}",
                new {controller ="Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
