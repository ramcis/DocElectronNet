using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VarDoc.Controllers
{
    public class Calendar : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
