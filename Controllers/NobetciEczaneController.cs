using Microsoft.AspNetCore.Mvc;

namespace Eczane_Stok.Controllers
{
    public class NobetciEczaneController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
