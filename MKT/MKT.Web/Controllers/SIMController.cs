using MKT.Logica;
using MKT.Logica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MKT.Web.Controllers
{
    public class SIMController : Controller
    {
        public ActionResult VerSIMS()
        {
            return View(DataManager.GetAllSIM());
        }

        public ActionResult AltaSIM()
        {
            ViewBag.Empleados = convert(DataManager.GetAllGerentes());
            return View();
        }

        public ActionResult AltaSIM2(string idOperador, string idGerente, string fechaSolicitud, string fechaEntrega)
        {
            ViewBag.Empleados = convert(DataManager.GetAllGerentes());

            DO_SIM dO_SIM = new DO_SIM();
            dO_SIM.SIM = "";
            dO_SIM.gerenteSelected = idGerente;
            dO_SIM.operadorSelected = idOperador;
            dO_SIM.FechaSolicitud = Convert.ToDateTime(fechaSolicitud);
            dO_SIM.FechaEntrega = Convert.ToDateTime(fechaEntrega);

            return View("AltaSIM", dO_SIM);
        }

        public ActionResult SaveSIM([Bind(Include = "SIM,operadorSelected")] DO_SIM dO_SIM)
        {
            DO_Gerente operador = DataManager.GetGerente(Convert.ToInt32(dO_SIM.operadorSelected));
            DO_Gerente gerente = DataManager.GetGerente(Convert.ToInt32(dO_SIM.gerenteSelected));

            dO_SIM.operador = operador;
            dO_SIM.gerente = gerente;

            DataManager.InsertSIM(dO_SIM);

            dO_SIM.SIM = "EL NUEVO";
            
            return RedirectToAction("AltaSIM2", new { idOperador = dO_SIM.operadorSelected , idGerente = dO_SIM.gerenteSelected, fechaSolicitud = dO_SIM.FechaSolicitud, fechaEntrega =  dO_SIM.FechaEntrega });
        }

        public ActionResult SaveChangeSIM([Bind(Include = "ID_SIM,FechaSolicitud,FechaEntrega,operadorSelected,gerenteSelected,idSIMGerente,SIM")] DO_SIM dO_SIM)
        {
            if (dO_SIM.idSIMGerente == 0)
            {
                DataManager.InsertSIMGerente(dO_SIM.FechaEntrega, dO_SIM.FechaSolicitud, dO_SIM.ID_SIM, Convert.ToInt32(dO_SIM.gerenteSelected));
            }
            else
            {
                DataManager.UpdateSIMGerente(dO_SIM.FechaEntrega, dO_SIM.FechaSolicitud, dO_SIM.ID_SIM, Convert.ToInt32(dO_SIM.gerenteSelected), dO_SIM.idSIMGerente);
            }

            return RedirectToAction("VerSIMS");
        }

        public ActionResult EditarSIM(int idSIM)
        {
            DO_SIM dO_SIM = DataManager.GetSIM(idSIM);
            List<SelectListItem> list = new List<SelectListItem>();
            list = convert(DataManager.GetAllGerentes());
            dO_SIM.operadorSelected = dO_SIM.operador.IdGerente.ToString();
            if (dO_SIM.gerente is null)
            {
                dO_SIM.gerenteSelected = "0";
            }
            else
            {
                dO_SIM.gerenteSelected = dO_SIM.gerente.IdGerente.ToString();
            }

            ViewBag.Empleados = list;
            return View(dO_SIM);
        }

        private List<SelectListItem> convert(List<DO_Gerente> dO_Gerentes)
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();

            foreach (var item in dO_Gerentes)
            {
                SelectListItem selectListItem = new SelectListItem();
                
                selectListItem.Text = item.Nombre;
                selectListItem.Value = item.IdGerente.ToString();

                selectListItems.Add(selectListItem);
            }

            return selectListItems;
        }
    }
}