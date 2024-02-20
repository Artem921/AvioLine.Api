using Microsoft.AspNetCore.Mvc;

namespace AvioLine.Components
{
    public class UserInfoViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke() => User.Identity?.IsAuthenticated == true
            ? View("UserInfo")
            : View("Default");
    }
}
