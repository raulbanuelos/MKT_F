using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKT.DataAccess.ServiceObjects
{
    public class SO_SIM_Gerente
    {
        public int Insert(DateTime fechaEntrega, DateTime fechaSolicitud, int idSIM, int idGerente)
        {
            try
            {
                using (var Conexion = new EntitiesMKT())
                {
                    SIMS_GERENTE sIMS_GERENTE = new SIMS_GERENTE();

                    sIMS_GERENTE.FECHA_ENTREGA = fechaEntrega;
                    sIMS_GERENTE.FECHA_SOLICITUD = fechaSolicitud;
                    sIMS_GERENTE.ID_SIM = idSIM;
                    sIMS_GERENTE.ID_GERENTE = idGerente;

                    Conexion.SIMS_GERENTE.Add(sIMS_GERENTE);

                    Conexion.SaveChanges();

                    return sIMS_GERENTE.ID_SIM_GERENTE;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int Update(DateTime fechaEntrega, DateTime fechaSolicitud, int idSIM, int idGerente, int idSIMGerente)
        {
            try
            {
                using (var Conexion = new EntitiesMKT())
                {
                    SIMS_GERENTE sIMS_GERENTE = Conexion.SIMS_GERENTE.Where(x => x.ID_SIM_GERENTE == idSIMGerente).FirstOrDefault();

                    sIMS_GERENTE.FECHA_ENTREGA = fechaEntrega;
                    sIMS_GERENTE.FECHA_SOLICITUD = fechaSolicitud;
                    sIMS_GERENTE.ID_SIM = idSIM;
                    sIMS_GERENTE.ID_GERENTE = idGerente;

                    Conexion.Entry(sIMS_GERENTE).State = EntityState.Modified;

                    return Conexion.SaveChanges();

                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
