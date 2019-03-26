using MKT.Logica;
using MKT.Logica.Models;
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
            return View();
        }

        [HttpPost]
        public JsonResult ConsultarCruce(string fechaInicial, string fechaFinal)
        {
            List<DO_Resumen> resumens = DataManager.GetResumen(fechaInicial,fechaFinal);

            var jsonResult = Json(resumens, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;

        }
    }
}