using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKT.DataAccess.ServiceObjects
{
    public class SO_Sim
    {
        public int Insert(int idOperador, int idGerente, string sim, DateTime fechaSolicitud, DateTime fechaEntrega)
        {
            try
            {
                using (var Conexion = new EntitiesMKT())
                {
                    SIMS sIMS = new SIMS();

                    sIMS.ID_OPERADOR = idOperador;
                    sIMS.ID_GERENTE = idGerente;
                    sIMS.SIM = sim;
                    sIMS.FECHA_SOLICITUD = fechaSolicitud;
                    sIMS.FECHA_ENTREGA = fechaEntrega;

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

        public IList GetAll()
        {
            try
            {
                using (var Conexion = new EntitiesMKT())
                {
                    var lista = (from a in Conexion.SIMS
                                 select a).OrderByDescending(x => x.FECHA_SOLICITUD).ToList();

                    return lista;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
