using System.Collections;
using System.Linq;

namespace MKT.DataAccess.ServiceObjects
{
    public class SO_Gerente
    {
        public IList GetAllGerente()
        {
            using (var Conexion = new EntitiesMKT())
            {
                var ListaGerentes = (from a in Conexion.Gerente
                             select a).ToList();
                return ListaGerentes;
            }
        }
    }
}
