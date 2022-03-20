using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sanctuary.Domain;

namespace Sanctuary.Presentation.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(BaseContext context) : base(context) { }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(string message)
        {
            ViewBag["Message"] = message;
            return View();
        }
    }
}
