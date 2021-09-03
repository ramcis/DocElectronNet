using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using VarDoc.Models;
using VarDoc.ViewModels;

namespace VarDoc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DocDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public HomeController(ILogger<HomeController> logger, DocDbContext context, IWebHostEnvironment _webHostEnvironment)
        {
            _logger = logger;
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public JsonResult GetPeople(int n)
        {
            DateTime moment = DateTime.Now;
            var today = moment.Year;
            var regio = _context.Patient.ToList();

            var groupedResult = regio.GroupBy(o => o.date_naissance.Year).ToList().
               Select(grp => new
               {
                   Name = ((today - _context.Patient.Find(grp.Key).date_naissance.Year)).ToString(),
                   Total = grp.Count(x => Convert.ToBoolean(x.id_patient))
               }).OrderByDescending(res => res.Total).Take(40).ToList();
            string jzon = JsonConvert.SerializeObject(groupedResult);
            return Json(jzon);
        }
        public JsonResult GetStats(int n)
        {
            DateTime moment = DateTime.Now;
            var today = moment.Year;
            var regio = _context.Patient.ToList();
            var groupedResult = regio.GroupBy(o => o.date_naissance.Year).ToList().
                Select(grp => new
                {
                    Name = ((today - _context.Patient.Find(grp.Key).date_naissance.Year)).ToString(),
                    Total = grp.Count(x => Convert.ToBoolean(x.id_patient))
                }).OrderByDescending(res => res.Total).ToList();
            string jzon = JsonConvert.SerializeObject(groupedResult);
            return Json(jzon);

        }


        public IActionResult Index()
        {
            string ipAdr = string.Empty;
            IPAddress ip = Request.HttpContext.Connection.RemoteIpAddress;
            if (ip != null)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
                {
                    ip = Dns.GetHostEntry(ip).AddressList.First(x =>
                    x.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);
                }
                ipAdr = ip.ToString();
            }
          //  var ip = HttpContext.Connection.RemoteIpAddress.ToString();
            Console.WriteLine("My ip address is:" + ipAdr);
            //  var ip = _accessor.ActionContext.HttpContext.Connection.RemoteIpAddress.ToString();
            try
            {
                return View();

            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        public IActionResult Stats()
        {
            try
            {
                return View();

            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        public IActionResult ConvertFile()
        {

            return View();
        }

        [HttpPost]
        public IActionResult ConvertFile(ConxString cnx)
        {
            JObject obj = (JObject)JToken.FromObject(cnx) ;
            CreateFile(obj);
            return RedirectToAction(nameof(Index));
        }

        private void CreateFile(JObject obj)
        {
            string uploadDir = Path.GetFullPath("appsettings.json");
            var fileName = "appsettings.json";
            string filePath = Path.GetFullPath(fileName);
            System.IO.File.WriteAllText(filePath, obj.ToString());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
