using System;
using System.Web.Mvc;

namespace MKT.Logica.Models
{
    public class DO_SIM
    {
        public int ID_SIM { get; set; }
        public DO_Gerente operador { get; set; }
        public DO_Gerente gerente { get; set; }
        public string SIM { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public DateTime FechaEntrega { get; set; }

        public string operadorSelected { get; set; }
        public string gerenteSelected { get; set; }
    }
}
