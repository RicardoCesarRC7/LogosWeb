using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogosWeb.Controllers
{
    public class SobreController : Controller
    {
        // GET: SobreController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Estudio()
        {
            return View();
        }
    }
}
