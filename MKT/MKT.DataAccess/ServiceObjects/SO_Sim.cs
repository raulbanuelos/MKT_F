﻿using MKT.DataAccess.SQLServer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKT.DataAccess.ServiceObjects
{
    public class SO_Sim
    {
        private string SP_GET_SIMS = "SP_GET_SIMS";

        public int Insert(int idOperador, string sim)
        {
            try
            {
                using (var Conexion = new EntitiesMKT())
                {
                    SIMS sIMS = new SIMS();

                    sIMS.ID_OPERADOR = idOperador;
                    sIMS.SIM = sim;

                    Conexion.SIMS.Add(sIMS);

                    Conexion.SaveChanges();

                    return sIMS.ID_SIMS;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public DataSet GetAll()
        {
            try
            {
                DataSet datos = new DataSet();
                Desing_SQL conexion = new Desing_SQL();
                Dictionary<string, object> parametros = new Dictionary<string, object>();

                datos = conexion.EjecutarStoredProcedure(SP_GET_SIMS, parametros);

                return datos;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
