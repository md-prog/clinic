using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ClinicaCloudPlatform.API.Controllers
{
    [Authorize]
    public class MainController : Controller
    {
        public MainController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
