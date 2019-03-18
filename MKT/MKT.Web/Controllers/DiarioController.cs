using MKT.DataAccess.ServiceObjects;
using SpreadsheetLight;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace MKT.Web.Controllers
{
    public class DiarioController : Controller
    {
        // GET: Diario
        public ActionResult Index()
        {
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
                    
                    var path = Path.Combine(Server.MapPath("~/Files/Consolidado/"), filename);
                    file.SaveAs(path);

                    SLDocument sL = new SLDocument(path);
                    int lotes = 5000;
                    using (var db = new EntitiesMKT())
                    {
                        int iRow = 2;
                        while (!string.IsNullOrEmpty(sL.GetCellValueAsString(iRow, 1)))
                        {
                            Diario diario = new Diario();
                            diario.ICC = sL.GetCellValueAsString(iRow, 1);
                            diario.DN = sL.GetCellValueAsString(iRow, 2);
                            diario.USUARIO = sL.GetCellValueAsString(iRow, 3);
                            diario.NOMBRE_CLIENTE = sL.GetCellValueAsString(iRow, 4);
                            diario.FECHA_INICIO = Convert.ToDateTime(sL.GetCellValueAsString(iRow, 5));//
                            diario.CODIGO_NOMINA_PROMOTOR = sL.GetCellValueAsString(iRow, 6);
                            diario.NOMBRE_PROMOTOR = sL.GetCellValueAsString(iRow, 7);
                            diario.CODIGO_NOMINA_GERENTE = sL.GetCellValueAsString(iRow, 8);
                            diario.ESTATUS = sL.GetCellValueAsString(iRow, 10);
                            diario.FECHA_ESTATUS = Convert.ToDateTime(sL.GetCellValueAsString(iRow, 11));//
                            diario.OPERADOR_ORIGEN = sL.GetCellValueAsString(iRow, 12);
                            diario.OPERADOR_DESTINO = sL.GetCellValueAsString(iRow, 13);
                            diario.INTERCONEXION = sL.GetCellValueAsString(iRow, 14);
                            diario.NUMERO_FOLIO_ABD = sL.GetCellValueAsString(iRow, 20);
                            diario.ESTADO = sL.GetCellValueAsString(iRow, 22);
                            diario.APP_ITX = sL.GetCellValueAsString(iRow, 25);
                            diario.VALIDACION_INTERCONEXION = sL.GetCellValueAsString(iRow, 26);
                            diario.FECHA_RECARGA = Convert.ToDateTime(sL.GetCellValueAsString(iRow, 27));//
                            diario.NO_RECARGA = sL.GetCellValueAsInt32(iRow, 28);

                            db.Diario.Add(diario);
                            if (iRow % lotes == 0)
                            {
                                db.SaveChanges();
                            }

                            iRow++;
                        }

                        db.SaveChanges();
                    }
                }
            }
            
            return RedirectToAction("Index");
        }
        
    }
}