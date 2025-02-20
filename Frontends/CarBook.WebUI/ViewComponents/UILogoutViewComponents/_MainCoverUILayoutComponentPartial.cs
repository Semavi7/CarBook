using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.UILogoutViewComponents
{
    public class _MainCoverUILayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
