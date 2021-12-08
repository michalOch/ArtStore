using Microsoft.AspNetCore.Mvc;
using System;

namespace ArtStore.Controllers
{
    public class AppController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
