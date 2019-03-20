using MKT.DataAccess.ServiceObjects;
using MKT.Logica;
using MKT.Logica.Models;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.IO;
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

        [HttpPost]
        public ActionResult Upload()
        {
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];
                if (file != null && file.ContentLength > 0)
                {
                    //string path = "consolidado_" + DateTime.Now.ToLongDateString() + DateTime.Now.ToShortTimeString() + ".xlsx";
                    var filename = Path.GetFileName(file.FileName);

                    var path = Path.Combine(Server.MapPath("~/Files/SIM/"), filename);
                    file.SaveAs(path);

                    SLDocument sL = new SLDocument(path);
                    int lotes = 3000;

                    List<DO_Gerente> ListaGerentes = DataManager.GetAllGerentes();


                    using (var db = new EntitiesMKT())
                    {
                        //Agregamos los sims.
                        int row = 2;
                        while (!string.IsNullOrWhiteSpace(sL.GetCellValueAsString(row,2)))
                        {
                            SIMS sim = new SIMS();

                            string codigoNominaOperador = sL.GetCellValueAsString(row, 3);
                            int idOperador = ListaGerentes.Where(x => x.CodigoNomina == codigoNominaOperador).FirstOrDefault().IdGerente;

                            sim.ID_OPERADOR = idOperador;
                            sim.SIM = sL.GetCellValueAsString(row, 4);

                            db.SIMS.Add(sim);
                            if (row % lotes == 0)
                                db.SaveChanges();

                            row++;
                        }
                        db.SaveChanges();

                        List<DO_SIM> ListaSIM = DataManager.GetAllSIM();
                        //Agregamos la relacion SIM-GERENTE.
                        row = 2;

                        while (!string.IsNullOrWhiteSpace(sL.GetCellValueAsString(row, 2)))
                        {
                            SIMS_GERENTE sIMS_GERENTE = new SIMS_GERENTE();
                            string codigoNominaOperador = sL.GetCellValueAsString(row, 3);
                            string codigoNominaGerente = sL.GetCellValueAsString(row, 5);
                            string sim = sL.GetCellValueAsString(row, 4);

                            int idOperador = ListaGerentes.Where(x => x.CodigoNomina == codigoNominaOperador).FirstOrDefault().IdGerente;
                            int idGerente = ListaGerentes.Where(x => x.CodigoNomina == codigoNominaGerente).FirstOrDefault().IdGerente;

                            DateTime fechaPedido = sL.GetCellValueAsDateTime(row, 7);
                            DateTime fechaEntrega = sL.GetCellValueAsDateTime(row, 8);

                            sIMS_GERENTE.FECHA_ENTREGA = fechaEntrega;
                            sIMS_GERENTE.FECHA_SOLICITUD = fechaPedido;
                            sIMS_GERENTE.ID_GERENTE = idGerente;
                            sIMS_GERENTE.ID_SIM = ListaSIM.Where(x => x.SIM == sim).FirstOrDefault().ID_SIM;

                            db.SIMS_GERENTE.Add(sIMS_GERENTE);

                            if (row % lotes == 0)
                                db.SaveChanges();

                            row++;
                        }

                        db.SaveChanges();
                    }
                }
            }

            return RedirectToAction("Index");
        }

        public ActionResult CargarSIM()
        {
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