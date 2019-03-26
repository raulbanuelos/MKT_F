using MKT.DataAccess.ServiceObjects;
using MKT.Logica.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKT.Logica
{
    public static class DataManager
    {
        #region Gerentes
        public static List<DO_Gerente> GetAllGerentes()
        {
            List<DO_Gerente> ListadoGerentes = new List<DO_Gerente>();

            SO_Gerente sO_Gerente = new SO_Gerente();

            IList informacionBD = sO_Gerente.GetAllGerente();

            if (informacionBD != null)
            {
                foreach (var itemGerente in informacionBD)
                {
                    DO_Gerente gerente = new DO_Gerente();

                    Type tipo = itemGerente.GetType();

                    gerente.IdGerente = (int)tipo.GetProperty("Id").GetValue(itemGerente, null);
                    gerente.CodigoNomina = (string)tipo.GetProperty("CodigoNomina").GetValue(itemGerente, null);
                    gerente.Nombre = (string)tipo.GetProperty("Nombre").GetValue(itemGerente, null);
                    gerente.Entidad = (string)tipo.GetProperty("Entidad").GetValue(itemGerente, null);
                    gerente.IsActive = (bool)tipo.GetProperty("Activo").GetValue(itemGerente, null);

                    if (Convert.ToDateTime(tipo.GetProperty("FechaInicio").GetValue(itemGerente, null)) != DateTime.MinValue)
                    {
                        gerente.FechaInicio = (DateTime)tipo.GetProperty("FechaInicio").GetValue(itemGerente, null);
                    }

                    if (Convert.ToDateTime(tipo.GetProperty("FechaTermino").GetValue(itemGerente, null)) != DateTime.MinValue)
                    {
                        gerente.FechaTermino = (DateTime)tipo.GetProperty("FechaTermino").GetValue(itemGerente, null);
                    }

                    gerente.Cargo = (string)tipo.GetProperty("Cargo").GetValue(itemGerente, null);

                    ListadoGerentes.Add(gerente);
                }
            }

            return ListadoGerentes;
        }

        public static int InsertGerente(DO_Gerente dO_Gerente)
        {
            SO_Gerente sO_Gerente = new SO_Gerente();

            return sO_Gerente.Insert(dO_Gerente.CodigoNomina, dO_Gerente.Nombre, dO_Gerente.Entidad, dO_Gerente.IsActive, dO_Gerente.FechaInicio, dO_Gerente.FechaTermino,dO_Gerente.Cargo);
        }

        public static int UpdateGerente(DO_Gerente dO_Gerente)
        {
            SO_Gerente sO_Gerente = new SO_Gerente();

            return sO_Gerente.Update(dO_Gerente.IdGerente, dO_Gerente.CodigoNomina, dO_Gerente.Nombre, dO_Gerente.Entidad, dO_Gerente.IsActive, dO_Gerente.FechaInicio, dO_Gerente.FechaTermino, dO_Gerente.Cargo);
        }

        public static int DeleteGerente(int idGerente)
        {
            SO_Gerente sO_Gerente = new SO_Gerente();

            return sO_Gerente.Delete(idGerente);
        } 

        public static bool ExistGerente(string codigoNomina)
        {
            bool respuesta = true;

            SO_Gerente sO_Gerente = new SO_Gerente();

            IList informacionBD = sO_Gerente.GetGerente(codigoNomina);

            if (informacionBD != null)
            {
                if (informacionBD.Count == 0)
                {
                    respuesta = false;
                }
            }

            return respuesta;
        }

        public static DO_Gerente GetGerente(int idGerente)
        {
            DO_Gerente gerente = new DO_Gerente();

            SO_Gerente sO_Gerente = new SO_Gerente();

            IList informacionBD = sO_Gerente.GetGerente(idGerente);

            if (informacionBD != null)
            {
                foreach (var itemGerente in informacionBD)
                {
                    gerente = new DO_Gerente();
                    Type tipo = itemGerente.GetType();

                    gerente.IdGerente = (int)tipo.GetProperty("Id").GetValue(itemGerente, null);
                    gerente.CodigoNomina = (string)tipo.GetProperty("CodigoNomina").GetValue(itemGerente, null);
                    gerente.Nombre = (string)tipo.GetProperty("Nombre").GetValue(itemGerente, null);
                    gerente.Entidad = (string)tipo.GetProperty("Entidad").GetValue(itemGerente, null);
                    gerente.IsActive = (bool)tipo.GetProperty("Activo").GetValue(itemGerente, null);

                    if (Convert.ToDateTime(tipo.GetProperty("FechaInicio").GetValue(itemGerente, null)) != DateTime.MinValue)
                    {
                        gerente.FechaInicio = (DateTime)tipo.GetProperty("FechaInicio").GetValue(itemGerente, null);
                    }
                    
                    if (Convert.ToDateTime(tipo.GetProperty("FechaTermino").GetValue(itemGerente, null)) != DateTime.MinValue)
                    {
                        gerente.FechaTermino = (DateTime)tipo.GetProperty("FechaTermino").GetValue(itemGerente, null);
                    }
                    
                    gerente.Cargo = (string)tipo.GetProperty("Cargo").GetValue(itemGerente, null);
                }
            }
            return gerente;
        }
        #endregion

        #region SIMS
        public static int InsertSIM(DO_SIM dO_SIM)
        {
            SO_Sim sO_Sim = new SO_Sim();

            return sO_Sim.Insert(dO_SIM.operador.IdGerente, dO_SIM.SIM);
        }

        public static DO_SIM GetSIM(int idSIM)
        {
            DO_SIM dO_SIM = new DO_SIM();

            SO_Sim sO_Sim = new SO_Sim();

            DataSet informacionBD = sO_Sim.GetSIM(idSIM);

            if (informacionBD != null)
            {
                if (informacionBD.Tables.Count > 0 && informacionBD.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in informacionBD.Tables[0].Rows)
                    {
                        dO_SIM = new DO_SIM();
                        dO_SIM.ID_SIM = Convert.ToInt32(item["ID_SIMS"].ToString());
                        dO_SIM.SIM = item["SIM"].ToString();
                        dO_SIM.operador = GetGerente((int)item["ID_OPERADOR"]);
                        if (!string.IsNullOrEmpty(item["ID_SIM_GERENTE"].ToString()))
                        {
                            dO_SIM.idSIMGerente = Convert.ToInt32(item["ID_SIM_GERENTE"].ToString());
                            dO_SIM.gerente = GetGerente((int)item["ID_GERENTE"]);
                            dO_SIM.FechaSolicitud = Convert.ToDateTime(item["FECHA_SOLICITUD"].ToString());
                            dO_SIM.FechaEntrega = Convert.ToDateTime(item["FECHA_ENTREGA"].ToString());
                        }
                        else
                        {
                            dO_SIM.idSIMGerente = 0;
                        }
                        
                    }
                }
            }

            return dO_SIM;
        }

        public static List<DO_SIM> GetAllSIM(string fechaInicial, string fechaFinal)
        {
            SO_Sim sO_Sim = new SO_Sim();

            List<DO_SIM> ListaResultante = new List<DO_SIM>();

            DataSet informacionBD = sO_Sim.GetAll(fechaInicial, fechaFinal);

            if (informacionBD != null)
            {
                if (informacionBD.Tables.Count > 0 && informacionBD.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in informacionBD.Tables[0].Rows)
                    {
                        DO_SIM dO_SIM = new DO_SIM();
                        dO_SIM.ID_SIM = Convert.ToInt32(item["ID_SIMS"].ToString());
                        dO_SIM.SIM = item["SIM"].ToString();
                        dO_SIM.operador = GetGerente((int)item["ID_OPERADOR"]);
                        if (!string.IsNullOrEmpty(item["ID_SIM_GERENTE"].ToString()))
                        {
                            dO_SIM.gerente = GetGerente((int)item["ID_GERENTE"]);
                            dO_SIM.FechaSolicitud = Convert.ToDateTime(item["FECHA_SOLICITUD"].ToString());
                            dO_SIM.FechaEntrega = Convert.ToDateTime(item["FECHA_ENTREGA"].ToString());
                        }


                        ListaResultante.Add(dO_SIM);
                    }
                }
            }

            return ListaResultante;
        }
        #endregion

        #region SIM GERENTE
        public static int InsertSIMGerente(DateTime fechaEntrega, DateTime fechaSolicitud, int idSIM, int idGerente)
        {
            SO_SIM_Gerente sO_SIM_Gerente = new SO_SIM_Gerente();

            return sO_SIM_Gerente.Insert(fechaEntrega, fechaSolicitud, idSIM, idGerente);
        } 

        public static int UpdateSIMGerente(DateTime fechaEntrega, DateTime fechaSolicitud, int idSIM, int idGerente, int idSIMGerente)
        {
            SO_SIM_Gerente sO_SIM_Gerente = new SO_SIM_Gerente();

            return sO_SIM_Gerente.Update(fechaEntrega, fechaSolicitud, idSIM, idGerente, idSIMGerente);
        }
        #endregion

        #region Reportes
        public static List<DO_Resumen> GetResumen(string fechaInicial, string fechaFinal)
        {
            List<DO_Resumen> vs = new List<DO_Resumen>();

            SO_Diario sO_Diario = new SO_Diario();

            DataSet informacionBD = sO_Diario.GetResumen(fechaInicial,fechaFinal);

            if (informacionBD != null)
            {
                if (informacionBD.Tables.Count > 0 && informacionBD.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in informacionBD.Tables[0].Rows)
                    {
                        DO_Resumen dO_Resumen = new DO_Resumen();
                        if (!string.IsNullOrEmpty(item["Nombre"].ToString()))
                            dO_Resumen.Nombre = item["Nombre"].ToString();
                        else
                            dO_Resumen.Nombre = "NO ENCONTRADO";

                        if (!string.IsNullOrEmpty(item["CODIGO_NOMINA_GERENTE"].ToString()))
                            dO_Resumen.CodigoNomina = item["CODIGO_NOMINA_GERENTE"].ToString();
                        else
                            dO_Resumen.CodigoNomina = "NO ENCONTRADO";

                        if (!string.IsNullOrEmpty(item["SIM_ENTREGADOS"].ToString()))
                            dO_Resumen.SIM_ENTREGADOS = Convert.ToInt32(item["SIM_ENTREGADOS"].ToString());
                        else
                            dO_Resumen.SIM_ENTREGADOS = 0;

                        if (!string.IsNullOrEmpty(item["CANTIDAD_REPORTADOS"].ToString()))
                            dO_Resumen.CANTIDAD_REPORTADOS = Convert.ToInt32(item["CANTIDAD_REPORTADOS"].ToString());
                        else
                            dO_Resumen.CANTIDAD_REPORTADOS = 0;


                        if (!string.IsNullOrEmpty(item["CANTIDAD_EXITOSAS"].ToString()))
                            dO_Resumen.CANTIDAD_EXISTOSAS = Convert.ToInt32(item["CANTIDAD_EXITOSAS"].ToString());
                        else
                            dO_Resumen.CANTIDAD_EXISTOSAS = 0;


                        if (!string.IsNullOrEmpty(item["CANTIDAD_ACTIVOS"].ToString()))
                            dO_Resumen.CANTIDAD_ACTIVOS = Convert.ToInt32(item["CANTIDAD_ACTIVOS"].ToString());
                        else
                            dO_Resumen.CANTIDAD_ACTIVOS = 0;

                        vs.Add(dO_Resumen);
                        
                    }
                }
            }

            return vs;
        }
        #endregion
    }
}
