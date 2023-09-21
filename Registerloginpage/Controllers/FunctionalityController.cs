using Microsoft.AspNetCore.Mvc;

namespace Registerloginpage.Controllers
{
    public class FunctionalityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
     
    }
}
