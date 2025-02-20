using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.UILogoutViewComponents
{
    public class _FooterUILayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
