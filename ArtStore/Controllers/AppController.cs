using Microsoft.AspNetCore.Mvc;
using System;

namespace ArtStore.Controllers
{
    public class AppController : Controller
    {
        public IActionResult Index()
        {
            throw new InvalidProgramException("Bad things happen to good developers");
            return View();
        }
    }
}
