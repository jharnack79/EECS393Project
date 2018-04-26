using System.Diagnostics;
using GetThiqqq.Models;
using Microsoft.AspNetCore.Mvc;
using GetThiqqqBase.Models;

namespace GetThiqqq.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var userID = 0;
            if (Request.Cookies["userAccountId"] != null)
                userID = int.Parse(Request.Cookies["userAccountId"]);
            var viewModelBase = new ViewModelBase
            {
                UserId = userID
            };
            return View(viewModelBase);
        }

        public IActionResult About()
        {

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
