using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKT.Logica.Models
{
    public class DO_Diario
    {
        public int ID_DIARIO { get; set; }
        public string ICC { get; set; }
        public string DN { get; set; }
        public string USUARIO { get; set; }
        public string NOMBRE_CLIENTE { get; set; }
        public DateTime FECHA_INICIO { get; set; }
        public string CODIGO_NOMINA_PROMOTOR { get; set; }
        public string NOMBRE_PROMOTOR { get; set; }
        public string CODIGO_NOMINA_GERENTE { get; set; }
        public string ESTATUS { get; set; }
        public DateTime FECHA_ESTATUS { get; set; }
        public string OPERADOR_ORIGEN { get; set; }
        public string OPERADOR_DESTINO { get; set; }
        public string INTERCONEXION { get; set; }
        public string NUMERO_FOLIO_ABD { get; set; }
        public string ESTADO { get; set; }
        public string APP_ITX { get; set; }
        public string VALIDACION_INTERCONEXION { get; set; }
        public DateTime FECHA_RECARGA { get; set; }
        public string NO_RECARGA { get; set; }
    }
}
