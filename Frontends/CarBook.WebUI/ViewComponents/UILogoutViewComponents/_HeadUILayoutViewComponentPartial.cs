using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.UILogoutViewComponents
{
    public class _HeadUILayoutViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
