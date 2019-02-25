using MKT.DataAccess.ServiceObjects;
using MKT.Logica.Models;
using System;
using System.Collections;
using System.Collections.Generic;
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
                    gerente.FechaInicio = (DateTime)tipo.GetProperty("FechaInicio").GetValue(itemGerente, null);
                    gerente.FechaTermino = (DateTime)tipo.GetProperty("FechaTermino").GetValue(itemGerente, null);
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
                    gerente.FechaInicio = (DateTime)tipo.GetProperty("FechaInicio").GetValue(itemGerente, null);
                    gerente.FechaTermino = (DateTime)tipo.GetProperty("FechaTermino").GetValue(itemGerente, null);
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

            return sO_Sim.Insert(dO_SIM.operador.IdGerente, dO_SIM.gerente.IdGerente, dO_SIM.SIM, dO_SIM.FechaSolicitud, dO_SIM.FechaEntrega);
        } 

        public static List<DO_SIM> GetAllSIM()
        {
            SO_Sim sO_Sim = new SO_Sim();

            List<DO_SIM> ListaResultante = new List<DO_SIM>();

            IList informacionBD = sO_Sim.GetAll();

            if (informacionBD != null)
            {
                foreach (var item in informacionBD)
                {
                    DO_SIM dO_SIM = new DO_SIM();

                    Type tipo = item.GetType();

                    dO_SIM.ID_SIM = (int)tipo.GetProperty("ID_SIMS").GetValue(item, null);
                    dO_SIM.operador = new DO_Gerente();

                    DO_Gerente operador = new DO_Gerente();
                    operador = GetGerente((int)tipo.GetProperty("ID_OPERADOR").GetValue(item, null));
                    dO_SIM.operador = operador;
                    
                    DO_Gerente gerente = new DO_Gerente();
                    gerente = GetGerente((int)tipo.GetProperty("ID_GERENTE").GetValue(item, null));
                    dO_SIM.gerente = gerente;

                    dO_SIM.SIM = (string)tipo.GetProperty("SIM").GetValue(item, null);
                    dO_SIM.FechaSolicitud = (DateTime)tipo.GetProperty("FECHA_SOLICITUD").GetValue(item, null);
                    dO_SIM.FechaEntrega = (DateTime)tipo.GetProperty("FECHA_ENTREGA").GetValue(item, null);
                    
                    ListaResultante.Add(dO_SIM);
                }
            }

            return ListaResultante;
        }
        #endregion
    }
}
