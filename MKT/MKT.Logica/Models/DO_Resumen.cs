using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKT.Logica.Models
{
    public class DO_Resumen
    {
        public string Nombre { get; set; }
        public string CodigoNomina { get; set; }
        public int SIM_ENTREGADOS { get; set; }
        public int CANTIDAD_REPORTADOS { get; set; }
        public int CANTIDAD_EXISTOSAS { get; set; }
        public int CANTIDAD_ACTIVOS { get; set; }
        
    }
}
