using Microsoft.AspNetCore.Mvc;

namespace TodoList.Api.Controllers
{
    [Controller]
    public class MyTaskController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


    }
}
