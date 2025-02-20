using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.UILogoutViewComponents
{
    public class _ScriptUILayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
