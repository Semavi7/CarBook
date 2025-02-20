using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.UILogoutViewComponents
{
    public class _NavbarUILayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
