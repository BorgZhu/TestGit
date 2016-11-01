using System.Web.Mvc;

namespace XHWebApi.Areas.Trading
{
    public class DisplayAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "XHWebApi";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "XHWebApi_default",
                "XHWebApi/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
