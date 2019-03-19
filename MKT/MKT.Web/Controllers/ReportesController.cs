using MKT.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MKT.Web.Controllers
{
    public class ReportesController : Controller
    {
        public ActionResult GetResumen()
        {
            return View(DataManager.GetResumen());
        }
    }
}