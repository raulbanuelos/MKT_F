using MKT.Logica.Models;
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
        public ActionResult Ingresar([Bind(Include = "Usuario,Contrasena")] DO_Usuario persona)
        {
            if (persona.Contrasena == "admin")
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("LoginMTK");
            }
        }
    }
}