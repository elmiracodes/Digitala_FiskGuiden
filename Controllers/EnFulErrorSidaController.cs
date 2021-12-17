using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


// Till denna sida (Se Index) kommer användaren vid error tack vare Try-Catch.

namespace Digitala_FiskGuiden.Controllers
{
    public class EnFulErrorSidaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
