using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MalayanBank.OnlineBanking.Models
{
    public class ViewBagFilter : IActionFilter
    {
        private static readonly string Enabled = "Enabled";
        private static readonly string Disabled = string.Empty;

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.Controller is Controller controller)
            {
                // SmartAdmin Toggle Features
                controller.ViewBag.AppSidebar = Enabled;
                controller.ViewBag.AppHeader = Enabled;
                controller.ViewBag.AppLayoutShortcut = Enabled;
                controller.ViewBag.AppFooter = Enabled;
                controller.ViewBag.ShortcutMenu = Enabled;
                controller.ViewBag.ChatInterface = Enabled;
                controller.ViewBag.LayoutSettings = Enabled;

                // SmartAdmin Default Settings
                controller.ViewBag.App = "Malayan Bank Online Banking";
                controller.ViewBag.AppName = "Malayan Bank Online Banking";
                controller.ViewBag.AppFlavor = "ASP.NET Core 3.1";
                controller.ViewBag.AppFlavorSubscript = ".NET Core 3.1";
                controller.ViewBag.IconPrefix = "fal";
                controller.ViewBag.User = "Ken Tsutsui";
                controller.ViewBag.Email = "astsutsui@trudi.tech";
                controller.ViewBag.Twitter = "";
                controller.ViewBag.Avatar = "user-icon.jpg";
                controller.ViewBag.Version = "1.0";
                controller.ViewBag.ThemeVersion = "1.0";
                controller.ViewBag.Bs4v = "4.3";
                controller.ViewBag.Logo = "malayanheader.png";
                controller.ViewBag.LogoM = "malayanheader.png";
                controller.ViewBag.Copyright = "2020 © Malayan Bank by&nbsp;<a href='https://trudi.tech/' class='text-primary fw-500' title='gotbootstrap.com' target='_blank'>https://www.malayanbank.com/</a>";
                controller.ViewBag.CopyrightInverse = "2020 © Malayan Bank by&nbsp;<a href='https://trudi.tech/' class='text-white opacity-40 fw-500' title='gotbootstrap.com' target='_blank'>https://www.malayanbank.com/</a>";
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
