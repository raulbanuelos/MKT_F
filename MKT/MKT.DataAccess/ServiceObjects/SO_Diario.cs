using MKT.DataAccess.SQLServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKT.DataAccess.ServiceObjects
{
    public class SO_Diario
    {
        private string SP_MKT_GET_CRUCE = "SP_MKT_GET_CRUCE";
        public DataSet GetResumen()
        {
            try
            {
                DataSet data = new DataSet();
                Desing_SQL conexion = new Desing_SQL();

                Dictionary<string, object> parametros = new Dictionary<string, object>();

                data = conexion.EjecutarStoredProcedure(SP_MKT_GET_CRUCE, parametros);
                return data;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
