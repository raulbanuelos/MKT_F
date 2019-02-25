using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MKT.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IrAltaUsuario()
        {
            return RedirectToAction("AltaUsuario", "Empleado");
        }

        public ActionResult IrViewAllGerentes()
        { 
            return RedirectToAction("ViewAllEmpleado", "Empleado");
        }
    }
}