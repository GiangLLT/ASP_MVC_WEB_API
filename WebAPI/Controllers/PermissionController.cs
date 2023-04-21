using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class PermissionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
