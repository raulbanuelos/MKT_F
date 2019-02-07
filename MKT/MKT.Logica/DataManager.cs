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

                    gerente.IdGerente = (int)tipo.GetProperty("Id").GetValue(itemGerente,null);
                    gerente.CodigoNomina = (string)tipo.GetProperty("CodigoNomina").GetValue(itemGerente, null);
                    gerente.Nombre = (string)tipo.GetProperty("Nombre").GetValue(itemGerente, null);
                    gerente.Entidad = (string)tipo.GetProperty("Entidad").GetValue(itemGerente, null);
                    gerente.IsActive = (bool)tipo.GetProperty("Activo").GetValue(itemGerente, null);
                    gerente.FechaInicio = (DateTime)tipo.GetProperty("FechaInicio").GetValue(itemGerente, null);
                    gerente.FechaTermino = (DateTime)tipo.GetProperty("FechaTermino").GetValue(itemGerente, null);
                    
                    ListadoGerentes.Add(gerente);
                }
            }

            return ListadoGerentes;
        }

        public static int InsertGerente(DO_Gerente dO_Gerente)
        {
            SO_Gerente sO_Gerente = new SO_Gerente();

            return sO_Gerente.Insert(dO_Gerente.CodigoNomina, dO_Gerente.Nombre, dO_Gerente.Entidad, dO_Gerente.IsActive, dO_Gerente.FechaInicio, dO_Gerente.FechaTermino);
        }

        public static int UpdateGerente(DO_Gerente dO_Gerente)
        {
            SO_Gerente sO_Gerente = new SO_Gerente();

            return sO_Gerente.Update(dO_Gerente.IdGerente, dO_Gerente.CodigoNomina, dO_Gerente.Nombre, dO_Gerente.Entidad, dO_Gerente.IsActive, dO_Gerente.FechaInicio, dO_Gerente.FechaTermino);
        }

        public static int DeleteGerente(int idGerente)
        {
            SO_Gerente sO_Gerente = new SO_Gerente();

            return sO_Gerente.Delete(idGerente);
        }
    }
}
