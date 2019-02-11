using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MKT.Web.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult LoginMTK()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ingresar(string usuario,string contrasena)
        {

            if (contrasena == "admin")
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Index");
            }
        }
    }
}