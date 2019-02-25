using MKT.Logica;
using MKT.Logica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MKT.Web.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        public ActionResult AltaUsuario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveEmpleado([Bind(Include = "CodigoNomina,Nombre,Entidad,IsActive,FechaInicio,FechaTermino")] DO_Gerente gerente)
        {
            if (DataManager.InsertGerente(gerente) > 0)
            {
                return RedirectToAction("ViewAllEmpleado");
            }
            else
            {
                return RedirectToAction("Index","Home");
            }
        }

        public ActionResult ViewAllEmpleado()
        {
            return View(DataManager.GetAllGerentes());
        }

        public ActionResult EditarEmpleado(int idGerente)
        {
            return View(DataManager.GetGerente(idGerente));
        }

        [HttpPost]
        public ActionResult SaveChangeEmpleado([Bind(Include = "IdGerente,CodigoNomina,Nombre,Entidad,IsActive,FechaInicio,FechaTermino")] DO_Gerente gerente)
        {
            if (DataManager.UpdateGerente(gerente) > 0)
            {
                return RedirectToAction("ViewAllEmpleado");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult ViewDelete(int idGerente)
        {
            return View(DataManager.GetGerente(idGerente));
        }

        [HttpPost]
        public ActionResult SaveDeleteEmpleado([Bind(Include = "IdGerente,CodigoNomina,Nombre,Entidad,IsActive,FechaInicio,FechaTermino")] DO_Gerente gerente)
        {
            if (DataManager.DeleteGerente(gerente.IdGerente) > 0)
            {
                return RedirectToAction("ViewAllEmpleado");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}